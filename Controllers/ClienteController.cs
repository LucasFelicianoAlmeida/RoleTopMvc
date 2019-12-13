using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleTopMvc.Repositories;
using RoleTopMvc.ViewModels;
using RoleTopMvc.Enums;
using System;
using System.Collections.Generic;
using RoleTopMvc.Models;

namespace RoleTopMvc.Controllers
{
    public class ClienteController : AbstractController
    {

        private AgendamentoRepository agendamentoRepository = new AgendamentoRepository();

        [HttpGet]
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

            if(cliente != null)
                {
                    if(cliente.Senha.Equals(senha))
                    {
                        switch(cliente.TipoUsuario){
                            case (uint) TiposUsuario.CLIENTE:
                                HttpContext.Session.SetString(SESSION_CLIENTE_EMAIL, usuario);
                                HttpContext.Session.SetString(SESSION_CLIENTE_NOME, cliente.Nome);
                                HttpContext.Session.SetString(SESSION_CLIENTE_TIPO, cliente.TipoUsuario.ToString());
                                
                                return RedirectToAction("Historico","Cliente");
                            
                            default:
                                HttpContext.Session.SetString(SESSION_CLIENTE_EMAIL, usuario);
                                HttpContext.Session.SetString(SESSION_CLIENTE_NOME, cliente.Nome);
                                HttpContext.Session.SetString(SESSION_CLIENTE_TIPO, cliente.TipoUsuario.ToString());
                                
                                return RedirectToAction("Dashboard","Administrador");
                            
                        }
                    }
                    else 
                    {
                        return View("Erro", new RespostaViewModel("Senha incorreta"));
                    }

                } 
                else
                {
                    return View("Erro", new RespostaViewModel($"Usuário {usuario} não encontrado"));
                }

            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.StackTrace);
                return View("Erro", new RespostaViewModel());
            }
                   
               
           }
           public IActionResult Logoff()
        {
            HttpContext.Session.Remove(SESSION_CLIENTE_EMAIL);
            HttpContext.Session.Remove(SESSION_CLIENTE_NOME);
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");

       }

       public IActionResult Historico ()
        {
            var emailCliente = ObterUsuarioSession();
            var pedidosCliente = agendamentoRepository.ObteTodosPorCliente(emailCliente);

            return View(new HistoricoViewModel()
            {
                Agendamento = pedidosCliente,
                NomeView = "Histórico",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()
            });
        }

        
    }
}

   
