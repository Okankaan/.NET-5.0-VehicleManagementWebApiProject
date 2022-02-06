using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMEntities.VMDBEntities;

namespace VMEntities.VMDtos
{
    public class ModelBrandDto:BaseDto
    {
        public string BrandName { get; set; }
        public List<ModelDto> Models { get; set; }

    }
}
