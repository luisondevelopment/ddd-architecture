using FluentValidation;

namespace Marketplace.Application.CommandHandlers.RegisterVehicle.Validation
{
    public class RegisterVehicleCommandValidator : AbstractValidator<RegisterVehicleCommand>
    {
        public RegisterVehicleCommandValidator()
        {
            BrandNotNull();
            ModelNotNull();
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
