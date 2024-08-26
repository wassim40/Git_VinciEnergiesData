
# Étape 1 : Construire l'application
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

# Copier csproj et restaurer les dépendances
COPY *.csproj ./
RUN dotnet restore

# Copier tout le reste et compiler
COPY . ./
RUN dotnet publish -c Release -o out

# Étape 2 : Créer l'image finale
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/out .

# Exposer le port sur lequel l'application écoutera
EXPOSE 80

# Commande pour démarrer l'application
ENTRYPOINT ["dotnet", "VinciEnergiesData.dll"]
