using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Hw8.Calculator;
using Microsoft.AspNetCore.Mvc;

namespace Hw8.Controllers;

public class CalculatorController : Controller
{
    public ActionResult<double> Calculate([FromServices] ICalculator calculator,
        string val1,
        string operation,
        string val2)
    {
        double x;
        Operation opr;
        double y;
        

        double result;
        try
        {
            Parser.ParseCalcArguments(new string[] { val1, operation, val2 }, out x, out opr, out y);
            result = new Calculator.Calculate().Calculator(x, opr, y);
        }
        catch (Exception e)
        {
            if (e is ArgumentException or InvalidOperationException)
                return BadRequest(e.Message);

            throw;
        }

        return Ok(result);
    }
    
    [ExcludeFromCodeCoverage]
    public IActionResult Index()
    {
        return Content(
            "Заполните val1, operation(plus, minus, multiply, divide) и val2 здесь '/calculator/calculate?val1= &operation= &val2= '\n" +
            "и добавьте её в адресную строку.");
    }
}