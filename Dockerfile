FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.sln ./
COPY ./FirstWebApp/FirstWebApp.csproj ./FirstWebApp/
COPY ./FirstWebAppTest/FirstWebAppTest.csproj ./FirstWebAppTest/
RUN dotnet restore

# Copy everything else and build
COPY . ./
WORKDIR /app/FirstWebApp
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
WORKDIR /app
COPY --from=build-env /app/FirstWebApp/out ./
ENTRYPOINT ["dotnet", "FirstWebApp.dll"]