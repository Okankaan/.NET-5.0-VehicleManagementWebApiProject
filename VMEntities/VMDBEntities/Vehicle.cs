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

        [ForeignKey("BrandId")]
        public virtual Brand Brand { get; set; }
        public int BrandId { get; set; }

        [ForeignKey("ColorId")]
        public virtual Color Color { get; set; }
        public int ColorId { get; set; }
        
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public int UserId { get; set; }
    }
}
