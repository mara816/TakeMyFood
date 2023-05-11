using TakeMyFoodApp.Views;

namespace TakeMyFoodApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(DiscoverPage), typeof(DiscoverPage));
		Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
		Routing.RegisterRoute(nameof(CreateProductPage), typeof(CreateProductPage));
	}
}
