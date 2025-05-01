# Build aşaması
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Proje dosyalarını kopyala ve derle
COPY . ./
WORKDIR /app/TodoApp.API
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Runtime aşaması
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/TodoApp.API/out ./
ENV ASPNETCORE_URLS=http://+:10000
EXPOSE 10000
ENTRYPOINT ["dotnet", "TodoApp.API.dll"]
