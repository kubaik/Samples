module Todos.TodoRepository

open Todos
open Microsoft.Extensions.DependencyInjection
open System.Collections

let find (inMemory: Hashtable) (criteria: TodoCriteria): Todo [] =
  match criteria with
  | All -> inMemory.Values |> Seq.cast |> Array.ofSeq
 
let delete (inMemory: Hashtable) (id: string): bool =
  let obj = inMemory.[id]
  match obj with
    | null -> false
    | _ ->
      inMemory.Remove(id)
      true    

let save (inMemory: Hashtable) (todo: Todo): Todo =  
  delete inMemory todo.Id |> ignore
  inMemory.Add(todo.Id, todo) |> ignore
  todo

type IServiceCollection with
  member this.AddTodoRepository(inMemory: Hashtable) =
    this.AddSingleton<TodoFind>(find inMemory) |> ignore
    this.AddSingleton<TodoSave>(save inMemory) |> ignore
    this.AddSingleton<TodoDelete>(delete inMemory) |> ignore
