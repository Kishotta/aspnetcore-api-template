FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Api/AspNetCoreApiTemplate.Api/AspNetCoreApiTemplate.Api.csproj", "src/Api/AspNetCoreApiTemplate.Api/"]
RUN dotnet restore "src/Api/AspNetCoreApiTemplate.Api/AspNetCoreApiTemplate.Api.csproj"
COPY . .
WORKDIR "/src/src/Api/AspNetCoreApiTemplate.Api"
RUN dotnet build "AspNetCoreApiTemplate.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "AspNetCoreApiTemplate.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AspNetCoreApiTemplate.Api.dll"]
