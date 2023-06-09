using AutoMapper;
using WebApi.Dto;
using WebApi.Models;

namespace WebApi.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<BrandDto, Brand>().ReverseMap();
            CreateMap<ManufacturerDto, Manufacturer>().ReverseMap();
        }
    }
}
