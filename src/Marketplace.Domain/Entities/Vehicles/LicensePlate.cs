namespace Marketplace.Domain.Entities.Vehicles
{
    public class LicensePlate : ValueObject
    {
        public LicensePlate(string value)
        {
            Value = value;
        }

        private readonly string Value;

        public static implicit operator string(LicensePlate licensePlate)
        {
            return licensePlate.Value;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
