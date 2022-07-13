using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PitneyBowesPickup
{

    ///v1/pickups/{pickupId}/cancel
    internal class Cancel
    {
        private readonly string url = "/v1/pickups/";
        private readonly string url2 = "/cancel";
        public async Task<CancelRequest>? CancelPickUpRequest(HttpClient client, PickupRequest CancelRequest, String URL, String RequestNumber)
        {
            StringBuilder fullURL = new StringBuilder(URL);
            fullURL.Append(new StringBuilder(url)).Append(new StringBuilder(RequestNumber)).Append(new StringBuilder(url2));
            var response = await client.PostAsync(fullURL.ToString(), new StringContent(""));
            var TransformResponse = await response.Content.ReadAsStringAsync();
            var CancelResponse = JsonSerializer.Deserialize<CancelRequest>(TransformResponse);
            if(CancelResponse != null)
                return CancelResponse;
            return new CancelRequest();
        }

    }
}
