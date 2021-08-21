FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["BoxTI.Challenge.CovidTracking.WebApi/BoxTI.Challenge.CovidTracking.WebApi.csproj", "BoxTI.Challenge.CovidTracking.WebApi/"]
RUN dotnet restore "BoxTI.Challenge.CovidTracking.WebApi/BoxTI.Challenge.CovidTracking.WebApi.csproj"
COPY . .
WORKDIR "/src/BoxTI.Challenge.CovidTracking.WebApi"
RUN dotnet build "BoxTI.Challenge.CovidTracking.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BoxTI.Challenge.CovidTracking.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BoxTI.Challenge.CovidTracking.WebApi.dll"]
