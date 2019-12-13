namespace CRUD.Http
open Giraffe
open Microsoft.AspNetCore.Http
open CRUD.Domain.Address
open FSharp.Control.Tasks.V2
open System

module CityHttp =
  let handlers : HttpFunc -> HttpContext -> HttpFuncResult =
    choose [
      GET >=> route "/cities" >=>
        fun next context ->
          let list = context.GetService<CityList>()
          json list next context

      GET >=> routef "/cities/%s" (fun id ->
        fun next context ->
          let find = context.GetService<CityFindById>()
          json (find (Guid.Parse(id))) next context
      )
    ]