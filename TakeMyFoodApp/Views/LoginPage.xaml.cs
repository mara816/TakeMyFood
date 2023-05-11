using TakeMyFoodApp.ViewModels;

namespace TakeMyFoodApp.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginViewModel vm)
	{
		InitializeComponent();
    BindingContext = vm;
  }
}