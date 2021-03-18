
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;

namespace Facturacion
{
    public static class GetApiSatrack
    {
        public  static string GetToken()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://securityprovider.satrack.com:8080/auth/realms/satrack-base/protocol/openid-connect/token");

                    var nvc = new List<KeyValuePair<string, string>>();
                    nvc.Add(new KeyValuePair<string, string>("client_id", "external-client-transportesgandur01")); 
                    nvc.Add(new KeyValuePair<string, string>("client_secret", "3d32c378-67a0-4749-b656-102cc04b85a7"));
                    nvc.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));

                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "");

                    request.Content = new FormUrlEncodedContent(nvc);

                   var response = client.SendAsync(request);
                    
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var r = response.Result.Content.ReadAsStringAsync();

                        TokenResult token = JsonConvert.DeserializeObject<TokenResult>(r.Result);

                        return token.access_token;
                    }
                
                }

                return null;


            }
            catch (Exception ex)
            {
                return null;

                throw;
            }
        }


        public class TokenResult
        {
            public string access_token { get; set; }

        }

    }
}
