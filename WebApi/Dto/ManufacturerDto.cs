using System.ComponentModel.DataAnnotations;

namespace WebApi.Dto
{
    public class ManufacturerDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50), MinLength(2)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50), MinLength(2)]
        public string Country { get; set; }
    }
}
