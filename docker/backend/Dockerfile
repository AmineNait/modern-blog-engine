# Utiliser l'image officielle .NET Core SDK comme image de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copier les fichiers .csproj et restaurer les dépendances
COPY BlogEngine.Api/BlogEngine.Api.csproj BlogEngine.Api/
RUN dotnet restore BlogEngine.Api/BlogEngine.Api.csproj

# Copier le reste des fichiers et construire l'application
COPY . .
RUN dotnet publish BlogEngine.Api/BlogEngine.Api.csproj -c Release -o /app/publish

# Utiliser l'image officielle .NET Core runtime comme image de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "BlogEngine.Api.dll"]
