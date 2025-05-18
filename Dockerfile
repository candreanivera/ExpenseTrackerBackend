# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY *.sln .
COPY ExpenseTracker.API/*.csproj ./ExpenseTracker.API/
RUN dotnet restore

COPY ExpenseTracker.API/. ./ExpenseTracker.API/
WORKDIR /app/ExpenseTracker.API
RUN dotnet publish -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "ExpenseTracker.API.dll"]