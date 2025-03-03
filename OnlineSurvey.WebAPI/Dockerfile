FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["OnlineSurvey.Application/OnlineSurvey.Application.csproj", "OnlineSurvey.Application/"]
COPY ["OnlineSurvey.Infrastructure/OnlineSurvey.Infrastructure.csproj", "OnlineSurvey.Infrastructure/"]
COPY ["OnlineSurvey.WebAPI/OnlineSurvey.WebAPI.csproj", "OnlineSurvey.WebAPI/"]

RUN dotnet restore "./OnlineSurvey.Application/./OnlineSurvey.Application.csproj"
RUN dotnet restore "./OnlineSurvey.Infrastructure/./OnlineSurvey.Infrastructure.csproj"
RUN dotnet restore "./OnlineSurvey.WebAPI/./OnlineSurvey.WebAPI.csproj"
COPY . .
WORKDIR "/src/OnlineSurvey.WebAPI"
RUN dotnet build "./OnlineSurvey.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./OnlineSurvey.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OnlineSurvey.WebAPI.dll"]