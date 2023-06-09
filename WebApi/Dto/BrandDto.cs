using System.ComponentModel.DataAnnotations;

namespace WebApi.Dto
{
    public class BrandDto
    {
        public int Id { get; set; }
        [Required]
        public ManufacturerDto Manufacturer { get; set; }
        [Required]
        [MaxLength(50), MinLength(2)]
        public string Name { get; set; }
        public string? Color { get; set; }
        [Required]
        public int Cost { get; set; }
    }
}
