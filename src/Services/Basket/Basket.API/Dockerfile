#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Services/Basket/Basket.API/Basket.API.csproj", "src/Services/Basket/Basket.API/"]
COPY ["src/Common/EventBus.Core/EventBus.Core.csproj", "src/Common/EventBus.Core/"]
COPY ["src/Common/EventBus.Messages/EventBus.Messages.csproj", "src/Common/EventBus.Messages/"]
COPY ["src/Services/Basket/Basket.Application/Basket.Application.csproj", "src/Services/Basket/Basket.Application/"]
COPY ["src/Services/Basket/Basket.Domain/Basket.Domain.csproj", "src/Services/Basket/Basket.Domain/"]
COPY ["src/Common/Common.Primitives/Common.Primitives.csproj", "src/Common/Common.Primitives/"]
COPY ["src/Services/Basket/Basket.Infrastructure/Basket.Infrastructure.csproj", "src/Services/Basket/Basket.Infrastructure/"]
RUN dotnet restore "src/Services/Basket/Basket.API/Basket.API.csproj"
COPY . .
WORKDIR "/src/src/Services/Basket/Basket.API"
RUN dotnet build "Basket.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Basket.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Basket.API.dll"]