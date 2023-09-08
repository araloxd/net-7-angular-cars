using System.ComponentModel.DataAnnotations;

namespace net_7_angular_cars.Models
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }
    }
}
