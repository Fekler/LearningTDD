# Use a imagem base do ASP.NET Core 8.0
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Use a imagem do SDK do .NET 8.0 para o build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["LearningTDD/LearningTDD.csproj", "LearningTDD/"]
RUN dotnet restore "./LearningTDD/LearningTDD.csproj"
COPY . .
WORKDIR "/src/LearningTDD"
RUN dotnet build "LearningTDD.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LearningTDD.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LearningTDD.dll"]
