FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["JWTService/JWTService.csproj", "./JWTService/"]
RUN dotnet restore "./JWTService/JWTService.csproj"
COPY . .
RUN dotnet build "JWTService/JWTService.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "JWTService/JWTService.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "JWTService.dll"]