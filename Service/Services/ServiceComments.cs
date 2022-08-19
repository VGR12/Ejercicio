using Models.Model;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ServiceComments : InterfaceServiceComments
    {
        public async Task<List<Comment>> GetListComments()
        {
            List<Comment> comments = new List<Comment>();
            var client = new RestClient("https://jsonplaceholder.typicode.com/comments");
            var request = new RestRequest();
            var response = client.Get(request);

            if (response.IsSuccessful)
            {
                var lista = JsonConvert.DeserializeObject<List<Comment>>(response.Content.ToString());
                comments = lista;
            }

            return comments;
        }
    }
}
