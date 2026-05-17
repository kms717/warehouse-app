using Microsoft.EntityFrameworkCore;
using WarehouseApp.Data;
using WarehouseApp.Models;

namespace WarehouseApp.Services
{
    public class SaleService : ISaleService
    {
        private readonly AppDbContext _context;
        public SaleService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Sale>> GetAllSalesAsync()
        {
            return await _context.Sales
                .Include(s => s.Product)
                .OrderByDescending(s => s.SaleDate)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Sale?> GetSaleByIdAsync(int id)
        {
            return await _context.Sales
                .Include(s => s.Product)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task CreateSaleAsync(Sale sale)
        {
            sale.SaleDate = DateTime.Now;
            await _context.Sales.AddAsync(sale);
            await _context.SaveChangesAsync();
        }

        public async Task<decimal> GetTotalSalesTodayAsync()
        {
            var today = DateTime.Today;
            return await _context.Sales
                .Where(s => s.SaleDate.Date == today)
                .SumAsync(s => s.TotalPrice);
        }

        public async Task<List<Sale>> GetSalesByDateRangeAsync(DateTime start, DateTime end)
        {
            return await _context.Sales
                .Include(s => s.Product)
                .Where(s => s.SaleDate >= start && s.SaleDate <= end)
                .OrderByDescending(s => s.SaleDate)
                .ToListAsync();
        }
        public async Task<bool> ProcessSaleAsync(int productId, int quantity, string? customerName)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null || product.Quantity < quantity)
                return false;

            var sale = new Sale
            {
                ProductId = productId,
                Quantity = quantity,
                TotalPrice = product.Price * quantity,
                SaleDate = DateTime.Now,
                CustomerName = customerName
            };

            await _context.Sales.AddAsync(sale);
            product.Quantity -= quantity;

            await _context.SaveChangesAsync();
            return true;
        }
        public async Task DeleteSaleAsync(int id)
        {
            var sale = await _context.Sales.FindAsync(id);
            if (sale != null)
            {
                _context.Sales.Remove(sale);
                await _context.SaveChangesAsync();
            }
        }
    }
}
