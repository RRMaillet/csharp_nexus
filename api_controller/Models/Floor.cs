using api_controller.Models.Validations;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace api_controller.Models
{

    // Wood - Price must be more than 2.00
    // Laminate - Price must be less than 2.00


    public class Floor
    {
        [Required]
        public int FloorId { get; set; }

        [Required]
        public string? FloorName { get; set;}

        public string? FloorColor { get; set;}

        public string? FloorDescription { get; set;}

        [Floor_EnsureCorrectPrice]
        public double? Price { get; set;}
    }
}
