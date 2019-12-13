using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleTopMvc.ViewModels;
using RoleTopMvc.Repositories;
using System;
using RoleTopMvc.Models;

namespace RoleTopMvc.Controllers
{
    public class AgendamentoController : AbstractController
    {
        
        ClienteRepository clienteRepository = new ClienteRepository();
        AgendamentoRepository agendamentoRepository = new AgendamentoRepository();
        public IActionResult Index()
        {
            AgendamentoViewModel avm = new AgendamentoViewModel();
            
            
            var usuarioLogado = ObterUsuarioSession(); //OBTEM A SESSAO DO USUARIO 
            var nomeUsuarioLogado = ObterUsuarioNomeSession();

            if(!string.IsNullOrEmpty(usuarioLogado)) //SE O USUARIO LOGADO NAO É VAZIO OU NULO 
            {
                avm.UsuarioEmail = usuarioLogado;
            }

            var clienteLogado = clienteRepository.ObterPor(usuarioLogado);
            if(clienteLogado !=null)
            {
                avm.NomeUsuario = nomeUsuarioLogado;
                avm.Cliente = clienteLogado; 
            }

            avm.NomeView = "Agendamento";
            avm.UsuarioEmail = usuarioLogado;
            avm.UsuarioNome = nomeUsuarioLogado;            
            return View(avm);
        }
        
        [HttpPost]
         public IActionResult AgendarEventos(IFormCollection form)
         {
             Agendamento agendamento = new Agendamento();
             
                agendamento.NomeEvento = form["eventos"];
                agendamento.DataDoEvento = DateTime.Parse(form["datadoevento"]);

                  
             Cliente cliente = new Cliente ()
             {
                Nome = form["nome"],
                Endereco = form["endereco"],
                Telefone = form["telefone"],
                Email = form["email"],
                
             };

             agendamento.Cliente = cliente;

             agendamento.DataDoEvento = DateTime.Now;

             if (agendamentoRepository.Inserir (agendamento)) {
                return View ("Sucesso", new RespostaViewModel()
                {
                    NomeView = "Agendamento",
                    UsuarioEmail = ObterUsuarioSession(),
                    UsuarioNome = ObterUsuarioNomeSession()
                    
                });
            } else {
                return View ("Erro", new RespostaViewModel()
                {
                    NomeView = "Agendamento",
                    UsuarioEmail = ObterUsuarioSession(),
                    UsuarioNome = ObterUsuarioNomeSession()
                });
            }
        }


                       
    }


 }
