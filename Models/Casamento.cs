namespace RoleTopMvc.Models
{
    public class Casamento : Evento
    {
        public Casamento()
        {

        }

        public Casamento(double preco)
        {
            this.Preco = preco;
        }
    }
}