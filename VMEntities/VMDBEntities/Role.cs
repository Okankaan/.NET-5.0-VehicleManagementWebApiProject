using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMEntities.VMDBEntities
{
    public class Role : BaseEntity
    {
        [StringLength(100)]
        [Required]
        public string Name { get; set; }
        public ICollection<AuthRole> AuthRoles { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
