using System;

namespace Marketplace.Api.Acceptance.Tests.Models
{
    public class Truck
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Colour { get; set; }
        public bool UniqueOwner { get; set; }
        public bool HasExtraKey { get; set; }
        public int Km { get; set; }
        public string LicensePlate { get; private set; }
        public DateTime CreatedAt { get; set; }
    }
}
