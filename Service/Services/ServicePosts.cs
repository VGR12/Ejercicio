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
    public class ServicePosts : InterfaceServicePosts
    {
        public async Task<List<Post>> GetListPosts()
        {
            List<Post> listPost = new List<Post>();
            var client = new RestClient("https://jsonplaceholder.typicode.com/posts");
            var request = new RestRequest();
            var response = client.Get(request);

            if (response.IsSuccessful)
            {
                var lista = JsonConvert.DeserializeObject<List<Post>>(response.Content.ToString());
                listPost = lista;
            }

            return listPost;
        }
    }
}
