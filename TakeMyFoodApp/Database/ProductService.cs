using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using TakeMyFoodApp.Models;

namespace TakeMyFoodApp.Database
{
  public class ProductService : IProductRepository
  {

        private readonly SQLiteAsyncConnection Database;
    public ProductService(string dbPath)
    {
      Database = new SQLiteAsyncConnection(dbPath);
      Database.CreateTableAsync<Product>().Wait();
    }
    public async Task<bool> AddUpdateProductAsync(Product product)
    {
      if (product.Id > 0)
      {
        await Database.UpdateAsync(product);
      }
      else
      {
        await Database.InsertAsync(product);
      }
      return await Task.FromResult(true);
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
      await Database.DeleteAsync<Product>(id);
      return await Task.FromResult(true);
    }

    public async Task<Product> GetProductAsync(int id)
    {
      return await Database.Table<Product>().Where(p => p.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Product>> GetProductAsync()
    {
      return await Task.FromResult(await Database.Table<Product>().ToListAsync());
    }
  }
}
