using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleCRUDApp.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [DisplayName("Item name")]
        public string? ItemName { get; set; }
        [Required]
        [Range(0,10000)]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }

    }
}
