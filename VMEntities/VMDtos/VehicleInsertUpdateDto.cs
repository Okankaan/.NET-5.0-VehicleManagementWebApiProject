using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMEntities.VMDtos
{
    public class VehicleInsertUpdateDto : BaseDto
    {
        public decimal Price { get; set; }
        public long ModelId { get; set; }
        public long ColorId { get; set; }
        public long UserId { get; set; }
    }
}
