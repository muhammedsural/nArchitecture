using Application.Features.Brands.Commands.CreateBrand;
using Application.Features.Brands.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Brands.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Brand, CreatedBrandDto>().ReverseMap(); // Brand ile CreatedBrandDto ile karşılaşırsan bunları maple tersinirde olabilir.
            CreateMap<Brand, CreateBrandCommand>().ReverseMap(); // Brand ile CreateBrandCommand ile karşılaşırsan bunları maple tersinirde olabilir.
        }
    }
}
