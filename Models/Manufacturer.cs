using System.ComponentModel.DataAnnotations;

namespace net_7_angular_cars.Models
{
    public class Manufacturer : BaseModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
