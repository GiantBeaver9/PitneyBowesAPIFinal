using Microsoft.AspNetCore.Mvc;
using PitneyBowesPickup;
using System.Text;
using System.Text.Json;

namespace PitneyConnectionAPI.Controllers
{
    public class PitneyBowesCancelController : Controller
    {
        private readonly string URLSuffix = "/v1/pickups/";
        private readonly string URLSuffix2 = "/cancel";
        private readonly string PitneyURL = "https://shipping-api.pitneybowes.com/shippingservices/";

        [Route("[CancelPickup]")]
        [HttpPost(Name = "CancelScheduledPickup")]
        internal async Task<CancelRequest>? CancelPickUpRequest(HttpClient client, PickupRequest CancelRequest, String RequestNumber)
        {
            StringBuilder fullURL = new StringBuilder(PitneyURL);
            fullURL.Append(new StringBuilder(URLSuffix)).Append(new StringBuilder(RequestNumber)).Append(new StringBuilder(URLSuffix2));
            var response = await client.PostAsync(fullURL.ToString(), new StringContent(""));
            var TransformResponse = await response.Content.ReadAsStringAsync();
            var CancelResponse = JsonSerializer.Deserialize<CancelRequest>(TransformResponse);
            if (CancelResponse != null)
                return CancelResponse;
            return new CancelRequest();
        }
    }
}
