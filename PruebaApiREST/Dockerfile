FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5000

ENV ASPNETCORE_URLS=http://*:5000

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PruebaApiREST/PruebaApiREST.csproj", "PruebaApiREST/"]
RUN dotnet restore "PruebaApiREST\PruebaApiREST.csproj"
COPY . .
WORKDIR "/src/PruebaApiREST"
RUN dotnet build "PruebaApiREST.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PruebaApiREST.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final 
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PruebaApiREST.dll"]
