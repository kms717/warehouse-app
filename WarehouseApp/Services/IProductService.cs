using WarehouseApp.Models;

namespace WarehouseApp.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<Product?> GetProductByIdAsync(int id);
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);
        Task<bool> ReduceStockAsync(int productId, int quantity);
    }
}