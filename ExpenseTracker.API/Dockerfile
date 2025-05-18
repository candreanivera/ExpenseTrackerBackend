# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy csproj y restore
COPY *.sln .
COPY ExpenseTrackerBackend/*.csproj ./ExpenseTrackerBackend/
RUN dotnet restore

# Copy everything and publish
COPY ExpenseTrackerBackend/. ./ExpenseTrackerBackend/
WORKDIR /app/ExpenseTrackerBackend
RUN dotnet publish -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Listening port
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "ExpenseTrackerBackend.dll"]
