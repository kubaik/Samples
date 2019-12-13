open System
open System.Collections
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.DependencyInjection
open Giraffe
open Todos.Http
open Todos.TodoRepository
open CRUD.Domain.Address.Repository
open CRUD.Domain.Person.Repository

let routes =
  choose [
    TodoHttp.handlers
  ]

let configureApp (app: IApplicationBuilder) =
  app.UseGiraffe routes

let configureServices (services: IServiceCollection) =
  services.AddGiraffe() |> ignore
  services.AddTodoRepository(Hashtable()) |> ignore
  services.AddCityRepository(Hashtable()) |> ignore
  services.AddPersonRepository(Hashtable()) |> ignore

[<EntryPoint>]
let main _ =
  printfn "F# REST Api with MongoDB"
  
  WebHostBuilder()
    .UseKestrel()
    .Configure(Action<IApplicationBuilder> configureApp)
    .ConfigureServices(configureServices)
    .Build()
    .Run()
  0
