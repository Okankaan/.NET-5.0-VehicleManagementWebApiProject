using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMEntities.VMDBEntities;

namespace VMDataAccess.Abstract.Repositories
{
    public interface IBrandDal : IBaseEntityRepository<Brand>
    {
         Task<List<Brand>> GetAllModelsOfBrands();
    }
}
