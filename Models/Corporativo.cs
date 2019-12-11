namespace RoleTopMvc.Models
{
    public class Corporativo : Evento
    {
       public Corporativo()
       {

       } 
       public Corporativo(double preco)
       {
           this.Preco = preco;
       }
    }
}