using System;
using Hw1;

double val1;
double val2;
CalculatorOperation operation;

Parser.ParseCalcArguments(new string[] {Console.ReadLine(),Console.ReadLine(),Console.ReadLine()},out val1, out operation, out val2);

// TODO: implement calculator logic
var result = Calculator.Calculate(val1, operation, val2);
Console.WriteLine(result);