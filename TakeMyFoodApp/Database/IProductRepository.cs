using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeMyFoodApp.Models;

namespace TakeMyFoodApp.Database
{
  public interface IProductRepository
  {
    Task<bool> AddUpdateProductAsync(Product product);
    Task<bool> DeleteProductAsync(int  id);
    Task<Product> GetProductAsync(int id);
    Task<IEnumerable<Product>> GetProductAsync();

  }
}
