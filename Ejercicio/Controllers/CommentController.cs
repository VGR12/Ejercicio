using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Model;
using Services.Services;

namespace Ejercicio.Controllers
{
    public class CommentController : Controller
    {
        private readonly InterfaceServiceComments _context;

        public CommentController(InterfaceServiceComments _context) { 
            this._context = _context;
        }

        // GET: CommentController
        public async Task<ActionResult> Index(int idPost, string message)
        {
            ViewBag.Message=message;
            List<Comment> list = await _context.GetListComments();
            if (idPost>0) {
                list = list.Where(x=>x.PostId==idPost).ToList();
            }
            return View(list);
        }

        [HttpPost]
        // GET: CommentController
        public ActionResult Index(int idPost)
        {
            try
            {
                if (idPost < 0)
                {
                    throw new Exception("Solo se permiten las identificaciones de la tabla(columna idPost)");
                }
                return RedirectToAction(nameof(Index), new { idPost = idPost });
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Index), new { message = ex });
            }
        }

    }
}
