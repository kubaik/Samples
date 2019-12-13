module CRUD.Domain.Person.Repository
open System
open System.Collections
open Microsoft.Extensions.DependencyInjection
open CRUD.Domain.Person

let list (inMemory: Hashtable): Person [] =
  inMemory |> Seq.cast |> Array.ofSeq

let delete (inMemory: Hashtable) (id: Guid) =
  let obj = inMemory.[id]
  match obj with
    | null -> false
    | _ ->
      inMemory.Remove(id)
      true

let save (inMemory: Hashtable) (data: Person) =
  delete inMemory data.Id |> ignore
  inMemory.Add(data.Id, data) |> ignore
  data

type IServiceCollection with
  member this.AddPersonRepository(inMemory: Hashtable) =
    this.AddSingleton<PersonList>(list inMemory) |> ignore
    this.AddSingleton<PersonDelete>(delete inMemory) |> ignore
    this.AddSingleton<PersonSave>(save inMemory) |> ignore