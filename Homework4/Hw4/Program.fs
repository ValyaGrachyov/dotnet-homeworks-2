

open System
open Hw4.Calculator
open Hw4.Parser

let read = Console.ReadLine().Split(" ")

let calculator CalcOptions =
    calculate CalcOptions.arg1  CalcOptions.operation  CalcOptions.arg2


Console.WriteLine(read |> parseCalcArguments |> calculator)

