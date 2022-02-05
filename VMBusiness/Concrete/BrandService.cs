using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMBusiness.Abstract;
using VMDataAccess.Abstract.Repositories;
using VMEntities.VMDBEntities;
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

        public Task<IDataResult<List<Brand>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Update(Brand brand)
        {
            throw new NotImplementedException();
        }
    }
}
