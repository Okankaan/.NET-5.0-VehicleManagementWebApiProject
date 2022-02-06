using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMEntities.VMDBEntities;
using VMEntities.VMDtos;
using VMEntities.VMDtos.ReturnResultEntities.Abstract;

namespace VMBusiness.Abstract
{
    public interface IVehicleService
    {
        Task<IDataResult<List<Vehicle>>> GetAll();
        Task<IResult> Delete(Vehicle vehicle);
        Task<IResult> Update(Vehicle vehicle);
        Task<IResult> Add(VehicleInsertUpdateDto vehicle);
        Task<IDataResult<List<VehicleDto>>> GetVehicleListByBrandModel(string brandName, string modelName);
    }
}
