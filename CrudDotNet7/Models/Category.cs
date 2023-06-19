using System.ComponentModel.DataAnnotations;

namespace CrudDotNet7.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Display { get; set; }

        public string Brand { get; set; }
        public Boolean IsFavorite { get; set; }

        public Boolean IsPacket { get; set; }

        [Required]
        public DateTime CreateDateTime { get; set; } = DateTime.Now;
    }
}
