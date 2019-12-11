using Microsoft.AspNetCore.Mvc;
using RoleTopMvc.ViewModels;

namespace RoleTopMvc.Controllers
{
    public class EventosController : AbstractController
    {
        public IActionResult Index()
        {
            return View(new BaseViewModel
            {
                NomeView = "Index",
                UsuarioEmail = ObterUsuarioNomeSession(),
                UsuarioNome = ObterUsuarioNomeSession()
            });
        }

        
    }
}