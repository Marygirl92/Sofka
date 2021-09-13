using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sofka_Prueba.Models;

namespace Sofka_Prueba.Controllers
{
    public class JuegoController : Controller
    {
        Player player1;
        public JuegoController()
        {
            this.player1 = null;
        }
        // GET: Juego
        public ActionResult Index(String message="")
        {
            ViewBag.message = message;
            return View();
        }
        [HttpPost]
        public ActionResult Profile(String user,String contrasenia)
        {
            using (sofka_juegoEntities s = new sofka_juegoEntities())
            {
                 player1 = (from us in s.usuario
                               join pl in s.player
                               on us.id equals pl.usuario_id
                               where us.user_text == user
                               && us.password_name == contrasenia
                               select new Player()
                               {
                                   Id = us.id,
                                   Nombre = pl.nombre,
                                   FechaNacimiento = pl.fecha_nacimiento,
                                   MaxPoints=pl.max_points
                               }).FirstOrDefault();
                
            if(player1 == null)
            {
                return RedirectToAction("Index","Juego",new { message = "No se Logro iniciar Session" });
            }
            else
            {
                    Session["player"] = player1;
                return View(player1);
            }
            }

        }

        public ActionResult Jugar()
        {
            if (Session["player"] == null)
                return RedirectToAction("Index", "Juego");
            return View(player1);
        }
        
    }
}
