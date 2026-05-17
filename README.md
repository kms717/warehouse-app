# WarehouseApp — Система управления складом и продажами

> Курсовой проект по дисциплине «Кроссплатформенная среда исполнения ПО»  
> 👨‍🎓 Автор: Юдайчев Виталий Семенович, группа ББСО-01-24  
> 📅 Год: 2025  

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet)](https://dotnet.microsoft.com/)
[![Blazor](https://img.shields.io/badge/Blazor-Server-512BD4)](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor)
[![EF Core](https://img.shields.io/badge/EF%20Core-8.0-512BD4)](https://docs.microsoft.com/ef/core/)
[![Docker](https://img.shields.io/badge/Docker-✓-2496ED?logo=docker)](https://www.docker.com/)
[![License](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)

---

## Быстрый старт

### Требования
- .NET 8.0 SDK ([скачать](https://dotnet.microsoft.com/download))
- Visual Studio 2022 или VS Code
- Docker Desktop (опционально, для контейнеризации)
- Git

### Запуск локально

```bash
# 1. Клонировать репозиторий
git clone https://github.com/YOUR_USERNAME/warehouse-app.git
cd warehouse-app

# 2. Восстановить зависимости
dotnet restore

# 3. Применить миграции (создаст БД)
dotnet ef database update --project src/WarehouseApp

# 4. Запустить приложение
dotnet run --project src/WarehouseApp