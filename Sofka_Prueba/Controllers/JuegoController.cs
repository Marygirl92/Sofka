using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibSofka_Prueba.Clases;
using LibSofka_Prueba.Model;
namespace Sofka_Prueba.Controllers
{
    public class JuegoController : Controller
    {
        // GET: Juego
        public ActionResult Index(String message="")
        {
            ViewBag.message = message;
            return View();
        }
        [HttpPost]
        public ActionResult Profile(String user,String contrasenia)
        {
            Player player = new PlayerDb().Login(new User(user, contrasenia));
            if(player == null)
            {
                return RedirectToAction("Index","Juego",new { message = "No se Logro iniciar Session" });
            }
            else
            {
                return View(player);
            }
            
        }
        
    }
}
