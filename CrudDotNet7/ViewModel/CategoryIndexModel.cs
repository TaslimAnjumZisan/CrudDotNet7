using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CrudDotNet7.ViewModel
{
    public class CategoryIndexModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name required")]
        [DisplayName("Product name")]
        [RegularExpression("([A-Z*a-z]+)", ErrorMessage = "Please enter valid Name")]
        [StringLength(20, ErrorMessage = "Do not enter more than 20 characters")]
        public string Name { get; set; }

        [DisplayName("Product stock")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid Number")]
        [Range(1, int.MaxValue, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Display { get; set; }
        public DateTime CreateDateTime { get; set; } = DateTime.Now;
    }
}
