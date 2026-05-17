using WarehouseApp.Models;

namespace WarehouseApp.Services
{
    public interface ISaleService
    {
        Task<List<Sale>> GetAllSalesAsync();
        Task<Sale?> GetSaleByIdAsync(int id);
        Task CreateSaleAsync(Sale sale);
        Task<decimal> GetTotalSalesTodayAsync();
        Task<List<Sale>> GetSalesByDateRangeAsync(DateTime start, DateTime end);
        Task<bool> ProcessSaleAsync(int productId, int quantity, string? customerName);
        Task DeleteSaleAsync(int id);
    }
}