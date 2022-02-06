using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMDataAccess.Abstract.Repositories;
using VMEntities.VMDBEntities;
using VMEntities.VMDtos.ReturnResultEntities;

namespace VMDataAccess.Concrete.RepositoryImplementations
{
    public class VehicleDal : BaseEntityRepository<Vehicle, VMDBContext>, IVehicleDal
    {
        
    }
}
