FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["EDA.Balance/EDA.Balance.csproj", "EDA.Balance/"]
COPY ["EDA.Core/EDA.Core.csproj", "EDA.Core/"]
RUN dotnet restore "EDA.Balance/EDA.Balance.csproj"
RUN dotnet restore "EDA.Core/EDA.Core.csproj"
COPY . .
WORKDIR "EDA.Balance"
RUN dotnet build "EDA.Balance.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EDA.Balance.csproj" -c Release -o /app/publish
#RUN dotnet publish "EDA.Core/EDA.Core.csproj" -c Release -o /app/publish

FROM base AS release
WORKDIR /app
COPY --from=publish /app/publish .

EXPOSE 80
ENTRYPOINT ["dotnet", "EDA.Balance.dll"]