module CRUD.Domain.Address.Repository
open System
open CRUD.Domain.Address
open Microsoft.Extensions.DependencyInjection
open System.Collections

let listCities (inMemory: Hashtable) : City[] =
  inMemory |> Seq.cast |> Array.ofSeq

let findCityById (inMemory: Hashtable) (id: Guid): City =
  inMemory.[id] :?> City

type IServiceCollection with
  member this.AddCityRepository(inMemory: Hashtable) =
    this.AddSingleton<CityFindById>(findCityById inMemory) |> ignore
    this.AddSingleton<CityList>(listCities inMemory) |> ignore