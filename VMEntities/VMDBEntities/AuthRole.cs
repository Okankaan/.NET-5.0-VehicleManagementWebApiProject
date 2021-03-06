using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMEntities.VMDBEntities
{
    public class AuthRole : BaseEntity
    {
        [ForeignKey("AuthorityId")]
        public virtual Authority Authority { get; set; }
        public long AuthorityId { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
        public long RoleId { get; set; }
        
    }
}
