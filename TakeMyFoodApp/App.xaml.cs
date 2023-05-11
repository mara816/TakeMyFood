using TakeMyFoodApp.Database;

namespace TakeMyFoodApp;

public partial class App : Application
{
  public static ProductService productService;

  public static ProductService ProductService
  {
    get
    {
      if (productService == null)
      {
        productService = new ProductService(
          Path.Combine(Environment.GetFolderPath((Environment.SpecialFolder.LocalApplicationData)), "ProductDB.db3"));
      }
      return productService;
    }
  }
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
