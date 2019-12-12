namespace RoleTopMvc.Models
{
    public class Evento
    {
        public string Nome {get;set;}
        public double Preco {get;set;}

        public Evento(string nome, double preco)
    {
        this.Nome = nome;
        this.Preco = preco;
    }
        public Evento()
        {
            
        }
    }

    
}