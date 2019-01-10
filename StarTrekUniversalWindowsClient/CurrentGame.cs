using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Windows.Data.Json;

namespace StarTrek
{
    public class CurrentGame
    {
        private Enterprise _enterprise;
       
        public CurrentGame()
        {

        }

        public Enterprise Enterprise => _enterprise;


        public void StartGame()
        {
            GameInit();
        }

        public void CancelGame()
        {

        }

        public void SaveGame()
        {

        }

        private async Task<HttpResponseMessage> GameInit()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //JsonValue result = JsonValue.CreateStringValue(Guid.NewGuid().ToString());


                HttpContent content = new StringContent(Guid.NewGuid().ToString(), Encoding.UTF8, "application/json");
                //HttpContent content = new StringContent(JsonConvert.SerializeObject(Guid.NewGuid()), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("http://localhost/StartrekServer/Game", content);
                return response;
            }
        }

        private void GameLoad()
        {

        }
    }
}
