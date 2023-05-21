using Calculadora.Mobile.MVVM.Models;
using Calculadora.Mobile.MVVM.ViewModels;

namespace Calculadora.Mobile.MVVM.Views;

public partial class CalculatorView : ContentPage
{
	public CalculatorView()
	{
		InitializeComponent();
		BindingContext = new CalculatorVewModel();
	}
}