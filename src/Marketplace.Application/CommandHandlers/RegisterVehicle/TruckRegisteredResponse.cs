using Marketplace.Application.Core;
using Marketplace.Domain.Entities.Vehicles;
using System;

namespace Marketplace.Application.CommandHandlers
{
    public class TruckRegisteredResponse : IResponse<Truck, TruckRegisteredResponse>
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

        public TruckRegisteredResponse Create(Truck truck)
        {
            Id = truck.Id;
            Brand = truck.Brand;
            Model = truck.Model;
            Colour = truck.Colour;
            UniqueOwner = truck.UniqueOwner;
            HasExtraKey = truck.HasExtraKey;
            Km = truck.Km;
            LicensePlate = truck.LicensePlate;
            CreatedAt = truck.CreatedAt;

            return this;
        }
    }
}
