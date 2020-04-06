using FluentValidation;
using Marketplace.Application.CommandHandlers.RegisterVehicle.Validation;

namespace Marketplace.Application.CommandHandlers.RegisterVehicle
{
    public class RegisterTruckCommandValidator : AbstractValidator<RegisterTruckCommand>
    {
        public RegisterTruckCommandValidator()
        {
            Include(new RegisterVehicleCommandValidator());
            KmGreatherThanZero();
            LicensePlateNotEmpty();
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
    }
}
