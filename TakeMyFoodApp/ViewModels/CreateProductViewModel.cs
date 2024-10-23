using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TakeMyFoodApp.Database;
using TakeMyFoodApp.Models;
using TakeMyFoodApp.Views;
using Microsoft.Maui.Storage;
using Microsoft.Maui.Controls;

namespace TakeMyFoodApp.ViewModels
{
  public partial class CreateProductViewModel : ObservableObject
  {
    [ObservableProperty] private string name;
    [ObservableProperty] private string description;
    [ObservableProperty] private string tag;
    [ObservableProperty] private double price;
    [ObservableProperty] private ImageSource selectedImage;

    [ObservableProperty]
    private ObservableCollection<Product> product;

    [RelayCommand]
    async Task Create()
    {
      var stream = await GetStreamFromImageSource(SelectedImage);
      using var memoryStream = new MemoryStream();
      await stream.CopyToAsync(memoryStream);
      var imageBytes = memoryStream.ToArray();
      var img = Convert.ToBase64String(imageBytes);

      await App.ProductService.AddUpdateProductAsync(new Product(Name, Description, Tag, img, Price));
      await Shell.Current.GoToAsync(nameof(DiscoverPage));
    }

    [RelayCommand]
    async Task PickImage()
    {
      var result = await FilePicker.PickAsync(new PickOptions
      {
        FileTypes = FilePickerFileType.Images,
        PickerTitle = "Pick an image"
      });

      if (result != null)
      {
        using var stream = await result.OpenReadAsync();
        var memoryStream = new MemoryStream();
        await stream.CopyToAsync(memoryStream);
        memoryStream.Position = 0; // Reset the position to the beginning of the stream
        SelectedImage = ImageSource.FromStream(() => new MemoryStream(memoryStream.ToArray()));
      }
    }

    [RelayCommand]
    async Task TakePicture()
    {
      if (MediaPicker.Default.IsCaptureSupported)
      {
        var result = await MediaPicker.Default.CapturePhotoAsync();

        if (result != null)
        {
          using var stream = await result.OpenReadAsync();
          var memoryStream = new MemoryStream();
          await stream.CopyToAsync(memoryStream);
          memoryStream.Position = 0; // Reset the position to the beginning of the stream
          SelectedImage = ImageSource.FromStream(() => new MemoryStream(memoryStream.ToArray()));
        }
      }
    }

    private async Task<Stream> GetStreamFromImageSource(ImageSource imageSource)
    {
      if (imageSource is StreamImageSource streamImageSource)
      {
        var cancellationToken = CancellationToken.None;
        return await streamImageSource.Stream(cancellationToken);
      }
      else if (imageSource is FileImageSource fileImageSource)
      {
        var filePath = fileImageSource.File;
        return File.OpenRead(filePath);
      }
      else if (imageSource is UriImageSource uriImageSource)
      {
        var httpClient = new HttpClient();
        return await httpClient.GetStreamAsync(uriImageSource.Uri);
      }
      throw new InvalidOperationException("Unsupported ImageSource type");
    }
  }
}
