using System.Collections.Generic;
using RoleTopMvc.Models;

namespace RoleTopMvc.ViewModels
{
    public class AgendamentoViewModel : BaseViewModel
    {
        public List<Evento> Eventos {get;set;}
        public Cliente Cliente {get;set;}
        public string NomeUsuario {get;set;}

        public AgendamentoViewModel()
        {
            this.Eventos = new List<Evento>();
            this.Cliente = new Cliente();
            this.NomeUsuario = "Fulano";
        }
    }
}