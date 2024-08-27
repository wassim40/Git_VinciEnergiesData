
# Étape 1 : Construire l'application
# Utilise une image de base .NET pour construire l'application
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

# Utilise une image de base .NET SDK pour compiler l'application
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["VinciEnergiesData.csproj", "./"]
RUN dotnet restore "VinciEnergiesData.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "VinciEnergiesData.csproj" -c Release -o /app/build

# Publie l'application
FROM build AS publish
RUN dotnet publish "MonProjet.csproj" -c Release -o /app/publish

# Finalise l'image en copiant les fichiers de l'application publiés
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VinciEnergiesData.dll"]
