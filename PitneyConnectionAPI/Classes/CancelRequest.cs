using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitneyBowesPickup
{
    ///v1/pickups/{pickupId}/cancel
    internal class CancelRequest
    {
        public class Status
        {
            public string? status { get; set; } = "Request Unsuccessful";
        }
    }
}
