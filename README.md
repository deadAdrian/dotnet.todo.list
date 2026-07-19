# 📝 Todo API (.NET 9)

## 📌 Project Overview

This is an **ASP.NET Core Web API** built with C# and .NET 9 for managing a Todo List application. The project demonstrates RESTful CRUD operations, layered architecture, Data Transfer Objects (DTOs), Entity Framework Core with PostgreSQL, CORS integration, and Docker containerization.

It serves as the backend service for the **Pixel Todo List Frontend** web application.

---

## ⚙️ Technologies Used

- **Framework**: ASP.NET Core Web API (.NET 9)
- **Database**: PostgreSQL 16 + Entity Framework Core (Migrations)
- **Documentation**: Swagger / OpenAPI UI
- **Containerization**: Docker & Docker Compose
- **Language**: C# 13

---

## 🚀 Running in Conjunction with the Frontend

To run this API together with the **React / TanStack Start Frontend**:

### 1. Start the API & Database (Backend)

#### Option A: Running with Docker Compose (Recommended)

```bash
# Start PostgreSQL database and ASP.NET Core API
docker compose up -d --build
```

- API Base URL: `http://localhost:8080/api`
- Swagger UI: **[http://localhost:8080/swagger](http://localhost:8080/swagger)**

#### Option B: Running Locally with .NET SDK

1. Ensure a PostgreSQL instance is running locally or via Docker:
   ```bash
   docker run -d --name todo-postgres -p 5432:5432 -e POSTGRES_DB=TodoListDb -e POSTGRES_USER=postgres -e POSTGRES_PASSWORD=@Admin123 postgres:16-alpine
   ```
2. Run the API:
   ```bash
   dotnet run
   ```
- Local URL: `http://localhost:5143/api`
- Swagger UI: `http://localhost:5143/swagger`

---

### 2. Start the Frontend Web App

1. Navigate to the frontend directory (`../todo-list`):
   ```bash
   cd ../todo-list
   ```
2. Configure `.env` file:
   ```env
   VITE_API_BASE_URL=http://localhost:8080/api
   ```
3. Start the dev server:
   ```bash
   npm install
   npm run dev
   ```
4. Access the web app at **[http://localhost:3000](http://localhost:3000)**.

---

## 🌐 CORS Configuration

The API is pre-configured in `Program.cs` to allow requests from the React frontend running on `http://localhost:3000`:

```csharp
builder.Services.AddCors(options =>
{
   options.AddPolicy("AllowFrontend", policy =>
   {
       policy.WithOrigins("http://localhost:3000")
             .AllowAnyHeader()
             .AllowAnyMethod();
   });
});
```

---

## 📖 API Endpoint Reference

| HTTP Method | Endpoint | Description |
| :--- | :--- | :--- |
| `GET` | `/api/TodoItems` | Retrieve all todo items |
| `GET` | `/api/TodoItems/{id}` | Retrieve a single todo item by ID |
| `POST` | `/api/TodoItems` | Create a new todo item |
| `PUT` | `/api/TodoItems/{id}` | Update an existing todo item |
| `DELETE` | `/api/TodoItems/{id}` | Delete a todo item by ID |

---

## 🧩 Architecture

- **Controllers** → Manage HTTP routes (`/api/TodoItems`)
- **Models** → Entity Framework Core database entities
- **DTOs** → API request/response contracts (`CreateTodoDto`, `UpdateTodoDto`, `TodoItemDto`)
- **Services** → Mapping logic (`MappingService`)
- **Data** → `TodoContext` for PostgreSQL access and migrations