using RoleTopMvc.Enums;
namespace RoleTopMvc.Models
{
    public class Agendamento
    {
        public ulong Id {get;set;}
        public Cliente Cliente{get;set;}
        public double Preco {get;set;}
        public Baile Baile {get;set;}
        public Formatura Formatura {get;set;}
        public Casamento Casamento {get;set;}
        public Corporativo Corporativo {get;set;}
        public uint Status {get;set;}

        public Agendamento()
        {
            this.Cliente = new Cliente();
            this.Id = 0;
            this.Status = (uint) StatusPedido.PENDENTE;
            this.Baile = new Baile();
            this.Formatura = new Formatura();
            this.Casamento = new Casamento();
            this.Corporativo = new Corporativo();
        }
    }

    
}