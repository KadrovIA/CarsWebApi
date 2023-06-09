using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface IManufacturerRepository
    {
        ICollection<Manufacturer> GetAllManufacturers();
        bool Add(Manufacturer newManufacturer);
        public Manufacturer GetManufacturer(int id);
        bool Delete(Manufacturer manufacturer);
        bool ManufacturerExists(int id);
    }
}
