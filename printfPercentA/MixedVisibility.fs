module MixedVisibility

open System
open System.Reflection

type internal MyRecord =
    {
        A: (string * string)
        B: (int * float * string)
        C: int
    }
    //override _.ToString() = "R"

    static member GetValueInfo (value: MyRecord (* me could be null *), bindingFlags: System.Reflection.BindingFlags) : obj array =
        match box value with
        | null -> printf "The value is null."
        | _ -> printf "The value is not null."

        [| value.A :> obj; value.B :> obj; value.C :> obj|]

//    override this.ToString() = $"MyRecord({this.A}{this.B}{this.C})"

let internal _data =
    [|
        {A = ("Hello", "World");  B = (1, 2.0,"First");  C = 1}
        {A = ("Bonjour", "Moon"); B = (3, 4.0,"Second"); C = 2}
        {A = ("Salut", "Sun");    B = (5, 6.0,"Third");  C = 3}
    |]


type internal R =
    { X : int list; Y : string list }
    override _.ToString() = "R"

let internal data = { X = [ 1;2;3 ]; Y = ["one"; "two"; "three"] }


let doit (bindingFlags: BindingFlags) =
//    let mystring = sprintf "%A" (MyRecordWithMixedVisibility.GetValueInfo(data[0], bindingFlags))

    let mystring =
        if (bindingFlags &&& BindingFlags.NonPublic) <> BindingFlags.NonPublic then
            sprintf "%+A" data
        else
            sprintf "%A" data

    Console.WriteLine(mystring)

