using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using PitneyBowesPickup;

namespace PitneyBowesPickupS
{
    internal class Request
    {
        private readonly string url = "/v1/pickups/schedule";
        public async Task<PickUpResponse> PickUpRequest(HttpClient client, PickupRequest pickupRequest, String URL)
        {
            var response = await client.PostAsJsonAsync(URL + url, pickupRequest);
            var JsonReturnValue = await response.Content.ReadAsStringAsync();
            var json = JsonSerializer.Deserialize<PickUpResponse>(JsonReturnValue);
            if(json != null)
                return json;
            return new PickUpResponse();
        }
        public async Task<PickUpResponse> PickUpRequest(HttpClient client, PickupRequestNoSpecialInstructions pickupRequest, String URL)
        {
            var response = await client.PostAsJsonAsync(URL + url, pickupRequest);
            var JsonReturnValue = await response.Content.ReadAsStringAsync();
            var json = JsonSerializer.Deserialize<PickUpResponse>(JsonReturnValue);
            if( json != null)
                return json;
            return new PickUpResponse();
        }
    }
}
