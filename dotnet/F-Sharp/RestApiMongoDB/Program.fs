open System
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.DependencyInjection
open Giraffe
open MongoDB.Driver
open Todos
open Todos.Http
open Todos.TodoMongoDB

let routes =
  choose [
    TodoHttp.handlers
  ]

let configureApp (app : IApplicationBuilder) =
  app.UseGiraffe routes

let configureServices (services : IServiceCollection) =  
  services.AddGiraffe() |> ignore  
  //services.AddTodoInMemory(Hashtable()) |> ignore
    
//  let mongo = MongoClient "mongodb://localhost:27017/"
  let mongo = MongoClient (Environment.GetEnvironmentVariable "Mongo.Url")
  let db = mongo.GetDatabase "Sample-FSharp-RestApi"
  services.AddTodoMongoDB(db.GetCollection<Todo>("todos")) |> ignore
    

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