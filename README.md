# 📝 Todo API (.NET 9)

## 📌 Project Overview

This is a simple **ASP.NET Core Web API** built with C# for managing a Todo List application. The project demonstrates basic CRUD operations, layered architecture concepts, and the use of Data Transfer Objects (DTOs) to separate API contracts from database models.

The API allows users to create, retrieve, update, and delete todo items, as well as mark tasks as completed.

---

## ⚙️ Technologies Used

- ASP.NET Core Web API (.NET 9)
- Entity Framework Core (In-Memory Database)
- C#
- Swagger / OpenAPI for API documentation
- Docker & Docker Compose for containerization

---

## 🧩 Architecture

The project follows a clean separation of concerns:

- **Controllers** → Handle HTTP requests and responses  
- **Models** → Represent database entities  
- **DTOs** → Define request and response contracts  
- **Services** → Handle mapping between models and DTOs  
- **Data Layer** → Manages database context using Entity Framework Core  

---

## 🚀 Features

- Create new todo items  
- Retrieve all or individual todos  
- Update todo details or completion status  
- Delete todo items  
- Swagger UI for API testing  
- Dockerized execution support  

---

## 🏃 Getting Started

### Option 1: Running with Docker Compose (Recommended)

1. Start the application container:
   ```bash
   docker compose up -d --build
   ```
2. Access Swagger UI: **[http://localhost:8080/swagger](http://localhost:8080/swagger)**
3. Stop the container:
   ```bash
   docker compose down
   ```

---

### Option 2: Running with Docker CLI

1. Build the Docker image:
   ```bash
   docker build -t todo-api .
   ```
2. Run the container:
   ```bash
   docker run -d -p 8080:8080 --name todo-app todo-api
   ```
3. Access Swagger UI: **[http://localhost:8080/swagger](http://localhost:8080/swagger)**

---

### Option 3: Running Locally (.NET SDK)

1. Ensure .NET 9 SDK is installed.
2. Run the project:
   ```bash
   dotnet run
   ```
3. Access Swagger UI: **[http://localhost:5143/swagger](http://localhost:5143/swagger)**

---

## 📖 API Documentation

When running the application, Swagger UI is available at:

- **Docker Environment**: `http://localhost:8080/swagger`
- **Local Environment**: `http://localhost:5143/swagger`