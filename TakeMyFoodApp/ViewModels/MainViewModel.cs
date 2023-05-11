using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TakeMyFoodApp.Views;

namespace TakeMyFoodApp.ViewModels
{
  public partial class MainViewModel : ObservableObject
  {

    public MainViewModel()
    {
      Shell.Current.GoToAsync( nameof( LoginPage ) );
    }
  }
}
