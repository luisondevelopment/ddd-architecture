namespace Marketplace.Domain.Entities.Vehicles
{
    public class Vehicle : Entity
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Colour { get; set; }
        public bool UniqueOwner { get; set; }
        public bool HasExtraKey { get; set; }
        public GearBoxType GearBoxType { get; private set;}
        public FuelType FuelType { get; private set; }
    }
}
