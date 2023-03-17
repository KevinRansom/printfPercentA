module Program
open System.Reflection

//let myAllPublic = AllPublic.doit (BindingFlags.Public)

MixedVisibility.doit (BindingFlags.Public)
printfn  "================================="
MixedVisibility.doit (BindingFlags.NonPublic)
