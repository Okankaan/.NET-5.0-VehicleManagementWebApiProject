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
    public class BrandService : IBrandService
    {
        private readonly IBrandDal _brandDal;
        public BrandService(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public async Task<IResult> Add(Brand brand)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Delete(Brand brand)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<List<Brand>>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(await _brandDal.GetAll(), ConstantMessages.BrandListedMessage);
        }

        public Task<IResult> Update(Brand brand)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<List<Brand>>> GetAllModelsOfBrands()
        {
            return new SuccessDataResult<List<Brand>>(await _brandDal.GetAllModelsOfBrands(), ConstantMessages.BrandListedMessage);
        }

    }
}
