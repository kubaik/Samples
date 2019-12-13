namespace CRUD.Domain.Person
open System

type Person = {
    Id: Guid
    Nome: string
    CityId: Guid
}

type PersonList = Person[]
type PersonSave = Person -> Person
type PersonDelete = Guid -> bool