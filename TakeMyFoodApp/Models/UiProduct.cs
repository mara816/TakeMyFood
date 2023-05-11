using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeMyFoodApp.Models
{
  public class UiProduct
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public ImageSource SourceImage { get; set; }
    private Product product { get; set; }

    public UiProduct(string name, string description, ImageSource source)
    {
      Name = name;
      Description = description;
      SourceImage = source;
    }

    public UiProduct(Product p)
    {
      product = p;
      SourceImage = ImageSource.FromStream(LoadImage);
      Name = p.Name;
      Description = p.Description;

    }

    private Stream LoadImage()
    {
      if (product.ImageString == null) return Stream.Null;
      var imageBytes = Convert.FromBase64String( product.ImageString );
      MemoryStream imageDecodeStream = new( imageBytes );
      return imageDecodeStream;
    }
  }
}
