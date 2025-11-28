using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRESTFULL.Controllers
{
    public static class PersonasController
    {
        //Post Method
       public async static Task<Models.Msg>CreatePerson(Models.Personas personas)
        {
           Models.Msg msg = new Models.Msg();
            String jsonObject = JsonConvert.SerializeObject(personas);

            StringContent content = new StringContent(jsonObject, Encoding.UTF8, "aplication/json");

            using (HttpClient client = new HttpClient())
            {

                HttpResponseMessage response = null;

                    response = await client.PostAsync("http:// 192.168.1.14/crud-php/Postpersons.php", content);

                if (response != null)
                {
                   if (response.IsSuccessStatusCode)
                    {
                        var resultado = await response.Content.ReadAsStringAsync();
                        msg = JsonConvert.DeserializeObject<Models.Msg>(resultado);
                    }
                }
            }
            return msg;
        } 
    }
}
