using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMEntities.JWT
{
    public class JwtCache
    {
        public JwtAuthResult Token { get; set; }
        public bool isActive { get; set; } 
    }
}
