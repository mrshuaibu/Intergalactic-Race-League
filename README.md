# Intergalactic Race League

Welcome to the Intergalactic Race League (IRL), a futuristic ASP.NET Core MVC
project designed to manage and simulate high-stakes races across planets, moons, 
and galaxies. This application provides an administrative and user-facing platform 
for managing racers, teams, tracks, and race events.

## 🚀 Project Overview

The IRL system allows users to:
- Register racers and assign them to teams
- Create and manage interplanetary race tracks
- Schedule races and track results
- View leaderboards and statistics

This is **project**, focused primarily on setting up:
- A clean database schema using Entity Framework Core
- Proper entity relationships with constraints
- User authentication and role management using Identity


## 🔧 Technologies Used

- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- ASP.NET Core Identity
- Bootstrap (for styling)

## 🔐 Authentication & Roles

The project uses ASP.NET Core Identity with predefined roles:
- **Admin**: Full control over all resources
- **User**: View-only access to race information and leaderboards

## 🛠️ Getting Started

### Prerequisites
- Visual Studio 2022 or newer
- .NET 6.0 SDK or higher
- SQL Server

### Setup Instructions

1. **Clone the repository**
   ```bash
   git clone https://github.com/your-username/intergalactic-race-league.git

2. **Update the database connection string in appsettings.json:**
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=IRL_DB;Trusted_Connection=True;"
}
3. **Apply migrations**
    Add-migration
    update-database
4. **Run the Application**


