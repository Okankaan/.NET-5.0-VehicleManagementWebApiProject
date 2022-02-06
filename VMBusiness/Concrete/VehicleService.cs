using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMBusiness.Abstract;
using VMBusiness.Constants;
using VMDataAccess.Abstract.Repositories;
using VMEntities.VMDBEntities;
using VMEntities.VMDtos;
using VMEntities.VMDtos.ReturnResultEntities;
using VMEntities.VMDtos.ReturnResultEntities.Abstract;

namespace VMBusiness.Concrete
{
    public class VehicleService : IVehicleService
    {
        private readonly IMapper _mapper;
        private readonly IVehicleDal _vehicleDal;
        public VehicleService(IVehicleDal vehicleDal, IMapper mapper)
        {
            _vehicleDal = vehicleDal;
            _mapper = mapper;
        }

        public async Task<IResult> Add(VehicleInsertUpdateDto vehicle)
        {
            //var result = CheckIfVehicleExist(vehicle);

            //if (result.Result.Success)
            //{
            //    return new ErrorResult(ConstantMessages.RecordAlreadyExist);
            //}


            await _vehicleDal.Add(_mapper.Map<Vehicle>(vehicle));

            return new SuccessResult(ConstantMessages.VehicleAdded);
        }

        public async Task<IResult> Delete(long vehicleId)
        {
            var vehicle = await CheckIfVehicleExist(vehicleId);

            if (vehicle.Success)
            {
                await _vehicleDal.Delete(vehicle.Data);
                return new SuccessResult(ConstantMessages.VehicleDeleted);
            }
            return new ErrorDataResult<Vehicle>(ConstantMessages.VehicleIsNotExist);
        }

        public Task<IDataResult<List<Vehicle>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> Update(VehicleInsertUpdateDto vehicle)
        {
            if( (await CheckIfVehicleExist(vehicle.Id)).Success)
            {
                await _vehicleDal.Update(_mapper.Map<Vehicle>(vehicle));
                return new SuccessResult(ConstantMessages.VehicleUpdated);
            }
            return new ErrorDataResult<Vehicle>(ConstantMessages.VehicleIsNotExist);

        }

        private async Task<IDataResult<Vehicle>> CheckIfVehicleExist(long vehicleId)
        {
            Vehicle vehicleItem = await _vehicleDal.Get(x => x.Id == vehicleId && x.Active == true);

            if (vehicleItem != null)
                return new SuccessDataResult<Vehicle>(vehicleItem);

            return new ErrorDataResult<Vehicle>(); 
        }

        public async Task<IDataResult<List<VehicleDto>>> GetVehicleListByBrandModel(string brandName, string modelName)
        {
            return new SuccessDataResult<List<VehicleDto>>(_mapper.Map<List<VehicleDto>>(await _vehicleDal.GetVehicleListByBrandModel(brandName, modelName)), ConstantMessages.BrandListedMessage);
        }
    }
}
