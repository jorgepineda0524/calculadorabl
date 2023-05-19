namespace Calculadora.Mobile.Class
{
    public static class Calculator
    {
        public static double Calculate(double date1, double date2, string operation)
        {
            double result = 0;

            switch (operation)
            {
                case "*":
                    result = date1 * date2;
                    break;
                case "/":
                    result = date1 / date2;
                    break;
                case "-":
                    result = date1 - date2;
                    break;
                case "+":
                    result = date1 + date2;
                    break;
                default:
                    break;
            }

            return result;
        } 
    }
}
