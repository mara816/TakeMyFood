using Microsoft.Extensions.Logging;
using TakeMyFoodApp.Database;
using TakeMyFoodApp.ViewModels;
using TakeMyFoodApp.Views;

namespace TakeMyFoodApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

    //builder.Services.AddSingleton<TakeMyFoodDatabase>();

    builder.Services.AddSingleton<MainPage>();
    builder.Services.AddSingleton<MainViewModel>();

    builder.Services.AddTransient<DiscoverPage>();
    builder.Services.AddTransient<DiscoverViewModel>();

    builder.Services.AddTransient<LoginPage>();
    builder.Services.AddTransient<LoginViewModel>();

    builder.Services.AddTransient<CreateProductPage>();
    builder.Services.AddTransient<CreateProductViewModel>();

    return builder.Build();
	}
}
