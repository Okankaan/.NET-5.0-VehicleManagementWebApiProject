using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMEntities.VMDBEntities
{
    public class Brand : BaseEntity
    {
        [StringLength(100)]
        [Required]
        public string Name { get; set; }

        public ICollection<Model> Models { get; set; }
    }
}
