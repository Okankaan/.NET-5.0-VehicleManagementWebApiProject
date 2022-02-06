using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMEntities.VMDtos
{
    public class UserDto:BaseDto
    {
        public string Name { get; set; }
        public string EMail { get; set; }
    }
}
