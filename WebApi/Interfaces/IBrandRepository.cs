using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface IBrandRepository
    {
        ICollection<Brand> GetAllBrandsByManufacturer(int id);
        ICollection<Manufacturer> GetAllManufacturers();
        bool Add(Brand newBrand);
        Brand GetBrand(int id);
        bool Delete(Brand brand);
        bool ManufacturerExists(int id);
        bool BrandExists(int id);
    }
}
