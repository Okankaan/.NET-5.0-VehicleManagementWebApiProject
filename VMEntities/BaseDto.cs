using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMEntities
{
    public abstract class BaseDto
    {
        public long Id { get; set; }
        public bool Active { get; set; }
    }
}
