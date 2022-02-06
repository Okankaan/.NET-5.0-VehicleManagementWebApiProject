using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMEntities.VMDBEntities;
using VMEntities.VMDtos.ReturnResultEntities;

namespace VMDataAccess.Abstract.Repositories
{
    public interface IVehicleDal : IBaseEntityRepository<Vehicle>
    {
        Task<IList<Vehicle>> GetVehicleListByBrandModel(string brandName, string modelName);
    }
}
