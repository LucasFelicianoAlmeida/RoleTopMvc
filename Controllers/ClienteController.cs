using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleTopMvc.Repositories;
using RoleTopMvc.ViewModels;

namespace RoleTopMvc.Controllers
{
    public class ClienteController : AbstractController
    {
      public IActionResult Index()
      {
          return View( new BaseViewModel()
          {
              NomeView = "Cliente",
              UsuarioEmail = ObterUsuarioSession(),
              UsuarioNome = ObterUsuarioNomeSession()
          });
      }  

      [HttpPost]
       public IActionResult Login(IFormCollection form)
       {
           ClienteRepository clienteRepository = new ClienteRepository();
           try
           {
               var usuario = form["email"];
               var senha = form["senha"];

               var cliente = clienteRepository.ObterPor(usuario);

               if(cliente.Senha.Equals(senha))
           }
       }
    }

   
}