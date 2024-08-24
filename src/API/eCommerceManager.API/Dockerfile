# U¿yj oficjalnego obrazu ASP.NET Core jako bazy
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

# Ustaw u¿ytkownika na 'app'
USER app
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

# U¿yj oficjalnego obrazu SDK jako bazy do budowy
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Skopiuj pliki projektów
COPY ["src/API/eCommerceManager.API/eCommerceManager.API.csproj", "src/API/eCommerceManager.API/"]
COPY ["src/BuildingBlocks/Infrastructure/Infrastructure.csproj", "src/BuildingBlocks/Infrastructure/"]
COPY ["src/BuildingBlocks/Application/Application.csproj", "src/BuildingBlocks/Application/"]
COPY ["src/SharedKernal/SharedKernal.csproj", "src/SharedKernal/"]
COPY ["src/Modules/Modules.Discount.Infrastructure/Modules.Discounts.Infrastructure.csproj", "src/Modules/Modules.Discount.Infrastructure/"]
COPY ["src/Modules/Modules.Orders.Infrastructure/Modules.Orders.Infrastructure.csproj", "src/Modules/Modules.Orders.Infrastructure/"]
COPY ["src/Modules/Modules.Products.Infrastructure/Modules.Products.Infrastructure.csproj", "src/Modules/Modules.Products.Infrastructure/"]
COPY ["src/Modules/Modules.Products.Application/Modules.Products.Application.csproj", "src/Modules/Modules.Products.Application/"]
COPY ["src/Modules/Modules.Products.Domain/Modules.Products.Domain.csproj", "src/Modules/Modules.Products.Domain/"]
COPY ["src/Modules/Modules.Stocks.Infrastructure/Modules.Stocks.Infrastructure.csproj", "src/Modules/Modules.Stocks.Infrastructure/"]
COPY ["src/Modules/Modules.Users.Infrastructure/Modules.Users.Infrastructure.csproj", "src/Modules/Modules.Users.Infrastructure/"]

# Przywróæ zale¿noœci
RUN dotnet restore "./src/API/eCommerceManager.API/eCommerceManager.API.csproj"

# Skopiuj wszystkie pliki
COPY . .

# Ustaw katalog roboczy i zbuduj aplikacjê
WORKDIR "/src/src/API/eCommerceManager.API"
RUN dotnet build "./eCommerceManager.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publikuj aplikacjê
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./eCommerceManager.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# U¿yj obrazu bazowego
FROM base AS final

# Zainstaluj OpenSSL
RUN apt-get update && apt-get install -y openssl

# Ustaw katalog roboczy
WORKDIR /app

# Skopiuj opublikowane pliki z etapu publikacji
COPY --from=publish /app/publish .

# Ustaw punkt wejœcia
ENTRYPOINT ["dotnet", "eCommerceManager.API.dll"]

# Ustawienie zmiennych œrodowiskowych dla Kestrel
ENV ASPNETCORE_URLS=https://+:5001;http://+:5000