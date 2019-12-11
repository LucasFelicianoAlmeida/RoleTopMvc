using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleTopMvc.ViewModels;
using System;

namespace RoleTopMvc.Controllers
{
    public class AgendamentoController : AbstractController
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View( new BaseViewModel()
                {
                    NomeView = "Agendamento",
                    UsuarioEmail = ObterUsuarioSession(),
                    UsuarioNome = ObterUsuarioNomeSession()
                }
            );
        }

        public IActionResult AgendarEventos(IFormCollection form)
        {
            try
        }


    }
}