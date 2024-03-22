using System.ComponentModel.DataAnnotations;

namespace SimpleCRUDApp.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public String? Name { get; set; }
    }
}
