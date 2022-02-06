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
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleDal _vehicleDal;
        public VehicleService(IVehicleDal vehicleDal)
        {
            _vehicleDal = vehicleDal;
        }

        public async Task<IResult> Add(Vehicle vehicle)
        {
            //var result = CheckIfVehicleExist(vehicle);

            //if (result.Result.Success)
            //{
            //    return new ErrorResult(ConstantMessages.RecordAlreadyExist);
            //}

            await _vehicleDal.Add(vehicle);

            return new SuccessResult(ConstantMessages.VehicleAdded);
        }

        //private async Task<Result> CheckIfVehicleExist(Vehicle vehicle)
        //{
        //    return await _vehicleDal.CheckIfVehicleExist(vehicle);
        //}

        public Task<IResult> Delete(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<List<Vehicle>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Update(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }
    }
}
