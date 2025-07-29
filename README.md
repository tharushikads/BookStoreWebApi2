BookStoreWebAPI2

An online bookstore RESTful API built with .NET, allowing customers to browse and purchase books, place orders, and make payments seamlessly.

---

-Features-

- CRUD operations for:
  * Books
  * Categories
  * Customers
  * Orders
  * Payments
-Authentication with JWT
- Entity Framework Core + SQLite integration
- Swagger UI for API testing
- Layered architecture (Controllers, Services, Repositories)

---

-Technologies Used-

- [.NET 9](https://dotnet.microsoft.com/)
- Entity Framework Core
- ASP.NET Core Identity
- SQLite
- JWT Authentication
- Swagger / Swashbuckle

---

Getting Started

-Prerequisites-

- [.NET SDK 9.0](https://dotnet.microsoft.com/)
- SQLite installed (optional; used via EF)

-Running the Application-

```bash
dotnet restore
dotnet ef database update   # Apply migrations
dotnet run
```

Navigate to: `http://localhost:5064/swagger/index.html` to explore the API using Swagger UI.

---

-API Endpoints-

* Book

| Method | Endpoint         | Description          |
|--------|------------------|----------------------|
| GET    | /api/Book        | Get all books        |
| POST   | /api/Book        | Add a book           |
| GET    | /api/Book/{id}   | Get book by ID       |
| PUT    | /api/Book/{id}   | Update book          |
| DELETE | /api/Book/{id}   | Delete book          |

* Category

| Method | Endpoint             | Description          |
|--------|----------------------|----------------------|
| GET    | /api/Category        | Get all books        |
| POST   | /api/Category        | Add a book           |
| GET    | /api/Category/{id}   | Get book by ID       |
| PUT    | /api/Category/{id}   | Update book          |
| DELETE | /api/Category/{id}   | Delete book          |


* Customer

| Method | Endpoint             | Description          |
|--------|----------------------|----------------------|
| GET    | /api/Customers       |Get all customers     |
| POST   | /api/Customers       |Create a new customer |
| GET    | /api/Customers/{id}  |Get customer by ID    |
| PUT    | /api/Customers/{id}  |Update a customer     |
| DELETE | /api/Customers/{id}  |Delete a customer     |

* Order  

| Method | Endpoint         | Description         |
|--------|------------------|---------------------|
| GET    | /api/Order       | Get all orders      |
| POST   | /api/Order       | Create a new order  |
| GET    | /api/Order/{id}  | Get order by ID     |
| PUT    | /api/Order/{id}  | Update an order     |
| DELETE | /api/Order/{id}  | Delete an order     |




* Payment

| Method | Endpoint          | Description          |
|--------|-------------------|----------------------|
| GET    | /api/Payment      | Get all payments     |
| POST   | /api/Payment      | Create a payment     |
| GET    | /api/Payment/{id} | Get payment by ID    |
| PUT    | /api/Payment/{id} | Update a payment     |
| DELETE | /api/Payment/{id} | Delete a payment     |


-Author

Tharushika De Silva
 [desilva16tharushika@gmail.com](mailto:desilva16tharushika@gmail.com)  
 [GitHub Profile](https://github.com/tharushikadesilva)

---

