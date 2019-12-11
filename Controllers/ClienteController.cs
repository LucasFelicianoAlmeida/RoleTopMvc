using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleTopMvc.Repositories;
using RoleTopMvc.ViewModels;
using RoleTopMvc.Enums;
using System;

namespace RoleTopMvc.Controllers
{
    public class ClienteController : AbstractController
    {
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
                                
                                return RedirectToAction("Index","Home");
                            
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


       }
    }

   
