using AutoMapper;

using Entities.DTO;
using Entities.Models;

namespace WebAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(p => p.Features, opt => opt.MapFrom(x => string.Join(", ", x.Genre, x.Features, x.Platform)));

            CreateMap<ProductSystemRequirements, ProductRequirementsDto>();

            CreateMap<ProductForCreationDto, Product>();

            CreateMap<RequirementsForCreationDto, ProductSystemRequirements>().ReverseMap();

            CreateMap<RequirementsForUpdateDto, ProductSystemRequirements>().ReverseMap();

            CreateMap<ProductForUpdateDto, Product>();

            CreateMap<UserForRegistrationDto, User>();

        }
    }
}
