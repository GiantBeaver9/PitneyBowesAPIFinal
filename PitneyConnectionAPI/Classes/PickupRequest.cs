using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitneyBowesPickup
{
    internal class PickupRequest
    {
        public PickUpAddress? Address { get; set; }
        public string? Carrier { get; set; } = "USPS";
        public PickUpSummary[]? pickupSummary { get; set; }
        public string? Reference { get; set; }
        /// <summary>
        /// Front Door
        /// Back Door
        /// Side Door
        /// Knock on Door/Ring Bell
        /// Mail Room
        /// Office
        /// Reception
        /// In/At Mailbox
        /// Other
        /// </summary>
        public string? PackageLocation { get; set; }
        public string? SpecialInstructions { get; set; }
        public PickUpOptions? PickUpOptions {get;set;}
    }

    public class PickUpAddress
    {
        public string[]? AddressLines { get; set; }
        public string? CityTown { get; set; }
        public string? StateProvince { get; set; }
        public string? PostalCode { get; set; }
        public string? CountryCode { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public bool IsResidential { get; set; }
        public string? DeliveryPoint { get; set; }
        public string? CarrierRoute { get; set; }
        public string? TaxID { get; set; }
        //public string Status { get; set; }
    }
    public class PickUpSummary
    {
        public bool ReturnShipment { get; set; }
        public TotalWeight? TotalWeight { get; set; }
        public string? ServiceID {get;set;}
        public int Count { get; set; }

    }
    public class TotalWeight
    {
        public float Weight { get; set; }
        public string? UnitOfMeasurement { get; set; }

    }
    public class PickUpOptions
    {
        public string? Name { get; set; }
        public string? Value { get; set; }
    }
}
