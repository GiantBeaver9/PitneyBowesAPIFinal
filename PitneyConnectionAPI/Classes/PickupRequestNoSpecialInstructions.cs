using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitneyBowesPickup
{
    internal class PickupRequestNoSpecialInstructions
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
        public PickUpOptions? PickUpOptions { get; set; }
    }
}
