
namespace Calculadora.Mobile
{
    public partial class MainPage : ContentPage
    {
        int state = 1;
        string operation;
        double number1, number2;

        public MainPage()
        {
            InitializeComponent();
            OnClear(null,null);
        }

        void OnClear(object sender, EventArgs e)
        {
            number1= 0;
            number2= 0;
            state= 1;
            this.resultado.Text= "0";
        }

        void SquareRoot(object sender, EventArgs e)
        {
            if (number1 == 0)
            {
                return;
            }

            number1 = number1 * number1;
            this.resultado.Text = number1.ToString();
        }
        
        void SelectionNumber(object sender, EventArgs e)
        {
            Button button = sender as Button;
            string btnAction = button.Text;

            if (this.resultado.Text == "0" || state < 0)
            {
                this.resultado.Text = string.Empty;
                if (state < 0)
                {
                    state *= -1;
                }
            }

            this.resultado.Text += btnAction;

            double num;
            if(double.TryParse(this.resultado.Text, out num))
            {
                this.resultado.Text = num.ToString("N0");
                if (state == 1)
                {
                    number1 = num;
                }
                else
                {
                    number2 = num;
                }
            }
        }

        void OperationSelected(object sender, EventArgs e)
        {
            state = -2;
            Button button = sender as Button;
            string btnAction = button.Text;
            operation= btnAction;
        }

        void Calculate(object sender, EventArgs e)
        {
            //if (state == 2)
            //{
            //    var result2 = Calculator.Calculate(number1,number2,operation);

            //    this.resultado.Text = result2.ToString();
            //    number1 = result2;
            //    state = -1;
            //}
        }
    }
}