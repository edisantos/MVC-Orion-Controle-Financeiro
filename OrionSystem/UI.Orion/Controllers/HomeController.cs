using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Orion.BLL;
using Orion.DAL;
using Microsoft.AspNet.Identity;

namespace UI.Orion.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult CadastroEntrada()
        {
            if(User.Identity.IsAuthenticated)
            {
               //ViewBag.UsuarioLogado = User.Identity.GetUserId();


            }
            return View();
        }
        [HttpPost]
        [Authorize]
        public ActionResult CadastroEntrada([Bind(Include = "Id,Date,Nome,TipoEntrada,Valor,Comentario")]EntradaConta model)
        {
            try
            {
                Entrada db = new Entrada();
                //ViewBag.Usuario = User.Identity.GetUserId();
                model.id = User.Identity.GetUserId();
                if(ModelState.IsValid)
                {
                    db.RegistrarEntrada(model);
                    ModelState.Clear();
                    ViewBag.MessageSuccess = "Registro feito com sucesso";
                }
            }
            catch (Exception ex)
            {

                ViewBag.MessageError = "Erro no registro " + ex.Message;
            }
            

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}