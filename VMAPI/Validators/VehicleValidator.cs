using FluentValidation;
using VMBusiness.Constants;
using VMEntities.VMDtos;

namespace VMAPI.Validators
{
    public class VehicleValidator : AbstractValidator<VehicleInsertUpdateDto>
    {
        public VehicleValidator()
        {
            RuleFor(poi => poi.Price)
                .GreaterThan(0).WithMessage(ConstantMessages.VehiclePriceWarning);
        }

    }
}
