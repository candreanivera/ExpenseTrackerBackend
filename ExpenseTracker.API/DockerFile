# Use the official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copy csproj and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the files and build the app
COPY . ./
RUN dotnet publish -c Release -o out

# Use the ASP.NET runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/out .

# Expose the port the app runs on
EXPOSE 80

# Run the app
ENTRYPOINT ["dotnet", "ExpenseTracker.API.dll"]