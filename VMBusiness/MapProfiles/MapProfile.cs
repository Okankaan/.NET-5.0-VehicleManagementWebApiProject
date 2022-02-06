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
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            //CreateMap<BrandDto, Brand>();
            CreateMap<Brand, BrandDto>();
        }
    }
}
