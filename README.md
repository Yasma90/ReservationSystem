# Reservation System

Reservation System development with ASP .Net 5 Web Application (backend) and Angular 13 (front-end)

To get more details or test go the API documentation `/swagger` 

## Pre-requisites 
            
* Target framework: .Net Core 5 
* EF Core version: 5.0.14
* IDE: Visula Studio 2019
* Database provider: Microsoft.EntityFrameworkCore.SqlServer
* Angular Cli 13.0.4
* npm 8.4.1
* node 16.3.0


## Solution Structure

* ReservationSystem.Application -> backend and front-end, Presentation Layer
* ReservationSystem.Domain -> Domain Layer
* ReservationSystem.Infrastructure -> Dependency Injection, Infrastructure Layer
* ReservationSystem.Persistence ->  Persistence, Data Access Layer


## Setting Api URL into front-end

`---ClientApp/src/enviroments/enviroment|.production|.ts`
`apiUrl: 'https://localhost:5001/api' //'https://localhost:44323/api'`

`dotnet run`

## Further help

`Add Migrations`
dotnet ef migrations add InitialDb --project ReservationSystem.Persistence -s ReservationSystem.Application

`Update Database`
dotnet ef database update --project ReservationSystem.Persistence -s ReservationSystem.Application

`Remove Migrations`
dotnet ef migrations remove --project ReservationSystem.Persistence -s ReservationSystem.Application


## Project status

* UI Don't search by name contact, sorting, paging, internationalization 
