// DAL/Interfaces/IUserRepository.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using Aplikasi_EX.Model;

public interface IProductRepository
{
    Task InsertProductAsync(Product product);
    Task<List<Product>> GetSellerProductsAsync(int sellerID);
    Task<List<Product>> GetProductsByCategoryAsync(string category);
}