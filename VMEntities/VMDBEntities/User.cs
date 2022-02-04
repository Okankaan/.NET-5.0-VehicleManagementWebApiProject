using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMEntities.VMDBEntities
{
    public class User:BaseEntity
    {
        [StringLength(150)]
        [Required]
        public string Name { get; set; }

        [StringLength(150)]
        [Required]
        public string Password { get; set; }

        [StringLength(150)]
        [Required]
        public string EMail { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<UserVehicle> UserVehicles { get; set; }

    }
}
