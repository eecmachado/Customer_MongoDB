FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Store.Host/Store.Host.csproj", "Store.Host/"]
RUN dotnet restore "src/Store.Host/Store.Host.csproj"
COPY . .
WORKDIR "/src/Store.Host"
RUN dotnet build "Store.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Store.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Store.Host.dll"]
