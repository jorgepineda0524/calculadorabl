using Calculadora.Mobile.MVVM.Views;

namespace Calculadora.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new CalculatorView());
        }
    }
}