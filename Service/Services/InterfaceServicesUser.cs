using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Services.Services
{
    public interface InterfaceServicesUser
    {
        public Task<List<Models.Model.User>> GetListUser();
        public Task<Models.Model.User> GetUser(int id);    

    }
}
