using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TakeMyFoodApp.Views;

namespace TakeMyFoodApp.ViewModels;

public partial class LoginViewModel : ObservableObject
{

  [ObservableProperty] private string userName;
  [ObservableProperty] private string password;

  [RelayCommand]
  async Task Login()
  {
    //if (userName != "mathias" && password != "pass")
    //  return;
    await Shell.Current.GoToAsync( nameof( DiscoverPage ) );

  }
}

