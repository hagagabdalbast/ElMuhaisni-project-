# AlMuhaisni — Real Estate Platform (API)

> Backend for **AlMuhaisni**, a property-management platform featuring interactive listings, dashboards, and search. Built with **ASP.NET Core** in a clean, layered architecture.

![C#](https://img.shields.io/badge/C%23-239120?style=flat&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=flat&logo=dotnet&logoColor=white)
![EF Core](https://img.shields.io/badge/Entity%20Framework%20Core-512BD4?style=flat&logo=dotnet&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=flat&logo=microsoftsqlserver&logoColor=white)

## 🏛️ Architecture

Organized into separated layers for clear separation of concerns:

| Project | Responsibility |
| --- | --- |
| **ElMuhaisni.API** | RESTful Web API — controllers & endpoints |
| **ElMuhaisni.BL** | Business Logic — services, repositories, DTOs |
| **ElMuhaisni.DAL** | Data Access — Entity Framework Core, entities, migrations |

## ✨ Highlights

- 🏢 Property listing & management with interactive search
- 🗺️ Map-ready property data and dashboards
- ⚡ Query optimization via strategic SQL Server indexing & partitioning
- 🧱 Repository + Service Layer patterns with Dependency Injection

## 🛠️ Tech Stack

- **Language:** C#
- **Framework:** ASP.NET Core Web API
- **ORM:** Entity Framework Core
- **Database:** SQL Server

## 🚀 Getting Started

```bash
# 1. Restore dependencies
dotnet restore

# 2. Update the connection string in appsettings.json

# 3. Apply migrations
dotnet ef database update

# 4. Run the API
dotnet run --project ElMuhaisni.API
```

## 📁 Solution Structure

```text
ElMuhaisni.API/   # Web API (controllers, endpoints)
ElMuhaisni.BL/    # Business logic (services, repositories, DTOs)
ElMuhaisni.DAL/   # Data access (EF Core, entities, migrations)
```

---

<p align="center">Built by <a href="https://github.com/hagagabdalbast">Hagag Abdelbaset</a></p>
