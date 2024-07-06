# Techy_MVC

## Description
Techy_MVC is a real-world e-commerce application built using ASP.NET Core MVC and Identity, Entity Framework Core, and .NET 8. The application includes features such as authorization, authentication, roles (Admin, Employee, Customer, and Company), Stripe payment integration, Facebook login, and a delivery system.

## Installation Instructions
To set up the project, follow these steps:

1. Ensure you have Visual Studio 2022 installed.
2. Make sure your computer has an SQL Server installed.
3. Clone the repository to your local machine.
4. Open the project in Visual Studio 2022.
5. Install the following packages:
    ```xml
    <PackageReference Include="Microsoft.AspNetCore.Authentication.Facebook" Version="8.0.6" />
    <PackageReference Include="Microsoft.AspNetCore.Identity.UI" Version="8.0.6" />
    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="8.0.6" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="8.0.6" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="8.0.6" />
    <PackageReference Include="Microsoft.AspNetCore.Identity.EntityFrameworkCore" Version="8.0.6" />
    ```

6. Update the `appsettings.json` file with your SQL Server connection string. Ensure you include `TrustServerCertificate=True` in the connection string.
    ```json
    "ConnectionStrings": {
        "DefaultConnection": "Server=your_server_name;Database=your_database_name;Trusted_Connection=True;TrustServerCertificate=True;"
    }
    ```

## Usage Instructions
1. Run the application from Visual Studio 2022.
2. Navigate to the application in your web browser.
3. Use the provided roles and features for various user interactions, including admin tasks, employee management, customer shopping, and company operations.
4. Utilize Stripe payment and Facebook login features as needed.

## Features
- **Authorization and Authentication**
- **Role Management**: Admin, Employee, Customer, Company
- **Stripe Payment Integration**
- **Facebook Login**
- **Delivery System**

## Contact Information
For questions or support, please contact timapatrik27@gmail.com
