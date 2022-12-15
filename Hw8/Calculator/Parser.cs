using System.Globalization;

namespace Hw8.Calculator
{
    public static class Parser
    {
        public static void ParseCalcArguments(string[] arr, out double val1, out Operation opr, out double val2  )
        {
            if (Double.TryParse(arr[0], NumberStyles.AllowDecimalPoint,
            CultureInfo.InvariantCulture, out val1) == false) { throw new ArgumentException(Messages.InvalidNumberMessage); }

            if (Double.TryParse(arr[2], NumberStyles.AllowDecimalPoint,
            CultureInfo.InvariantCulture, out val2) == false) { throw new ArgumentException(Messages.InvalidNumberMessage); }

            opr = ParseOperation(arr[1]);

            if (opr == Operation.Invalid) { throw new InvalidOperationException(Messages.InvalidOperationMessage); }

        }

        private static Operation ParseOperation(string str)
        {            
            switch (str)
            {
                case "Plus":
                    return Operation.Plus;
                    break;

                case "Minus":
                    return Operation.Minus;
                    break;

                case "Multiply":
                    return Operation.Multiply;
                    break;

                case "Divide":
                    return Operation.Divide;
                    break;

                default:
                    return Operation.Invalid;
                    break;
            }
        }
    }
}
