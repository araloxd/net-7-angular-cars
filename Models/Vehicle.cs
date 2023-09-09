using System.ComponentModel.DataAnnotations;

namespace net_7_angular_cars.Models
{
    public class Vehicle: BaseModel
    {
        [Required(ErrorMessage = "Owner's Name is required.")]
        public string OwnerName { get; set; }
        [Required(ErrorMessage = "Year of manufacture is required.")]
        public int YearOfManufacture { get; set; }
        public decimal Weight { get; set; }
        // Category
        public Category? Category { get; set; }
        public int? CategoryId { get; set; }
        // User
        public int? UserId { get; set; }
        public User? User { get; set; }
        // Manufacturer
        public int? ManufacturerId { get; set; }
        public Manufacturer? Manufacturer { get; set; }
    }
}
