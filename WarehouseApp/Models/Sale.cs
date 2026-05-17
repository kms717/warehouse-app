using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseApp.Models
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }

        public DateTime SaleDate { get; set; } = DateTime.Now;

        public string? CustomerName { get; set; }
    }
}