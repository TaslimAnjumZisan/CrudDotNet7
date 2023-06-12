using System.ComponentModel.DataAnnotations;

namespace CrudDotNet7.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Display { get; set; }
        [Required]
        public DateTime CreateDateTime { get; set; } = DateTime.Now;
    }
}
