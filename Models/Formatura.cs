namespace RoleTopMvc.Models
{
    public class Formatura : Evento
    {
        public Formatura()
        {

        }

        public Formatura(double preco)
        {
            this.Preco = preco;
        }
    }
}