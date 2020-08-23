using Marketplace.Domain.Interfaces.Services;
using System;

namespace Marketplace.Domain.Entities.Vehicles
{
    public class Truck : Vehicle
    {
        private Truck() { }

        public Truck(
            int km, 
            string licensePlate, 
            string brand,
            string model,
            ITruckUniquenessChecker uniquenessTruckChecker)
        {
            uniquenessTruckChecker = uniquenessTruckChecker ?? throw new Exception($"Invalid {nameof(uniquenessTruckChecker)}");

            if (!uniquenessTruckChecker.IsLicensePlateUnique(licensePlate))
                throw new Exception("Invalid checker");

            if (km < 0)
                throw new Exception("Invalid checker");

            Km = km;
            LicensePlate = new LicensePlate(licensePlate);
            Brand = brand;
            Model = model;
            CreatedAt = DateTime.Now;
        }

        public int Km { get; set; }
        public LicensePlate LicensePlate { get; private set; }
    }
}
