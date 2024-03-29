#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Directory.Build.props", "."]
COPY ["src/Gateway/OcelotApiGateway/OcelotApiGateway.csproj", "src/Gateway/OcelotApiGateway/"]
COPY ["src/Common/Common.Logging/Common.Logging.csproj", "src/Common/Common.Logging/"]
RUN dotnet restore "src/Gateway/OcelotApiGateway/OcelotApiGateway.csproj"
COPY . .
WORKDIR "/src/src/Gateway/OcelotApiGateway"
RUN dotnet build "OcelotApiGateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OcelotApiGateway.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OcelotApiGateway.dll"]