using System.Collections.Generic;
using RoleTopMvc.Models;

namespace RoleTopMvc.ViewModels
{
    public class AgendamentoViewModel : BaseViewModel
    {
        public Cliente Cliente {get;set;}
        public string NomeUsuario {get;set;}

        public AgendamentoViewModel()
        {

            this.Cliente = new Cliente();

        }
    }
}