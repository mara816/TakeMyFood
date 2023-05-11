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

    public SQLiteAsyncConnection database;
    public ProductService(string dbPath)
    {
      database = new SQLiteAsyncConnection(dbPath);
      database.CreateTableAsync<Product>().Wait();
    }
    public async Task<bool> AddUpdateProductAsync(Product product)
    {
      if (product.Id > 0)
      {
        await database.UpdateAsync(product);
      }
      else
      {
        await database.InsertAsync(product);
      }
      return await Task.FromResult(true);
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
      await database.DeleteAsync<Product>(id);
      return await Task.FromResult(true);
    }

    public async Task<Product> GetProductAsync(int id)
    {
      return await database.Table<Product>().Where(p => p.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Product>> GetProductAsync()
    {
      return await Task.FromResult(await database.Table<Product>().ToListAsync());
    }
  }
}
