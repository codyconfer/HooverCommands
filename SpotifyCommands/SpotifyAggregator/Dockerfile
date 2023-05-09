FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["SpotifyAggregator/SpotifyAggregator.csproj", "SpotifyAggregator/"]
RUN dotnet restore "SpotifyAggregator/SpotifyAggregator.csproj"
COPY . .
WORKDIR "/src/SpotifyAggregator"
RUN dotnet build "SpotifyAggregator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SpotifyAggregator.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SpotifyAggregator.dll"]
