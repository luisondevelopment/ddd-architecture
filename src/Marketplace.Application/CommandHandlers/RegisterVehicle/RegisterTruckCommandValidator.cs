using FluentValidation;

namespace Marketplace.Application.CommandHandlers.RegisterVehicle
{
    public class RegisterTruckCommandValidator : AbstractValidator<RegisterTruckCommand>
    {
        public RegisterTruckCommandValidator()
        {
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
