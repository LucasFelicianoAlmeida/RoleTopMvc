using System;
using RoleTopMvc.Enums;
namespace RoleTopMvc.Models
{
    public class Agendamento
    {
        public ulong Id {get;set;}
        public Cliente Cliente{get;set;}
        public double PrecoTotal {get;set;}
        public DateTime DataDoEvento {get;set;}
        public string NomeEvento {get;set;}
        
        
        public uint Status {get;set;}

        public Agendamento()
        {
            this.Cliente = new Cliente();
            this.Id = 0;
            this.Status = (uint) StatusPedido.PENDENTE;
            this.NomeEvento = "Evento";
            
            
            
        }
    }

    
}