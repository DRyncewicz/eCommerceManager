#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
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
RUN dotnet restore "./src/API/eCommerceManager.API/./eCommerceManager.API.csproj"
COPY . .
WORKDIR "/src/src/API/eCommerceManager.API"
RUN dotnet build "./eCommerceManager.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./eCommerceManager.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "eCommerceManager.API.dll"]