using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CrudDotNet7.ViewModel
{
    public class CategoryEditModel
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

        public string Brand { get; set; }

        [DisplayName("Favorite")]
        public Boolean IsFavorite { get; set; }

        [DisplayName("Packet Available")]
        public Boolean IsPacket { get; set; }
        public DateTime CreateDateTime { get; set; } = DateTime.Now;

        public string Favourite
        {
            get
            {
                if (IsFavorite)
                {
                    return "Yes";
                }
                else
                {
                    //DEFAULT value here. 
                    return "No";
                }
            }

        }

        public string Packet
        {
            get
            {
                if (IsPacket)
                {
                    return "Available";
                }
                else
                {
                    //DEFAULT value here. 
                    return "Not Available";
                }
            }

        }
    }
}
