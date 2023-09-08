using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace net_7_angular_cars.Models
{

    public class User : BaseModel
    {
        [Required]
        [StringLength(50)]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [ForeignKey("UserId")]
        public ICollection<Vehicle>? Vehicles { get; set; }
    }
}
