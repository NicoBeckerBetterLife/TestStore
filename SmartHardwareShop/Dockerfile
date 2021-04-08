#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
ENV ASPNETCORE_URLS=https://*:44343

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["SmartHardwareShop/SmartHardwareShop.csproj", "SmartHardwareShop/"]
RUN dotnet restore "SmartHardwareShop/SmartHardwareShop.csproj"
COPY . .
WORKDIR "/src/SmartHardwareShop"
RUN dotnet build "SmartHardwareShop.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SmartHardwareShop.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SmartHardwareShop.dll"]