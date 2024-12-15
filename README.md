# Steve Lang's Todo App

This app is composed of an ASP.NET Core (.NET 8) back end, and an Angular 19 front end.

The objective of this very simple app is to showcase clean architecture principles.

The aim of clean architecture is to decouple the application's core logic from the services it uses. This is achieved by having the dependencies flow from infrastructure to services and from services to the domain. The domain is thus isolated from services and infrastructure; infrastructure can even be swapped out, with no impact to services and the domain.

## Class library structure

The ASP.NET Core app class libraries are organized as follows:

- Domain layer:
  - Domain
  - Contracts
- Service layer:
  - Services
  - Services.Interfaces
- Infrastructure layer:
  - Persistence

## Dependency flow
  
We can easily check the dependency flow by looking at the dependencies of each class library.

- Domain layer:
  - Domain and Contracts don't have any dependencies.
- Service layer:
  - Services --> Domain, Services.Interfaces.
  - Services.Interfaces --> Contracts
- Infrastructure layer:
  - Persistence --> Domain

## Getting it up and running

In a Windows Command Prompt:

```
cd path\to\SteveLang.TodoApp\Web
dotnet run
```

In another Windows Command Prompt:

```
cd path\to\steve-lang-todo-app
npm install
npx ng serve
```

In a browser, navigate to http://localhost:4200
