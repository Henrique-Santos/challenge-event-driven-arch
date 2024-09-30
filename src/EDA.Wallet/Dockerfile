FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["EDA.Wallet/EDA.Wallet.csproj", "EDA.Wallet/"]
COPY ["EDA.Core/EDA.Core.csproj", "EDA.Core/"]
RUN dotnet restore "EDA.Wallet/EDA.Wallet.csproj"
RUN dotnet restore "EDA.Core/EDA.Core.csproj"
COPY . .
WORKDIR "EDA.Wallet"
RUN dotnet build "EDA.Wallet.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EDA.Wallet.csproj" -c Release -o /app/publish
#RUN dotnet publish "EDA.Core/EDA.Core.csproj" -c Release -o /app/publish

FROM base AS release
WORKDIR /app
COPY --from=publish /app/publish .

EXPOSE 80
ENTRYPOINT ["dotnet", "EDA.Wallet.dll"]