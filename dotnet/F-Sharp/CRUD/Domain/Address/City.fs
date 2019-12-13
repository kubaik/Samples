namespace CRUD.Domain.Address
open System

type City = {
    id: Guid
    Name: string
}

type CityList = City[]
type CityFindById = Guid -> City