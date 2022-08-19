using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public interface InterfaceServicePosts
    {
        public Task<List<Models.Model.Post>> GetListPosts();
    }
}
