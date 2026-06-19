FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY src/SchoolShop.Api/SchoolShop.Api.csproj src/SchoolShop.Api/
COPY src/SchoolShop.Application/SchoolShop.Application.csproj src/SchoolShop.Application/
COPY src/SchoolShop.Domain/SchoolShop.Domain.csproj src/SchoolShop.Domain/
COPY src/SchoolShop.Infrastructure/SchoolShop.Infrastructure.csproj src/SchoolShop.Infrastructure/
RUN dotnet restore src/SchoolShop.Api/SchoolShop.Api.csproj

COPY . .
RUN dotnet publish src/SchoolShop.Api/SchoolShop.Api.csproj -c Release -o /app/publish --no-restore /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080
ENTRYPOINT ["dotnet", "SchoolShop.Api.dll"]
