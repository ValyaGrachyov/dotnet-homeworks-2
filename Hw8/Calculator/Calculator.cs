namespace Hw8.Calculator
{
    public class Calculator : ICalculator
    {
        public double Divide(double val1, double val2)
        {
            return val2 == 0 ? throw new InvalidOperationException(Messages.DivisionByZeroMessage) : val1 / val2;
        }

        public double Minus(double val1, double val2) => val1 - val2;

        public double Multiply(double val1, double val2) => val1 * val2;

        public double Plus(double val1, double val2) => val1 + val2;

        public double Calc(double val1, Operation opr, double val2)
        {
            switch (opr) 
                {
                case Operation.Multiply:
                    return Multiply(val1, val2);

                case Operation.Divide:
                    return Divide(val1, val2);

                case Operation.Minus:
                    return Minus(val1, val2);

                case Operation.Plus:
                    return Plus(val1, val2);

                default:
                    throw new InvalidOperationException(Messages.InvalidOperationMessage);


            }
        }

    }
}
