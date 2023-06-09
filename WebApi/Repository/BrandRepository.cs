using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Repository
{
    public class BrandRepository : IBrandRepository
    {
        private readonly DataContext _context;

        public BrandRepository(DataContext context)
        {
            _context = context;
        }
        public Brand GetBrand(int id)
        {
            return _context.Brands.Include(b => b.Manufacturer).Where(b => b.Id == id).FirstOrDefault();
        }
        public bool Add(Brand newBrand)
        {

            _context.Entry(newBrand).State = EntityState.Unchanged;
            _context.Add(newBrand);
            return Save();
        }
        public ICollection<Manufacturer> GetAllManufacturers()
        {
            return _context.Manufacturers.ToList();
        }
        public bool ManufacturerExists(int id)
        {
            return _context.Manufacturers.Any(b => b.Id == id);
        }
        public bool BrandExists(int id)
        {
            return _context.Brands.Any(b => b.Id == id);
        }

        public bool Delete(Brand brand)
        {
            _context.Remove(brand);
            return Save();
        }

        public ICollection<Brand> GetAllBrandsByManufacturer(int id)
        {
            return _context.Brands.Include(b => b.Manufacturer).Where(b => b.Manufacturer.Id == id).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }
    }
}
