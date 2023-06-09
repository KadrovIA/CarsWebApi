namespace WebApi.Models
{
    public class Manufacturer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public ICollection<Brand>? Cars { get; set; }
    }
}
