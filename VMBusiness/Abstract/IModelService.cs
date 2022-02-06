using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMEntities.VMDBEntities;
using VMEntities.VMDtos.ReturnResultEntities.Abstract;

namespace VMBusiness.Abstract
{
    public interface IModelService
    {
        Task<IDataResult<List<Model>>> GetAll();
        Task<IResult> Delete(Model brand);
        Task<IResult> Update(Model brand);
        Task<IResult> Add(Model brand);
        Task<IDataResult<List<Model>>> GetByBrandId(int brandId);
    }
}
