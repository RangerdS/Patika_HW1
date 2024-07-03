using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Patika_HwFirstWeek.Models
{
    public class Car : BaseModel
    {
        [Required(ErrorMessage = "Brand is required.")]
        [MinLength(2, ErrorMessage = "Brand must be at least 2 characters.")]
        [MaxLength(50, ErrorMessage = "Brand must be at most 50 characters.")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Model is required.")]
        [MinLength(2, ErrorMessage = "Model must be at least 2 characters.")]
        [MaxLength(50, ErrorMessage = "Model must be at most 50 characters.")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Year is required.")]
        [Range(1900, 2025, ErrorMessage = "Year must be between 1900 and 2025.")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0, 1000000, ErrorMessage = "Price must be between 0 and 1000000.")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Km is required.")]
        [Range(0, 1000000, ErrorMessage = "Km must be between 0 and 1000000.")]
        public int Km { get; set; }

        [Required(ErrorMessage = "Color is required.")]
        [RegularExpression(@"^5\d{2}\s?\d{3}\s?\d{2}\s?\d{2}$", ErrorMessage = "Phone number must be in the format 5xx xxx xx xx.")]
        [StringLength(10, ErrorMessage = "User phone number must be 10 characters.")]
        public string LastUserPhone { get; set; }
    }
}