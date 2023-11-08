#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Directory.Build.props", "."]
COPY ["src/Services/Discount/Discount.API/Discount.API.csproj", "src/Services/Discount/Discount.API/"]
COPY ["src/Common/Common.Logging/Common.Logging.csproj", "src/Common/Common.Logging/"]
COPY ["src/Services/Discount/Discount.Application/Discount.Application.csproj", "src/Services/Discount/Discount.Application/"]
COPY ["src/Common/Common.Primitives/Common.Primitives.csproj", "src/Common/Common.Primitives/"]
COPY ["src/Services/Discount/Discount.Domain/Discount.Domain.csproj", "src/Services/Discount/Discount.Domain/"]
COPY ["src/Services/Discount/Discount.Infrastructure/Discount.Infrastructure.csproj", "src/Services/Discount/Discount.Infrastructure/"]
RUN dotnet restore "src/Services/Discount/Discount.API/Discount.API.csproj"
COPY . .
WORKDIR "/src/src/Services/Discount/Discount.API"
RUN dotnet build "Discount.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Discount.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Discount.API.dll"]