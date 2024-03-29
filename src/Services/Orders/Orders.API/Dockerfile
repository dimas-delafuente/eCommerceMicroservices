#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Directory.Build.props", "."]
COPY ["src/Services/Orders/Orders.API/Orders.API.csproj", "src/Services/Orders/Orders.API/"]
COPY ["src/Common/Common.Logging/Common.Logging.csproj", "src/Common/Common.Logging/"]
COPY ["src/Common/EventBus.Core/EventBus.Core.csproj", "src/Common/EventBus.Core/"]
COPY ["src/Common/EventBus.Messages/EventBus.Messages.csproj", "src/Common/EventBus.Messages/"]
COPY ["src/Services/Orders/Orders.Application/Orders.Application.csproj", "src/Services/Orders/Orders.Application/"]
COPY ["src/Common/Common.Primitives/Common.Primitives.csproj", "src/Common/Common.Primitives/"]
COPY ["src/Services/Orders/Orders.Domain/Orders.Domain.csproj", "src/Services/Orders/Orders.Domain/"]
COPY ["src/Services/Orders/Orders.Infrastructure/Orders.Infrastructure.csproj", "src/Services/Orders/Orders.Infrastructure/"]
RUN dotnet restore "src/Services/Orders/Orders.API/Orders.API.csproj"
COPY . .
WORKDIR "/src/src/Services/Orders/Orders.API"
RUN dotnet build "Orders.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Orders.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Orders.API.dll"]