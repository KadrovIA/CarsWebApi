using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Repository
{
    public class ManufacturerRepository : IManufacturerRepository
    {
        private readonly DataContext _context;

        public ManufacturerRepository(DataContext context)
        {
            _context = context;
        }

        public bool Add(Manufacturer newManufacturer)
        {
            _context.Add(newManufacturer);
            return Save();
        }

        public bool Delete(Manufacturer manufacturer)
        {
            _context.Attach(manufacturer);
            _context.Remove(manufacturer);
            return Save();
        }

        public ICollection<Manufacturer> GetAllManufacturers()
        {
            return _context.Manufacturers.Include(m => m.Cars).ToList();
        }

        public Manufacturer GetManufacturer(int id)
        {
            return _context.Manufacturers.Include(m => m.Cars).Where(m => m.Id == id).FirstOrDefault();
        }

        public bool ManufacturerExists(int id)
        {
            return _context.Manufacturers.Any(m => m.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }
    }
}
