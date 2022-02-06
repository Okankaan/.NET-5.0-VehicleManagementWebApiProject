using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VMEntities.VMDBEntities;
using VMEntities.VMDtos;
using VMEntities.VMDtos.ReturnResultEntities.Abstract;

namespace VMBusiness.Abstract
{
    public interface IBrandService
    {
        Task<IDataResult<List<BrandDto>>> GetAll();
        Task<IResult> Delete(Brand brand);
        Task<IResult> Update(Brand brand);
        Task<IResult> Add(Brand brand);
        Task<IDataResult<List<ModelBrandDto>>> GetAllModelsOfBrands();
    }
}
