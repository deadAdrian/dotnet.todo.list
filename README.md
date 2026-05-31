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

---

## 📖 API Documentation

When running the project in development mode, Swagger UI is available at:

```
http://localhost:<port>/swagger/index.html
```