using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeMyFoodApp.Models
{
    public class UiProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public double Price { get; set; }
        public ImageSource SourceImage { get; set; }
        private Product product { get; set; }

        public UiProduct(int id, string name, string description, double price, ImageSource source)
        {
            Id = id;
            Name = name;
            Description = description;
            SourceImage = source;
            Price = price;
        }

        public UiProduct(Product p)
        {
            Id = p.Id;
            product = p;
            SourceImage = ImageSource.FromStream(LoadImage);
            Name = p.Name;
            Description = p.Description;
            Price = p.Price;

        }

        private Stream LoadImage()
        {
            if (product.ImageString == null) return Stream.Null;
            var imageBytes = Convert.FromBase64String(product.ImageString);
            MemoryStream imageDecodeStream = new(imageBytes);
            return imageDecodeStream;
        }
    }
}
