using TakeMyFoodApp.Database;
using TakeMyFoodApp.ViewModels;

namespace TakeMyFoodApp.Views;

public partial class CreateProductPage : ContentPage
{
  public CreateProductPage(CreateProductViewModel vm)
	{
		InitializeComponent();
    BindingContext = vm;
  }
}