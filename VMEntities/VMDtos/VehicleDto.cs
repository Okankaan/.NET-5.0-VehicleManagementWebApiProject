using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMEntities.VMDBEntities;

namespace VMEntities.VMDtos
{
    public class VehicleDto:BaseDto
    {
        public decimal Price { get; set; }
        public ColorDto ColorDto { get; set; }
        public UserDto UserDto { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
    }
}
