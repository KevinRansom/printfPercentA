// For more information see https://aka.ms/fsharp-console-apps
module AllPublic

open System

type MyRecord =
    {
        A: (string * string)
        B: (int * float * string)
        C: int
    }

    static member GetValueInfo (value: MyRecord (* me could be null *), bindingFlags: System.Reflection.BindingFlags) : obj array =
        match box value with
        | null -> printf "The value is null."
        | _ -> printf "The value is not null."

        [| value.A :> obj; value.B :> obj; value.C :> obj|]

let data =
    [|
        { A = ("Hello", "World"); B = (1,2.0,"First"); C = 1 }
        { A = ("Bonjour", "Moon"); B = (3,4.0,"Second"); C = 2 }
        { A = ("Salut", "Sun");    B = (5,6.0,"Third"); C = 3 }
    |]

let doit (bindingFlags: System.Reflection.BindingFlags) =
    let mystring = sprintf "%A" (MyRecord.GetValueInfo(data[0], bindingFlags))

    //let mystring = sprintf "%+30A" data

    Console.WriteLine(mystring)
