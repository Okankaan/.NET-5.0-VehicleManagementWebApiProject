using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMEntities.VMDBEntities
{
    public class UserVehicle:BaseEntity
    {
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public int UserId { get; set; }

        [ForeignKey("VehicleId")]
        public virtual Vehicle Vehicle { get; set; }
        public int VehicleId { get; set; }
    }
}
