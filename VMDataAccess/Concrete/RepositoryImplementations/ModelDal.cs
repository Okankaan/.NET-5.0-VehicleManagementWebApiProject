using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMDataAccess.Abstract.Repositories;
using VMEntities.VMDBEntities;

namespace VMDataAccess.Concrete.RepositoryImplementations
{
    public class ModelDal : BaseEntityRepository<Model, VMDBContext>, IModelDal
    {
    }
}
