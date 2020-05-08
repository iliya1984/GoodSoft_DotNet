FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct project
COPY . ./
RUN dotnet restore Services/GS.Logging/GS.Logging.Api/*.csproj
RUN dotnet publish Services/GS.Logging/GS.Logging.Api/*.csproj -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "GS.Logging.Api.dll"]
