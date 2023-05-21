using PropertyChanged;
using System.Data;
using System.Windows.Input;

namespace Calculadora.Mobile.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class CalculatorVewModel
    {
        public string Number1 { get; set; }
        public string Number2 { get; set; }
        public string Number3 { get; set; }
        public string Operation1 { get; set; }
        public string Operation2 { get; set; }
        public string Operation3 { get; set; }
        public string Result { get; set; }
        public string OpMath { get; set; }

        public ICommand AddCommand => new Command(() => Result = CalculateOperationMath());
        public ICommand AddCommandClear => new Command(() => ClearCalculator());
        public ICommand AddCommandDelete => new Command(() => DeleteLastChar());
        public ICommand AddCommandNumber1 => new Command((key) => OpMath = AddOperationMath(key.ToString()));

        private string CalculateOperationMath()
        {
            string operacion = OpMath;
            DataTable dt = new DataTable();
            var resultado = dt.Compute(operacion, "");
            return resultado.ToString();
        }

        private void ClearCalculator()
        {
            Result = string.Empty;
            OpMath = string.Empty;
        }

        private void DeleteLastChar()
        {
            if (!string.IsNullOrEmpty(OpMath))
            {
                OpMath = OpMath[..^1];
            }
        }

        private string AddOperationMath(string key)
        {
            string opConcat = OpMath;

            List<string> ops = new List<string>();

            if (string.IsNullOrEmpty(OpMath))
            {
                opConcat = key;
            }
            else if (key.All(char.IsDigit))
            {
                string lastChar = opConcat.Substring(opConcat.Length - 1, 1);
                if (lastChar.All(char.IsDigit))
                {
                    opConcat = $"{opConcat}{key}";
                }
                else
                {
                    opConcat = $"{opConcat} {key}";
                }
            }
            else
            {
                var opArray = opConcat.Split(' ');
                if (opArray.LastOrDefault().All(char.IsDigit))
                {
                    opConcat = $"{opConcat} {key}";
                }
                else
                {
                    opArray = opArray.SkipLast(1).ToArray();
                    opConcat = string.Join(" ", opArray);
                    opConcat = $"{opConcat} {key}";
                }
            }

            return opConcat;
        }
    }
}
