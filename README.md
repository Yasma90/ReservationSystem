# Reservation System

Reservation System development with ASP .Net 5 Web Application (backend) and Angular 13 (front-end)

To get more details go the API documentation /swagger 

## Solution Structure

* ReservationSystem.Application -> backend and front-end, Presentation Layer
* ReservationSystem.Domain -> Domain Layer
* ReservationSystem.Infrastructure -> Dependency Injection, Infrastructure Layer
* ReservationSystem.Persistence ->  Persistence, Data Access Layer


## Further help

`Add Migrations`
dotnet ef migrations add InitialDb --project ReservationSystem.Persistence -s ReservationSystem.Application

`Update Database`
dotnet ef database update --project ReservationSystem.Persistence -s ReservationSystem.Application

`Remove Migrations`
dotnet ef migrations remove --project ReservationSystem.Persistence -s ReservationSystem.Application


## Project status

* Still UI for Develop
