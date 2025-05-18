# Etapa 1: Construcción
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copiamos todo el contenido del repo
COPY . .

# Nos movemos a la carpeta donde está el proyecto y hacemos publish
WORKDIR /src/ExpenseTracker.API
RUN dotnet publish -c Release -o /app/publish

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app

# Copiamos el output del build
COPY --from=build /app/publish .

# Puerto en el que la app escuchará
EXPOSE 80

# Comando para arrancar la app
ENTRYPOINT ["dotnet", "ExpenseTracker.API.dll"]