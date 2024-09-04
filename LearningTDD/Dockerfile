# Use a imagem base do ASP.NET Core 8.0
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Use a imagem do SDK do .NET 8.0 para o build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy only the .csproj files and restore as distinct layers
COPY ["LearningTDD.API/LearningTDD.API.csproj", "LearningTDD.API/"]
COPY ["LearningTDD.IOC/LearningTDD.IOC.csproj", "LearningTDD.IOC/"]
COPY ["LearningTDD.InfraData/LearningTDD.InfraData.csproj", "LearningTDD.InfraData/"]
COPY ["LearningTDD.Domain/LearningTDD.Domain.csproj", "LearningTDD.Domain/"]

RUN dotnet restore "LearningTDD.API/LearningTDD.API.csproj" --verbosity detailed

# Copy the remaining source code
COPY . .
WORKDIR "/src/LearningTDD.API"
RUN dotnet build "LearningTDD.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LearningTDD.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LearningTDD.API.dll"]
