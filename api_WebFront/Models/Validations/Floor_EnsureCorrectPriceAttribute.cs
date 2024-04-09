using System.ComponentModel.DataAnnotations;

namespace api_WebFront.Models.Validations
{
    public class Floor_EnsureCorrectPriceAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var floor = validationContext.ObjectInstance as Floor;

            if (floor != null)
            {
                if (floor.FloorName != null && floor.FloorName.Equals("Wood", StringComparison.OrdinalIgnoreCase) && floor.Price <= 2.00)
                {
                    return new ValidationResult("Wood Floor pricing must be more than $2.00. Please verify that pricing is set accordingly.");
                }
                else if (floor.FloorName != null && floor.FloorName.Equals("Laminate", StringComparison.OrdinalIgnoreCase) && floor.Price >= 2.00)
                {
                    return new ValidationResult("Cork Floor pricing must be less than $2.00. Please verify that pricing is set accordingly.");
                }
            }
            return ValidationResult.Success;
        }
    }
}
