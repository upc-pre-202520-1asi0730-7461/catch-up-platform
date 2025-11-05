# Catch-Up Platform (catch-up-platform)

## Overview

Catch-Up Platform is a small ASP.NET Core service that provides an API to manage users' favorite news sources. The project demonstrates a clean package structure separated into bounded contexts (news and shared) and follows simple command/query service patterns with Entity Framework Core persistence.

## Features

- List favorite sources scoped to a News API key
- Retrieve a favorite source by its identifier
- Retrieve a favorite source by News API key + source id
- Create (persist) a new favorite source
- Custom ASP.NET Core route naming convention to use kebab-case for API routes
- Custom Entity Framework naming strategy to convert identifiers to snake_case and plural table names.

## Technologies

- C# 12+ and .NET 9
- ASP.NET Core (REST controllers)
- Entity Framework Core
- PlantUML (architecture diagrams in `docs/`)

## Technical stories

The API-focused technical stories for frontend integration are in [`docs/user-stories.md`](docs/user-stories.md).

## Class diagram

A PlantUML class diagram that reflects the code structure and bounded contexts is available at [`docs/class-diagram.puml`](docs/class-diagram.puml).

## Getting started (quick)

To run the application locally (recommended: macOS / Linux / Windows):

```bash
dotnet run --project CatchUpPlatform.API
```

Or from the API directory:

```bash
cd CatchUpPlatform.API
dotnet run
```

Or build and run the dll:

```bash
dotnet build
dotnet run --project CatchUpPlatform.API
```
