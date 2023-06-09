using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public BrandController(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        [HttpGet("{Id:int}")]
        public IActionResult GetBrandsByManufacturer(int Id)
        {
            if (!_brandRepository.ManufacturerExists(Id))
                return NotFound();

            var brands = _mapper.Map<List<BrandDto>>(_brandRepository.GetAllBrandsByManufacturer(Id));

            return Ok(brands);
        }

        [HttpPost]
        public IActionResult AddBrand([FromBody] BrandDto addBrand)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var manufacturer = _brandRepository.GetAllManufacturers()
                               .Where(m => m.Name.Trim().ToUpper() == addBrand.Manufacturer.Name.TrimEnd().ToUpper())
                               .FirstOrDefault();

            var brandMap = _mapper.Map<Brand>(addBrand);

            if (manufacturer != null)
            {
                brandMap.ManufacturerId = manufacturer.Id;
            }


            if (!_brandRepository.Add(brandMap))
            {
                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpDelete("{Id:int}")]
        public IActionResult DeleteBrand(int Id)
        {
            if (!_brandRepository.BrandExists(Id))
                return NotFound();

            var brandToDelete = _brandRepository.GetBrand(Id);

            if (!_brandRepository.Delete(brandToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting brand");
            }

            return NoContent();
        }
    }
}
