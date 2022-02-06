using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMEntities.VMDBEntities;
using VMEntities.VMDtos;

namespace VMBusiness.MapProfiles
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<VehicleInsertUpdateDto, Vehicle>();
            CreateMap<Color, ColorDto>();
            CreateMap<User, UserDto>();
            CreateMap<Brand, BrandDto>();
            CreateMap<Model, ModelDto>();
            CreateMap<Brand, ModelBrandDto>().ForMember(x => x.BrandName, opt => opt.MapFrom(src => src.Name))
                .ForMember(x => x.Models, opt => opt.MapFrom(src => src.Models));

            CreateMap<Vehicle, VehicleDto>().ForMember(x => x.ColorDto, opt => opt.MapFrom(src => src.Color))
                .ForMember(x => x.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(x => x.ModelName, opt => opt.MapFrom(src => src.Model.Name))
                .ForMember(x => x.BrandName, opt => opt.MapFrom(src => src.Model.Brand.Name))
                .ForMember(x => x.UserDto, opt => opt.MapFrom(src => src.User));

        }
    }
}
