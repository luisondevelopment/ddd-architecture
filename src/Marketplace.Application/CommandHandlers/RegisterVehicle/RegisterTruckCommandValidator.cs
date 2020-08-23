using FluentValidation;

namespace Marketplace.Application.CommandHandlers.RegisterVehicle
{
    public class RegisterTruckCommandValidator : AbstractValidator<RegisterTruckCommand>
    {
        public RegisterTruckCommandValidator()
        {
            KmGreatherThanZero();
            LicensePlateNotEmpty();
            BrandNotNull();
            ModelNotNull();
        }

        public void KmGreatherThanZero()
        {
            RuleFor(x => x.Km)
                .GreaterThan(-1);
        }

        public void LicensePlateNotEmpty()
        {
            RuleFor(x => x.LicensePlate)
                .NotEmpty();
        }


        public void BrandNotNull()
        {
            RuleFor(x => x.Brand)
                .NotEmpty();
        }

        public void ModelNotNull()
        {
            RuleFor(x => x.Model)
                .NotEmpty();
        }
    }
}
