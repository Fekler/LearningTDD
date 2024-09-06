# Use a imagem base do ASP.NET Core 8.0
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Use a imagem do SDK do .NET 8.0 para o build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copie apenas os arquivos .csproj e faça restore das dependências
COPY . .
RUN dotnet restore "LearningTDD.API/LearningTDD.API.csproj"

# Copie o restante do código-fonte
COPY . .
WORKDIR "/src/LearningTDD.API"
RUN dotnet build "LearningTDD.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LearningTDD.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Define variáveis de ambiente padrão (podem ser sobrescritas em tempo de execução)
ENV ASPNETCORE_ENVIRONMENT=Development
ENV ConnectionStrings__DefaultConnection=

ENTRYPOINT ["dotnet", "LearningTDD.API.dll"]
