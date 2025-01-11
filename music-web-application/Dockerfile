#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ARG ASPNETCORE_ENVIRONMENT
ARG SPOTIFY_WEB_API_BASE_URI
ARG SPOTIFY_WEB_API_TOKEN_ENDPOINT_URI

ENV ASPNETCORE_ENVIRONMENT=$ASPNETCORE_ENVIRONMENT
ENV SPOTIFY_WEB_API_BASE_URI=$SPOTIFY_WEB_API_BASE_URI
ENV SPOTIFY_WEB_API_TOKEN_ENDPOINT_URI=$SPOTIFY_WEB_API_TOKEN_ENDPOINT_URI

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["music-web-application/music-web-application.csproj", "music-web-application/"]
RUN dotnet restore "./music-web-application/music-web-application.csproj"
COPY . .
WORKDIR "/src/music-web-application"
RUN dotnet build "./music-web-application.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./music-web-application.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "music-web-application.dll"]