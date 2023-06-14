using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CrudDotNet7.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        //[Required(ErrorMessage ="Product name required")]
        //[DisplayName("Product name")]
        //[StringLength(20)]
        public string Name { get; set; }

       
        //[DisplayName("Product stock")]
        //[RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid Number")]
        //[Range(1, int.MaxValue, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Display { get; set; }


        

        [Required]
        public DateTime CreateDateTime { get; set; } = DateTime.Now;
    }
}
