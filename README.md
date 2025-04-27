# TableTap

**Digital Menu SaaS for Restaurants & Cafés**  
A responsive, Bootstrap-powered ASP.NET Core MVC application with Identity, QR-code access, flexible subscription management, and full bilingual support (Arabic & English) via resource files.

---

## 🚀 Project Overview

TableTap is a multi-tenant platform that empowers restaurants and cafés to publish, organize, and update their digital menus instantly via unique QR codes. Venue owners manage their menus, subscription plans, and venue profiles while admins oversee cities, subscription lifecycles, user roles, and localization settings.

> **Note:** All plans and subscriptions are fully configurable by the admin — no fixed trial/monthly/yearly system.

> **Note:** Site languages are limited to Arabic and English only — owners cannot add additional languages.

---

## ✨ Key Features

- **Multi-Tenant**: Support for restaurants **and** cafés in one platform
- **User Roles**:  
  - **Admin**: Manage cities, plans, venues, subscriptions, and monitor users
  - **Venue Owner**: Full CRUD on menus, categories, items, venue profiles
- **Subscription Plans**:  
  - Admin-defined (Custom duration, price, theme count)  
  - No built-in payment integration (manual management)
- **Digital Menus**:  
  - Multiple menus per venue (e.g. "Breakfast", "Dinner")  
  - Categories (Starters, Mains, Desserts, etc.)  
  - Items with name, description, image, price, display order
- **QR Code Access**:  
  - Permanent QR code per venue  
  - Direct scan to view menu without login
- **Responsive UI**:  
  - Built with **Bootstrap 5** for mobile-first design  
  - Fully adaptive across phones, tablets, desktops
- **Localization**:  
  - Resource-based support for **Arabic** and **English**  
  - Static bilingual system without user-added languages
- **Scalable Architecture**:  
  - Repository & Service patterns  
  - EF Core with SQL Server (or Azure SQL)  
  - Ready for Docker and cloud hosting (optional)

---

## 🛠 Tech Stack

| Layer               | Technology                                  |
|---------------------|---------------------------------------------|
| Framework           | ASP.NET Core MVC (.NET 8)                   |
| Authentication      | ASP.NET Core Identity (Cookie)              |
| Data Access         | Entity Framework Core, SQL Server           |
| UI                  | Bootstrap 5, Razor Views, Tag Helpers       |
| QR Generation       | QRCoder (.NET Library)                      |
| Localization        | .resx Resource Files (Arabic & English)     |
| Dependency Injection| Built-in DI container                       |

---

## 🔧 Getting Started

1. **Clone the repo**  
   ```bash
   git clone https://github.com/Zaki-Malla/TableTap.git
   cd TableTap
   ```

2. **Configure connection**  
   - Edit `appsettings.json` → set your SQL Server connection string.

3. **Apply Migrations**  
   ```bash
   dotnet ef database update
   ```

4. **Seed Data (optional)**  
   - Seed default cities, plans, roles, and supported cultures in `Program.cs`.

5. **Run the App**  
   ```bash
   dotnet run
   ```
   Navigate to `https://localhost:5001`

---

## 🎨 UI & Responsive Design

- **Layout**: `_Layout.cshtml` uses Bootstrap 5 grid and navbar.
- **Forms & Tables**: Styled with `.form-control`, `.table`, and responsive classes.
- **Cards & Modals**: Display menus and details in mobile-friendly cards.

---

## 🌐 Localization

- Resource (.resx) files manage text for Arabic and English.
- Language switcher in UI toggles between cultures at runtime.

---

## 📄 License

See **[Custom License](LICENSE.txt)** for details on usage restrictions and permissions.

