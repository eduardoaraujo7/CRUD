using ProcTeste.BLL;
using ProcTeste.DTO;
using ProcTeste.Web.Views;
using System.Web.Mvc;

namespace ProcTeste.Web.Controllers
{
    public class HomeController : Controller

    {
        UsuarioBLL usuarioBLL;
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(UsuarioViewModel usuarioViewModel)
        {
            if (ModelState.IsValid)
            {
                usuarioBLL = new UsuarioBLL();
                var usuarioDTO = new Usuario()
                {
                    Nome = usuarioViewModel.Nome,
                    Login = usuarioViewModel.Login,
                    Senha = usuarioViewModel.Senha,
                    Endereco = usuarioViewModel.Endereco
                };

                usuarioBLL.InserirUsuario(usuarioDTO);
                return Redirect("Main");   
            }
            return Redirect("Index");
        }

        public ActionResult Main()
        {
            return View("Main");
        }
    }
}