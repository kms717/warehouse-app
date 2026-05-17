using System.ComponentModel.DataAnnotations;

namespace WarehouseApp.Models
{
    /// <summary>
    /// Категория товара
    /// </summary>
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; } = string.Empty;

        // Навигационное свойство
        public virtual ICollection<Product>? Products { get; set; }
    }
}