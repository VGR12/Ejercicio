using Ejercicio.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Models.Model;
using Services.Services;

namespace Ejercicio.Controllers
{
    public class UserController : Controller
    {
        private readonly InterfaceServicesUser _contextUser;


        public UserController(InterfaceServicesUser _contextUse)
        {
            _contextUser = _contextUse;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetUsers()
        {
            List<User>list= await _contextUser.GetListUser();
            return View(list);
        }

        public async Task<IActionResult> DetailsAddress(int id)
        {
            User user = await _contextUser.GetUser(id);
            Address address = user.Address;
            Geo geo = address.Geo;
            ViewBag.Geo = geo;
            return View(address);
        }

        public async Task<IActionResult> DetailsCompany(int id)
        {
            User user = await _contextUser.GetUser(id);
            Company company = user.Company;
            return View(company);
        }

    }
}