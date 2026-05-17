using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseApp.Models
{
    /// <summary>
    /// Товар на складе
    /// </summary>
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string? Description { get; set; }

        // Внешний ключ
        public int CategoryId { get; set; }

        // Навигационное свойство
        public virtual Category? Category { get; set; }

        // Связь с продажами
        public virtual ICollection<Sale>? Sales { get; set; }
    }
}