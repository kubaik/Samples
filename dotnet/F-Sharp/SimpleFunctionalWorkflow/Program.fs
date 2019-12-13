//// Learn more about F# at http://fsharp.org
//
//open System
//
////type UseCaseResult =
////    | Success
////    | ValidationError
////    | UpdateError
////    | SmtpError
////
////type UseCaseResult =
////    | Success
////    | Failure
//
////let bind switchFunction =
////    fun twoTrackInput ->
////        match twoTrackInput with
////        | Success s -> switchFunction s
////        | Failure f -> Failure f
//
////let bind switchFunction =
////    function
////    | Success s -> switchFunction s
////    | Failure f -> Failure f
//
////let (>=>) switch1 switch2 x =
////    match switch1 x with
////    | Success s -> switch2 s
////    | Failure f -> Failure f
//
//// convert a normal function into a two-track function
////let map oneTrackFunction twoTrackInput =
////    match twoTrackInput with
////    | Success s -> Success (oneTrackFunction s)
////    | Failure f -> Failure f
//
//// Tipo nativo equivalente no F# -> Choise
//type Result<'TSuccess, 'TFailure> =
//    | Success of 'TSuccess
//    | Failure of 'TFailure
//
//let bind switchFunction twoTrackInput =
//    match twoTrackInput with
//    | Success s -> switchFunction s
//    | Failure f -> Failure f
//
//let plus addSuccess addFailure switch1 switch2 x =
//    match (switch1 x),(switch2 x) with
//    | Success s1,Success s2 -> Success (addSuccess s1 s2)
//    | Failure f1,Success _  -> Failure f1
//    | Success _ ,Failure f2 -> Failure f2
//    | Failure f1,Failure f2 -> Failure (addFailure f1 f2)
//
///// create an infix operator
//let (>>=) twoTrackInput switchFunction =
//    bind switchFunction twoTrackInput
//
//let (>=>) switch1 switch2 =
//    switch1 >> (bind switch2)
//
//// create a "plus" function for validation functions
//let (&&&) v1 v2 =
//    let addSuccess r1 r2 = r1 // return first
//    let addFailure s1 s2 = s1 + "; " + s2  // concat
//    plus addSuccess addFailure v1 v2
//
//// convert a normal function into a switch
//let switch f x =
//    f x |> Success
//
//let tee f x =
//    f x |> ignore
//    x
//
//let tryCatch f x =
//    try
//        f x |> Success
//    with
//    | ex -> Failure ex.Message
//
//let doubleMap successFunc failureFunc twoTrackInput =
//    match twoTrackInput with
//    | Success s -> Success (successFunc s)
//    | Failure f -> Failure (failureFunc f)
//
//let map successFunc =
//    doubleMap successFunc id
//
//let log twoTrackInput =
//    let success x = printfn "DEBUG. Success so far: %A" x; x
//    let failure x = printfn "ERROR. %A" x; x
//    doubleMap success failure twoTrackInput
//
//let succeed x =
//    Success x
//
//let fail x =
//    Failure
//
//// Injectable log
//type Config = {debug:bool}
//let debugLogger twoTrackInput =
//    let success x = printfn "DEBUG. Success so far: %A" x; x
////    let failure = id // don't log here
//    let failure x = printfn "ERROR. %A" x; x
//    doubleMap success failure twoTrackInput
//
//let injectableLogger config =
//    if config.debug then debugLogger else id
//
//// Business rules
//type Request = { name: string; email: string }
//
//let validate1 input =
//   if input.name = "" then Failure "Name must not be blank"
//   else Success input
//
//let validate2 input =
//   if input.name.Length > 50 then Failure "Name must not be longer than 50 chars"
//   else Success input
//
//let validate3 input =
//   if input.email = "" then Failure "Email must not be blank"
//   else Success input
//
//let canonicalizeEmail input =
//   { input with email = input.email.Trim().ToLower() }
//
//let combinedValidation =
//    validate1
//    &&& validate2
//    &&& validate3
//
//// a dead-end function
//let updateDatabase input =
//   ()   // dummy dead-end function for now
//
//// execution rule
//let usecase config =
//    combinedValidation
//    //>=> switch canonicalizeEmail
//    >=> switch canonicalizeEmail  // normal composition
//    >=> tryCatch (tee updateDatabase)
//    >> injectableLogger config

open Library
open UseCases
open DomainTypes

[<EntryPoint>]
let main argv =
    let goodInput = {name="Alice"; email="UPPERCASE "}
    handleUpdateRequest goodInput
        |> printfn "Good Result = %A\n"
    //Canonicalize Good Result = Success {name = "Alice"; email = "uppercase";}

    let badInput = {name=""; email=""}
    handleUpdateRequest badInput
        |> printfn "Bad Result = %A\n"
    //Canonicalize Bad Result = Failure "Name must not be blank"

    0 // return an integer exit code
