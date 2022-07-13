using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace PitneyConnectionAPI.Methods
{
    public class OpenConnection
    {
        private int TransactionID { get; set; } = 0;
        private static readonly string _requestUrl = "https://shipping-api-sandbox.pitneybowes.com/oauth/token";
        private static readonly string _key = "OG8MuZosUS3FhM2utv8N3QTvy6vhQHFr"; //Put in Maersk Key here to connect to Pitney Bowes
        private static readonly string _secret = "WDKrK7X0GBZNNmAR"; //Put in Maersk Secret here to connect to Pitney Bowes
        internal static PitneyLoginResponse _response = new PitneyLoginResponse();
        internal static async Task ConnectToPitney(HttpClient client)
        {
            var request = new HttpRequestMessage(new HttpMethod("Post"), "https://shipping-api-sandbox.pitneybowes.com/oauth/token");
            request.Headers.TryAddWithoutValidation("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(_key + ':' + _secret)));

            request.Content = new StringContent("grant_type=client_credentials");
            request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");
            var response = await client.SendAsync(request);
            var JsonResponse = await response.Content.ReadAsStringAsync();
            var LoginResponse = JsonSerializer.Deserialize<PitneyLoginResponse>(JsonResponse);
            if (LoginResponse != null)
                _response = LoginResponse;
        }



        public static void ConfigureClient(HttpClient client, int transactionID)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            if (_response.access_token is not null)
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _response.access_token);
            }
            client.DefaultRequestHeaders.Add("Content-Type", "application/json");
            client.DefaultRequestHeaders.Add("X-PB-TransactionId", transactionID.ToString());
            client.DefaultRequestHeaders.Add("X-PB-UnifiedErrorStructure", "true");
            transactionID = transactionID++;
        }
    }
    internal class PitneyLoginResponse
    {
        public string? access_token { get; set; }
        public string? tokenType { get; set; }
        public string? issuedAt { get; set; }
        public string? expiresIn { get; set; }
        public string? clientID { get; set; }
        public string? org { get; set; }
    }
}

