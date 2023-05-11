using TakeMyFoodApp.ViewModels;

namespace TakeMyFoodApp.Views;

public partial class DiscoverPage : ContentPage
{
	public DiscoverPage(DiscoverViewModel vm)
	{
		InitializeComponent();
    BindingContext = vm;
    vm.OnAppearing();
  }
}