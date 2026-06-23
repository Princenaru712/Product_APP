# Product_APP 🚀

A professional, enterprise-grade web application built using **Clean Architecture** patterns, **.NET 8/9**, and modern backend development practices. The project is fully containerized using **Docker** and orchestrates multiple microservices/containers seamlessly.

---

## 🏗️ Architecture Overview

The project is structured following **Clean Architecture** principles to ensure high maintainability, testability, and decoupling of concerns:

*   **`src/API_`**: The presentation layer. Contains API Controllers (`v1/AuthController`, `v1/ProductsController`), Custom Middlewares (e.g., `ExceptionHandlingMiddleware`), and configuration settings.
*   **`src/Application`**: The core business logic layer. Implements business rules, DTOs (`ProductDtos`, `LoginModel`), services (`ProductService`), interfaces, and validators.
*   **`src/Domain`**: The enterprise core layer. Contains database entities (`Product`, `Item`) and pure domain models completely independent of external libraries.
*   **`src/Infrastructure`**: The data access and external integration layer. Houses the Entity Framework Core `ApplicationDbContext`, SQL Server repositories, and configuration for data persistence.

---

## 🛠️ Tech Stack & Features

*   **Backend Framework**: .NET C# Core with Clean Architecture
*   **API Standards**: RESTful API endpoints with versioning (`v1`)
*   **Database Management**: EF Core with highly optimized SQL Server integration
*   **Containerization**: Full Docker support with multi-container orchestration via Docker Compose
*   **Security & Auth**: Built-in Authentication endpoints (`AuthController`)
*   **Error Handling**: Global exception handling through custom middleware architecture

---

## 🚀 Getting Started

### Prerequisites
Make sure you have the following installed on your machine:
*   [.NET SDK](https://dotnet.microsoft.com/download) (Latest Version)
*   [Docker Desktop](https://www.docker.com/products/docker-desktop/)
*   [Visual Studio 2022](https://visualstudio.microsoft.com/) / VS Code

### Running with Docker Compose
To orchestrate and spin up the complete application stack (API and database containers), run the following command from the root directory:

```bash
docker-compose up --build

Product_APP/
├── src/
│   ├── API_/                   # Presentation Layer (Controllers, Middlewares)
│   ├── Application/            # Business Logic Layer (Services, DTOs)
│   ├── Domain/                 # Enterprise Core Layer (Entities)
│   └── Infrastructure/         # External Concerns Layer (Data, DbContext)
├── .dockerignore               # Docker ignore definitions
├── .gitignore                  # Standard Git ignore configurations
├── docker-compose.dcproj       # Visual Studio Docker Project
├── docker-compose.yml          # Core Multi-Container Orchestration
└── Product_APP.sln             # Main Visual Studio Solution File

---

## 🔒 Authentication & API Testing

The application includes built-in security features via the `AuthController`. To test the authenticated endpoints or obtain a token, use the following default administrative credentials:

*   **API Endpoint**: `POST /api/v1/auth/login`
*   **Default Username**: `admin`
*   **Default Password**: `Admin@123`

### Example Request Body (JSON)
```json
{
  "username": "admin",
  "password": "Admin@123"
}



