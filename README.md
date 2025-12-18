# ZitroShop API

ZitroShop is a modern, modular e-commerce API built with .NET 9. The project follows a **Modular Monolith** architecture, ensuring clear separation of concerns between different business domains such as Products, Basket, and Payments.

## 🚀 Tech Stack

- **Framework:** .NET 9
- **Database:** SQL Server (EF Core)
- **Caching & Locking:** Redis
- **Message Broker:** RabbitMQ
- **API Documentation:** Scalar (Modern Swagger alternative)
- **Validation:** FluentValidation

## 🏗 Project Structure

The solution is divided into several modules:
- **ZitroShop.Api:** The entry point and API layer.
- **ZitroShop.Modules:** Contains independent business modules:
  - **ProductModule:** Product catalog and management.
  - **BasketModule:** Shopping basket logic using Redis for persistence and locking.
  - **PaymentModule:** Payment processing and status tracking.
- **ZitroShop.Shared:** Shared infrastructure, base classes, and utilities.

## 🛠 Getting Started

### 1. Prerequisites
- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Docker Desktop](https://www.docker.com/products/docker-desktop)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### 2. Infrastructure Setup
Run the following command to start Redis and RabbitMQ containers:
```bash
docker compose up -d
```

### 3. Database Configuration
Update the connection string in `src/ZitroShop.Api/appsettings.Development.json` if your SQL Server instance differs from the default:
```json
"ConnectionStrings": {
  "SvcDbContext": "data source=.;initial catalog=ZitroShopDB;TrustServerCertificate=True;Trusted_Connection=True;"
}
```

Then, apply the migrations to create the database:
```bash
dotnet ef database update --project src/ZitroShop.Modules --startup-project src/ZitroShop.Api
```

### 4. Running the Project
```bash
dotnet run --project src/ZitroShop.Api
```
The API will be available at `http://localhost:5128`.

### 5. API Documentation
Once the app is running, you can explore the interactive API documentation at:
- **Scalar:** `http://localhost:5128/scalar/v1`

---

## 📡 API Examples

### 📦 Products
#### Get All Products
Retrieves a list of all available products.
- **URL:** `/products`
- **Method:** `GET`
- **Example Request:**
```bash
curl -X GET http://localhost:5128/products
```

### 🛒 Basket
#### Add Product to Basket
Adds a specific product to a user's basket.
- **URL:** `/basket/add`
- **Method:** `POST`
- **Payload:**
```json
{
  "userId": 1,
  "productId": 1
}
```
- **Example Request:**
```bash
curl -X POST http://localhost:5128/basket/add \
-H "Content-Type: application/json" \
-d '{"userId": 1, "productId": 1}'
```

### 💳 Payment
#### Start Payment Process
Initiates a payment for the items in the user's basket.
- **URL:** `/payment/start`
- **Method:** `POST`
- **Payload:**
```json
{
  "userId": 1
}
```
- **Example Request:**
```bash
curl -X POST http://localhost:5128/payment/start \
-H "Content-Type: application/json" \
-d '{"userId": 1}'
```

#### Check Payment Status
Retrieves the current status of a payment.
- **URL:** `/payment/{paymentId}`
- **Method:** `GET`
- **Example Request:**
```bash
curl -X GET http://localhost:5128/payment/1
```

---

![zitro-shop Endpoints](zitro-shop-api.png)

## 📜 License
This project is licensed under the [LICENSE](LICENSE) file.

