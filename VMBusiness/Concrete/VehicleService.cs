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

        public async Task<IDataResult<List<VehicleDto>>> GetVehicleListByBrandModel(string brandName, string modelName)
        {
            return new SuccessDataResult<List<VehicleDto>>(_mapper.Map<List<VehicleDto>>(await _vehicleDal.GetVehicleListByBrandModel(brandName, modelName)), ConstantMessages.BrandListedMessage);
        }
    }
}
