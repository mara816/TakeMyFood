using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TakeMyFoodApp.Models;
using TakeMyFoodApp.Views;

namespace TakeMyFoodApp.ViewModels;

public partial class DiscoverViewModel : ObservableObject
{
  [ObservableProperty] private bool isBusy;

  [ObservableProperty]
  private ObservableCollection<UiProduct> products;


  public DiscoverViewModel()
  {
    Products = new ObservableCollection<UiProduct>();
  }

  [RelayCommand]
  async Task LoadProduct()
  {
    IsBusy = true;
    try
    {
      Products.Clear();

      var list = await App.ProductService.GetProductAsync();
      foreach (var p in list)
      {
        Products.Add(new UiProduct(p));
      }
    }
    catch (Exception)
    {
      Console.WriteLine();
      throw;
    }
    finally
    {
      IsBusy = false;
    }
  }


  [RelayCommand]
  async Task Add()
  {
    await Shell.Current.GoToAsync(nameof(CreateProductPage));
  }

  public void OnAppearing()
  {
    IsBusy = true;
  }

  [RelayCommand]
  async Task Delete(UiProduct ui)
  {
    await App.ProductService.DeleteProductAsync(ui.Id);
    if (Products.Contains(ui))
    {
      Products.Remove(ui);
      await App.ProductService.DeleteProductAsync(ui.Id);
    }
  }
}

