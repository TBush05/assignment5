# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["DbPinger.Console/DbPinger.Console.csproj", "DbPinger.Console/"]
COPY ["DBConnector/DBConnector.csproj", "DBConnector/"]

RUN dotnet restore "DbPinger.Console/DbPinger.Console.csproj"

COPY . .
WORKDIR /src/DbPinger.Console
RUN dotnet publish "DbPinger.Console.csproj" -c Release -o /app/publish

# Runtime
FROM mcr.microsoft.com/dotnet/runtime:8.0
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "DbPinger.Console.dll"]
