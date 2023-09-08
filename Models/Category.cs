using System.ComponentModel.DataAnnotations;

namespace net_7_angular_cars.Models
{
    public class Category : BaseModel
    {
        [Required(ErrorMessage = "Category's Name is required.")]
        [StringLength(50)]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Invalid character(s)")]
        public string Name { get; set; }
        [Required(ErrorMessage = "MinWeight is required.")]
        [Range(0, 10000)]
        public decimal MinWeight { get; set; }
        [Required(ErrorMessage = "MaxWeight is required.")]
        [Range(0, 10000)]
        public decimal MaxWeight { get; set; }
        [Required(ErrorMessage = "Icon is required.")]
        public string Icon { get; set; }

    }
}
