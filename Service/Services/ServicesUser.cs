using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;

namespace Services.Services
{
    public class ServicesUser : InterfaceServicesUser
    {
        //private string url = "https://jsonplaceholder.typicode.com/users";

        public async Task<List<User>> GetListUser()
        {
            List<User> users = new List<User>();
            var client = new RestClient("https://jsonplaceholder.typicode.com/users");
            var request=new RestRequest();
            var response=client.Get(request);

            if (response.IsSuccessful)
            {
                var lista = JsonConvert.DeserializeObject<List<User>>(response.Content.ToString());
                users = lista;
            }

            return users;
        }

        public async Task<User> GetUser(int id)
        {
            User users = new User();
            var client = new RestClient("https://jsonplaceholder.typicode.com/");
            var request = new RestRequest($"users/{id}", Method.Get);
            var content = client.ExecuteGet(request);
            if (content.IsSuccessful) {
                var userDetails = JsonConvert.DeserializeObject<User>(content.Content);
                users = userDetails;
            }
            return users;
        }
    }
}
