using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Model;
using Services.Services;

namespace Ejercicio.Controllers
{
    public class PostController : Controller
    {
        private readonly InterfaceServicePosts _contextUser;


        public PostController(InterfaceServicePosts _contextUse)
        {
            _contextUser = _contextUse;
        }

        // GET: PostController
        [HttpGet]
        public async Task<ActionResult> Index(string text, string message)
        {
            ViewBag.Message = message;

            List<Post> lista = await _contextUser.GetListPosts();
            if (text !=null)
            {
                List<Post> listaAux = lista.Where(x => x.Title.Contains(text) || x.Body.Contains(text)).ToList();
                return View(listaAux);
            }
            return View(lista);
        }
        // POST: PostController
        [HttpPost]
        public ActionResult Index(string text)
        {
            try
            {
                if (text ==null)
                {
                    throw new Exception("Debe ingresar texto");
                }
                return RedirectToAction(nameof(Index), new { text = text});


            }
            catch (Exception ex) {
                return RedirectToAction(nameof(Index), new { message=ex.Message});
            }
        }

        [HttpPost]
        public ActionResult Recargar()
        {
            return RedirectToAction(nameof(Index), new { message ="Ingrese texto a Filtrar" });
        }
    }
}
