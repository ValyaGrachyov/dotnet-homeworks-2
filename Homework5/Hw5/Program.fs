open System
open System.Diagnostics.CodeAnalysis
open Hw5

[<ExcludeFromCodeCoverage>]
let getArgs (input : string[]) : string[] =
    match input.Length with
    | 0 ->
        let str = Console.ReadLine()
        let args = str.Split(' ', StringSplitOptions.RemoveEmptyEntries)
        args
    | _ -> input

let messageToString message=
    match message with
    | Message.WrongArgLength -> "Должно быть только 3 аргумента"
    | Message.WrongArgFormat -> "Одно из чисел неправильного формата";
    | Message.WrongArgFormatOperation -> "Неправильная операция"
    | Message.DivideByZero -> "Деление на 0"
    
let calculate (a,operation:Calculator.CalculatorOperation, b) =
    Calculator.calculate a operation b
    
[<EntryPoint>]
let main (args: string[]) =
    let parsedArgs = getArgs args
    match Parser.parseCalcArguments parsedArgs with 
    | Ok num -> printf $"{calculate num}"
    | Error err -> printf $"Error occured: {messageToString err}"
    0          