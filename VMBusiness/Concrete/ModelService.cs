using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMBusiness.Abstract;
using VMBusiness.Constants;
using VMDataAccess.Abstract.Repositories;
using VMEntities.VMDBEntities;
using VMEntities.VMDtos.ReturnResultEntities;
using VMEntities.VMDtos.ReturnResultEntities.Abstract;

namespace VMBusiness.Concrete
{
    public class ModelService : IModelService
    {
        private readonly IModelDal _modelDal;
        public ModelService(IModelDal modelDal)
        {
            _modelDal = modelDal;
        }
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

        public async Task<IDataResult<List<Model>>> GetByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Model>>(await _modelDal.GetAll(x=>x.BrandId==brandId), ConstantMessages.ModelListedByBrandIdMessage);
        }

        public Task<IResult> Update(Model brand)
        {
            throw new NotImplementedException();
        }
    }
}
