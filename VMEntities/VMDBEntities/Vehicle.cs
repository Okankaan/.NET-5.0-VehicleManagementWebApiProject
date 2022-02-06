using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMEntities.VMDBEntities
{
    public class Vehicle : BaseEntity
    {
        public decimal Price { get; set; }

        [ForeignKey("ModelId")]
        public virtual Model Model { get; set; }
        public long ModelId { get; set; }

        [ForeignKey("ColorId")]
        public virtual Color Color { get; set; }
        public long ColorId { get; set; }
        
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public long UserId { get; set; }
    }
}
