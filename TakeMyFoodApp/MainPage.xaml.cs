using TakeMyFoodApp.ViewModels;

namespace TakeMyFoodApp;

public partial class MainPage : ContentPage
{
  public MainPage( MainViewModel vm )
	{
		InitializeComponent();
    BindingContext = vm;
  }
}

