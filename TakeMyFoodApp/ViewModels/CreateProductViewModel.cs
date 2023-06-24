using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TakeMyFoodApp.Database;
using TakeMyFoodApp.Models;
using TakeMyFoodApp.Views;

namespace TakeMyFoodApp.ViewModels
{
    public partial class CreateProductViewModel : ObservableObject
    {
        [ObservableProperty] private string name;
        [ObservableProperty] private string description;
        [ObservableProperty] private string tag;
        [ObservableProperty] private double price;


        [ObservableProperty]
        private ObservableCollection<Product> product;


        [RelayCommand]
        async Task Create()
        {
            await using var imageEncodeStream = await FileSystem.OpenAppPackageFileAsync("sunflower.jpg");
            using var ms = new MemoryStream();
            await imageEncodeStream.CopyToAsync(ms);
            var img = Convert.ToBase64String(ms.ToArray());

            await App.ProductService.AddUpdateProductAsync(new Product(Name, Description, Tag, img, Price));
            await Shell.Current.GoToAsync(nameof(DiscoverPage));
        }
    }
}
