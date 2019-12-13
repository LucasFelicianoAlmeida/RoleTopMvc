using System.Collections.Generic;
using RoleTopMvc.Models;

namespace RoleTopMvc.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        public List<Agendamento> Pedidos {get;set;}
        public uint PedidosAprovados {get;set;}
        public uint PedidosReprovados {get;set;}
        public uint PedidosPendentes {get;set;}

        public DashboardViewModel()
        {
            this.Pedidos = new List<Agendamento>();
        }

    }
}