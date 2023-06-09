using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturerController : ControllerBase
    {
        private readonly IManufacturerRepository _manufacturerRepository;
        private readonly IMapper _mapper;

        public ManufacturerController(IManufacturerRepository manufacturerRepository, IMapper mapper)
        {
            _manufacturerRepository = manufacturerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetManufacturers()
        {
            var manufacturers = _mapper.Map<List<ManufacturerDto>>(_manufacturerRepository.GetAllManufacturers());

            return Ok(manufacturers);
        }

        [HttpPost]
        public IActionResult AddManufacturer([FromBody] ManufacturerDto addManufacturer)
        {
            if (addManufacturer == null)
                return BadRequest(ModelState);

            var manufacturer = _manufacturerRepository.GetAllManufacturers()
                .Where(m => m.Name.Trim().ToUpper() == addManufacturer.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (manufacturer != null)
            {
                ModelState.AddModelError("", "Manufacturer already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var manufacturerMap = _mapper.Map<Manufacturer>(addManufacturer);

            if (!_manufacturerRepository.Add(manufacturerMap))
            {
                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpDelete("{Id:int}")]
        public IActionResult DeleteManufacturer(int Id)
        {
            if (!_manufacturerRepository.ManufacturerExists(Id))
                return NotFound();

            var manufacturerToDelete = _manufacturerRepository.GetManufacturer(Id);

            if (!_manufacturerRepository.Delete(manufacturerToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting manufacturer");
            }

            return NoContent();
        }
    }
}
