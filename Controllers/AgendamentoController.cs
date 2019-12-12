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
        EventosRepository eventoRepository = new EventosRepository();
        ClienteRepository clienteRepository = new ClienteRepository();
        AgendamentoRepository agendamentoRepository = new AgendamentoRepository();
        public IActionResult Index()
        {
            AgendamentoViewModel avm = new AgendamentoViewModel();
            avm.Eventos = eventoRepository.ObterTodos();
            
            
            var usuarioLogado = ObterUsuarioSession();
            var nomeUsuarioLogado = ObterUsuarioNomeSession();
            if(!string.IsNullOrEmpty(nomeUsuarioLogado))
            {
                avm.NomeUsuario = nomeUsuarioLogado;
            }

            var clienteLogado = clienteRepository.ObterPor(usuarioLogado);
            if(clienteLogado !=null)
            {
               avm.Cliente = clienteLogado; 
            }

            avm.NomeView = "Agendamento";
            avm.UsuarioEmail = usuarioLogado;
            avm.UsuarioNome = nomeUsuarioLogado;            
            return View( new BaseViewModel()
                {
                    NomeView = "Agendamento",
                    UsuarioEmail = ObterUsuarioSession(),
                    UsuarioNome = ObterUsuarioNomeSession()
                }
            );
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
