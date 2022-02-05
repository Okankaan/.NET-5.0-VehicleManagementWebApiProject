using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMBusiness.Abstract;
using VMEntities.VMDBEntities;
using VMEntities.VMDtos.ReturnResultEntities.Abstract;

namespace VMBusiness.Concrete
{
    public class ModelService : IModelService
    {
        public Task<IResult> Add(Model brand)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Delete(Model brand)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<List<Model>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Update(Model brand)
        {
            throw new NotImplementedException();
        }
    }
}
