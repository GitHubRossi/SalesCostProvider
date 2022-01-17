#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build

WORKDIR /src
COPY ["SalesCostProvider/SalesCostProvider.csproj", "SalesCostProvider/"]
COPY ["SalesCostProvider/nuget.config", "SalesCostProvider/"]
COPY ["SalesCostProvider.SL/SalesCostProvider.SL.csproj", "SalesCostProvider.SL/"]
COPY ["SalesCostProvider.DAL/SalesCostProvider.DAL.csproj", "SalesCostProvider.DAL/"]

RUN dotnet restore SalesCostProvider/SalesCostProvider.csproj --configfile "SalesCostProvider/nuget.config"
RUN dotnet restore "SalesCostProvider/SalesCostProvider.csproj"
RUN dotnet restore "SalesCostProvider.SL/SalesCostProvider.SL.csproj"
RUN dotnet restore "SalesCostProvider.DAL/SalesCostProvider.DAL.csproj"

COPY . .
WORKDIR "SalesCostProvider"
RUN dotnet build "SalesCostProvider.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SalesCostProvider.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SalesCostProvider.dll"]