FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CommandsImplementation/CommandsImplementation.csproj", "CommandsImplementation/"]
RUN dotnet restore "CommandsImplementation/CommandsImplementation.csproj"
COPY . .
WORKDIR "/src/CommandsImplementation"
RUN dotnet build "CommandsImplementation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CommandsImplementation.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CommandsImplementation.dll"]
