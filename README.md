# Task Management System

##  Project Overview
Task Management System is a web-based application developed using ASP.NET MVC and ADO.NET.
The application helps users to create, track, update, and manage tasks efficiently with due dates, status, and remarks.

This project is designed to demonstrate real-world CRUD operations, database interaction using ADO.NET, and clean MVC architecture.

---

##  Features
- Create new tasks
- Update task details
- Delete tasks
- Track task status (Pending / In Progress / Completed)
- Add remarks and due dates
- Audit information (CreatedOn, Last UpdatedOn, CreatedBy, Last UpdatedBy)

---

##  Tech Stack
- ASP.NET MVC (.NET Framework)
- ADO.NET
- SQL Server
- HTML
- CSS
- Bootstrap

---

##  Project Architecture
- **Controllers**: Handle user requests and business flow
- **Models**: Represent database entities
- **Views**: UI using Razor and Bootstrap
- **ADO.NET**: Used for database operations (SqlConnection, SqlCommand, SqlDataAdapter)

---

##  Database Structure

### Tasks Table
| Column Name      | Data Type         | Description |
|----------------|------------------|-------------|
| TaskId         | INT (PK, Identity) | Unique Task ID |
| TaskTitle      | NVARCHAR(200)     | Task Title |
| TaskDescription| NVARCHAR(MAX)     | Task Details |
| TaskDueDate    | DATE              | Due Date |
| TaskStatus     | NVARCHAR(50)      | Task Status |
| TaskRemarks    | NVARCHAR(500)     | Remarks |
| CreatedOn      | DATETIME          | Created Date |
| LastUpdatedOn  | DATETIME          | Updated Date |
| CreatedBy      | INT               | Created By User |
| LastUpdatedBy  | INT               | Updated By User |

---

## 🧾 SQL Script
Complete SQL script is available in the **Database** folder:


---

## ▶ How to Run the Project
1. Clone the repository
2. Open the project in Visual Studio
3. Restore packages
4. Update the SQL Server connection string in `Web.config`
5. Execute the SQL script to create the database
6. Run the project using IIS Express

---

## 🔐 Notes
- Connection string credentials are not included for security reasons
- This project is created for learning and interview demonstration purposes

---

## Developer
**Danish Khan**  
BCA Student | .NET Developer (1 Year Experience)

