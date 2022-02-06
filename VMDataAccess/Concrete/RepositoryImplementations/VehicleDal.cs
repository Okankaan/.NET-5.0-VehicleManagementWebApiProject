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
        public async Task<IList<Vehicle>> GetVehicleListByBrandModel(string brandName, string modelName)
        {
            using (VMDBContext context = new VMDBContext())
            {

                IQueryable<Vehicle> query = context.Vehicles.Include(x => x.User).Include(x => x.Color).Include(x => x.Model).Include(t => t.Model.Brand);

                if (!String.IsNullOrEmpty(brandName))
                    query = query.Where(x => x.Model.Brand.Name == brandName);
                if (!String.IsNullOrEmpty(modelName))
                    query = query.Where(t => t.Model.Name == modelName);

                query = query.Where(t => t.Active == true);

                return await query.ToListAsync();
            }
        }
    }
}
