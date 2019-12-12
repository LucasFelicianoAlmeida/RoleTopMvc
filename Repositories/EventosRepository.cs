using System.Collections.Generic;
using System.IO;
using RoleTopMvc.Models;

namespace RoleTopMvc.Repositories
{
    public class EventosRepository
    {
        private const string PATH = "Database/Evento.csv";

        public EventosRepository () {
            if (!File.Exists (PATH)) {
                File.Create (PATH).Close ();
            }
        }

        public double ObterPrecoDoEvento(string nomeDoEvento)
        {
            var lista = ObterTodos();
            var preco = 0.0;
            foreach(var item in lista)
            {
                if(item.Nome.Equals(nomeDoEvento))
                {
                    preco = item.Preco;
                    break;
                }

            }
            return preco;
        }
        public List<Evento> ObterTodos()
        {
            List<Evento> eventos = new List<Evento>();

            string[] linhas = File.ReadAllLines(PATH);
            foreach(var linha in linhas)
            {
                Evento e  = new Evento();
                string[] dados = linha.Split(";");
                e.Nome = dados[0];
                e.Preco = double.Parse(dados[1]);
                eventos.Add(e);
            }
            return eventos; 
        }
        
    }
}