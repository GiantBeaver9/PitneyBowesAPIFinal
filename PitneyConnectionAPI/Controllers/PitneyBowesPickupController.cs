using Microsoft.AspNetCore.Mvc;
using PitneyBowesPickup;
using System.Text.Json;

namespace PitneyConnectionAPI.Controllers
{
    public class PitneyBowesPickupController : Controller
    {
        private readonly string URLSuffix = "/v1/pickups/schedule";
        private readonly string PitneyURL = "https://shipping-api.pitneybowes.com/shippingservices";

        [Route("PickupRequest")]
        [HttpPost(Name = "SchedulePickup")]
        internal async Task<PickUpResponse> PickUpRequest(HttpClient client, PickupRequest pickupRequest)
        {
            var response = await client.PostAsJsonAsync(PitneyURL + URLSuffix, pickupRequest);
            var JsonReturnValue = await response.Content.ReadAsStringAsync();
            var json = JsonSerializer.Deserialize<PickUpResponse>(JsonReturnValue);
            if (json != null)
                return json;
            return new PickUpResponse();
        }

        [Route("PickupRequest")]
        [HttpPost(Name = "SchedulePickup")]
        internal async Task<PickUpResponse> PickUpRequest(HttpClient client, PickupRequestNoSpecialInstructions pickupRequest)
        {
            var response = await client.PostAsJsonAsync(PitneyURL + URLSuffix, pickupRequest);
            var JsonReturnValue = await response.Content.ReadAsStringAsync();
            var json = JsonSerializer.Deserialize<PickUpResponse>(JsonReturnValue);
            if (json != null)
                return json;
            return new PickUpResponse();
        }
    }
}
