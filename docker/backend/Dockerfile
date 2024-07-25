FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY backend/BlogEngine.Api/BlogEngine.Api.csproj BlogEngine.Api/
RUN dotnet restore "BlogEngine.Api/BlogEngine.Api.csproj"
COPY backend/BlogEngine.Api/ BlogEngine.Api/
WORKDIR "/src/BlogEngine.Api"
RUN dotnet build "BlogEngine.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlogEngine.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlogEngine.Api.dll"]
