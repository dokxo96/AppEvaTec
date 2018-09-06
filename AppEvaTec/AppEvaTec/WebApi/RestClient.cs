using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppEvaTec.WebApi
{
    public class RestClient
    {
        public  async Task<T> Get<T>(string url)
        {
            try
            {
                HttpClient cliente = new HttpClient();
                var response = await cliente.GetAsync(url);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonstring = await response.Content.ReadAsStringAsync();
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonstring);
                }
                else
                {
                    var jsonstring = await response.Content.ReadAsStringAsync();
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonstring);
                }
            }
            catch(Exception ev)
            {
                
            }


            return default(T);
        }

    }
}
