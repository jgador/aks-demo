# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
WORKDIR /app

COPY ["src/AKS.Demo/AKS.Demo.csproj", "AKS.Demo/"]

RUN dotnet restore "AKS.Demo/AKS.Demo.csproj"
COPY . .
WORKDIR "/app/src/AKS.Demo"
RUN dotnet build "AKS.Demo.csproj" --configuration Release --output "/build"

# Stage 2: Publish
RUN dotnet publish "AKS.Demo.csproj" --configuration Release --output "/publish"

# Final stage / image
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine
WORKDIR /app

COPY --from=build "/publish" .

RUN apk update && apk upgrade --available

EXPOSE 80
EXPOSE 443

ENTRYPOINT ["dotnet", "AKS.Demo.dll"]

# docker build
# docker build -t aks.demo --no-cache .

# docker run
# docker run -d -p 8000:80 --name aks.demo --env ASPNETCORE_ENVIRONMENT=Development aks.demo