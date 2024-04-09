using api_WebFront.Models.Validations;
using System.ComponentModel.DataAnnotations;


namespace api_WebFront.Models
{

    // Wood - Price must be more than 2.00
    // Laminate - Price must be less than 2.00


    public class Floor
    {
        public int FloorId { get; set; }

        [Required]
        public string? FloorName { get; set;}

        [Required]
        public string? FloorColor { get; set;}

        public string? FloorDescription { get; set;}

        [Floor_EnsureCorrectPrice]
        public double? Price { get; set;}
    }
}
