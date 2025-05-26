# Используем официальный SDK для сборки
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Копируем csproj и восстанавливаем зависимости
COPY *.csproj ./
RUN dotnet restore

# Копируем все остальные файлы и публикуем релиз
COPY . ./
RUN dotnet publish -c Release -o out

# Финальный runtime-образ
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out ./

# Порт, который слушает приложение
EXPOSE 8080

# Запускаем приложение
ENTRYPOINT ["dotnet", "WebApplication1.dll"]
