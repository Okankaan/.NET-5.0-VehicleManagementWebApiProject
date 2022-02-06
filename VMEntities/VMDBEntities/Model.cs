using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMEntities.VMDBEntities
{
    public class Model : BaseEntity
    {
        [StringLength(100)]
        [Required]
        public string Name { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; }

        [ForeignKey("BrandId")]
        public virtual Brand Brand { get; set; }
        public long BrandId { get; set; }
    }
}
