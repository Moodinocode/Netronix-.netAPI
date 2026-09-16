# Netronix API

An e-commerce REST API for an electronics store, built with ASP.NET Core 8 and Entity Framework Core. It covers a product catalogue with configurable variants, inventory, tagging, guest and customer orders, and JWT-secured admin operations.

## Background

Netronix started as a group university project with a different backend. After taking an ASP.NET Core course, I rebuilt the backend from scratch in .NET on my own to learn how the stack works in a non-trivial domain — one with real relational complexity rather than a toy CRUD example. This repository is that solo rewrite; all the code here is mine.

## Features

- **Product variants** — products carry variants (e.g. storage, colour), each with options that apply their own price adjustment. Order items capture the exact options chosen and the price at the time of purchase, so historical orders stay accurate when a product later changes.
- **Guest and customer orders** — orders can be placed with or without a user account, tracked via an `IsGuestOrder` flag.
- **Tagging** — many-to-many product tagging, with lookup of products by tag.
- **Best sellers** endpoint derived from order data.
- **JWT authentication** using ASP.NET Core Identity, with `Admin` and `Ops` roles gating all write operations.
- **Repository pattern** — controllers depend on interfaces (`IProductRepository`, `IOrderRepository`, `ITagRepository`, `ITokenRepository`), keeping EF Core out of the controllers.
- **DTOs with AutoMapper** so domain entities are never exposed directly.
- **Swagger UI** wired up with JWT bearer auth for testing protected endpoints.

## Tech stack

- ASP.NET Core 8 (Web API)
- Entity Framework Core 9 + SQL Server
- ASP.NET Core Identity
- AutoMapper
- Swashbuckle / Swagger

## Architecture

Two `DbContext`s keep concerns separate:

- `NetronixDbContext` — catalogue and order data (products, variants, inventory, orders, tags, customers, addresses)
- `NetronixAuthDbContext` — Identity data (users, roles)

Request flow: **Controller → Repository (interface) → EF Core → SQL Server**, with AutoMapper translating between DTOs and domain models at the controller boundary.

### Domain model

```
Product ──< ProductVariant ──< VariantOption
   │
   ├──< ProductTags >── Tag
   └──< InventoryItem

Order ──< OrderItem ──< SelectedVariantOption
  │
  ├── Customer (optional — guest orders allowed)
  └── Adress (shipping)
```

## Endpoints

### Auth
| Method | Route | Description |
|---|---|---|
| POST | `/api/auth/register` | Register a new user |
| POST | `/api/auth/login` | Log in and receive a JWT |

### Products
| Method | Route | Role | Description |
|---|---|---|---|
| GET | `/api/product` | — | List all products |
| GET | `/api/product/bestSellers` | — | Best-selling products |
| GET | `/api/product/tag/{tagId}` | — | Products carrying a given tag |
| GET | `/api/product/{id}` | — | Single product with variants |
| POST | `/api/product` | Admin, Ops | Create a product |
| PUT | `/api/product/{id}` | Admin, Ops | Update a product |
| DELETE | `/api/product/{id}` | Admin, Ops | Delete a product |

### Orders
| Method | Route | Role | Description |
|---|---|---|---|
| POST | `/api/order` | — | Create an order (pass `?Userid=` for a customer order, omit for guest) |
| GET | `/api/order` | Admin, Ops | List all orders |
| GET | `/api/order/{id}` | — | Single order |
| GET | `/api/order/user/{userId}` | — | Orders belonging to a user |
| PUT | `/api/order/{id}` | Admin, Ops | Update an order |
| DELETE | `/api/order/{id}` | Admin, Ops | Delete an order |

### Tags
| Method | Route | Role |
|---|---|---|
| GET | `/api/tags` | — |
| POST | `/api/tags` | Admin, Ops |
| PUT | `/api/tags/{id}` | Admin, Ops |
| DELETE | `/api/tags/{id}` | Admin, Ops |

## Getting started

### Prerequisites
- .NET 8 SDK or later
- SQL Server (LocalDB or a full instance)

### Setup

1. Clone the repository and open `Netronix.sln`.

2. In `Netronix.API/appsettings.json`, replace `YOUR_SERVER` in both connection strings with your SQL Server instance.

3. Supply a JWT signing key. It is deliberately blank in `appsettings.json` so it is never committed — use user-secrets instead:

   ```bash
   cd Netronix.API
   dotnet user-secrets init
   dotnet user-secrets set "Jwt:Key" "a-key-at-least-32-characters-long"
   ```

4. Apply the migrations for both contexts:

   ```bash
   dotnet ef database update --context NetronixDbContext
   dotnet ef database update --context NetronixAuthDbContext
   ```

5. Run it:

   ```bash
   dotnet run
   ```

   Swagger UI is at `https://localhost:7219/swagger` in development.

### Using protected endpoints

Register a user, log in to obtain a token, then click **Authorize** in Swagger and paste it. Role-gated endpoints additionally require the user to hold the `Admin` or `Ops` role in the auth database.

## Known limitations

- Cart handling is done client-side; orders are submitted complete rather than built up server-side.
- `UpdateOrder` replaces order items wholesale and does not recalculate the subtotal.
- No automated tests.
