# Data Access Layer with Dapper - SOLID & Clean Code

This repository implements a data access layer for a scalable and maintainable application using **Dapper** as the ORM. The code follows **SOLID principles** and **Clean Code practices** to ensure high code quality, flexibility, and ease of maintenance. It uses the **Repository Pattern** for efficient data management and separation of concerns.

## Features

- **Dapper ORM**: Lightweight and efficient object-relational mapper (ORM) for interacting with the database.
- **SOLID Principles**: Follows the five SOLID principles for clean, maintainable, and testable code.
- **Repository Pattern**: Encapsulates data access logic and abstracts it from business logic, making the application more modular.
- **Clean Code**: Ensures code readability, simplicity, and ease of understanding.
- **Separation of Concerns**: Keeps business logic, data access, and presentation layers separate for better maintainability.
- **Scalability**: Designed for easy extension as the application grows.

## Architecture

### SOLID Principles Applied

- **Single Responsibility Principle (SRP)**: Each class in the repository has one responsibility, such as handling data access or mapping entities.
- **Open/Closed Principle (OCP)**: The system is open for extension but closed for modification. You can add new functionality without modifying existing code.
- **Liskov Substitution Principle (LSP)**: Derived classes can be substituted for their base classes without altering the correctness of the program.
- **Interface Segregation Principle (ISP)**: Interfaces are split into smaller, more specific interfaces that are easier to implement and understand.
- **Dependency Inversion Principle (DIP)**: High-level modules do not depend on low-level modules but on abstractions. The repository layer is abstracted from concrete implementations.

### Clean Code Principles

- **Meaningful Names**: Variables, classes, and methods are named descriptively to convey the purpose of the code.
- **Small Functions/Methods**: Each function does one thing and does it well. Functions are kept small and concise.
- **Avoiding Duplication**: Code duplication is minimized, and reusable components are abstracted.
- **Commenting & Documentation**: Comments are used where necessary to explain complex logic or intentions. However, code is written clearly enough to reduce unnecessary comments.
- **Error Handling**: Proper error handling mechanisms are in place to ensure the application runs smoothly and errors are logged appropriately.

### Repository Pattern

The **Repository Pattern** is used to provide an abstraction layer between the application's business logic and data access logic. It simplifies interactions with the database and allows easier testing and maintenance.
