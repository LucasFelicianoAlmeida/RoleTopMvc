namespace RoleTopMvc.Models
{
    public class Evento
    {
        public string Nome {get;set;}
         public ulong Id {get;set;}
        public Cliente Cliente {get;set;}
        public uint Status {get;set;}

        public Evento(string nome)
    {
        this.Nome = nome;
        
    }
        public Evento()
        {
            
        }
    }

    
}