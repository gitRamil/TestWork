FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Test.Web.Api/Test.Web.Api.csproj", "./Test.Web.Api/"]
RUN dotnet restore "./Test.Web.Api/Test.Web.Api.csproj"
COPY . .
RUN dotnet build "Test.Web.Api/Test.Web.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Test.Web.Api/Test.Web.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Test.Web.Api.dll"]