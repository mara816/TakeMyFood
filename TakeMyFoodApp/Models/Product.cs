using System.Collections.ObjectModel;
using SQLite;

namespace TakeMyFoodApp.Models
{
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public string Owner { get; set; }
        public string Tag { get; set; }
        //public List<string> Ingredients { get; set; }
        public string ImageString { get; set; }

        public double Price { get; set; }

        public Product()
        {
        }
        public Product(string name, string description, string tag, string imageString)
        {
            Name = name;
            Description = description;
            Tag = tag;
            ImageString = imageString;
        }
        public Product(string name, string description, string tag, string imageString, double price)
        {
            Name = name;
            Description = description;
            Tag = tag;
            Price = price;
            ImageString = imageString;
        }

        //public Product( string name, string description, string tag/*, List<string> ingredients*/ )
        //{
        //  Name = name;
        //  Description = description;
        //  Tag = tag;
        //  //Ingredients = ingredients;
        //}
    }
}
