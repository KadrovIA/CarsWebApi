namespace WebApi.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public int ManufacturerId { get; set; }
        public string Name { get; set; }
        public string? Color { get; set; }
        public int Cost { get; set; }
    }
}
