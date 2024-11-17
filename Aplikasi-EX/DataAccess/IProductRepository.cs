// DAL/Interfaces/IUserRepository.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using Aplikasi_EX.Model;

public interface IProductRepository
{
    Task InsertProductAsync(Product product);
    Task<List<Product>> GetSellerProductsAsync(int sellerID);
    Task<List<Product>> GetProductsByCategoryAsync(string category);
    Task<List<Product>> GetProductsBySearchAsync(string search);
    Task<List<Product>> GetProductsBySearchAndCategoryAsync(string search, string category);
    Task<Product> GetProductByIdAsync(int id);
    Task UpdateProductAsync(Product product);
    Task BuyProductAsync(int ProductID, int Quantity, int BuyerID);
}