using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleTopMvc.Enums;
using RoleTopMvc.Models;
using RoleTopMvc.Repositories;
using RoleTopMvc.ViewModels;

namespace RoleTopMvc.Controllers
{
        public class CadastroController : AbstractController
        {
            ClienteRepository clienteRepository = new ClienteRepository();
            [HttpGet]
            public IActionResult Index()
            {
                return View( new BaseViewModel()
                {
                    NomeView = "Cadastro",
                    UsuarioEmail = ObterUsuarioSession(),
                    UsuarioNome = ObterUsuarioNomeSession()
                });
            }

            [HttpPost]
            public IActionResult CadastrarCliente(IFormCollection form)
            {
                ViewData["Action"] = "Cadastro";

                try
                {
                    Cliente cliente = new Cliente(
                        form["nome"],
                        form["email"],
                        form["senha"],
                        form["endereco"],
                        form["telefone"]  
                    );
                    cliente.TipoUsuario = (uint) TiposUsuario.CLIENTE;
                    clienteRepository.Inserir(cliente);

                    return View("Sucesso",  new RespostaViewModel()
                    {
                        NomeView="Cadastro",
                        UsuarioEmail = ObterUsuarioSession(),
                        UsuarioNome = ObterUsuarioNomeSession()

                    });  
                }
                catch(Exception e)
                {
                    System.Console.WriteLine(e.StackTrace);
                    return View("Erro", new RespostaViewModel()
                    {
                        NomeView = "Cadastro",
                        UsuarioEmail = ObterUsuarioSession(),
                        UsuarioNome = ObterUsuarioNomeSession()
                    });
            }
        }
    }
}