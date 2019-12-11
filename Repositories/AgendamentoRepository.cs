using System.Collections.Generic;
using System.IO;
using RoleTopMvc.Models;

namespace RoleTopMvc.Repositories
{
    public class AgendamentoRepository : RepositoryBase
    {
        private const string PATH = "Database/Agendamento.csv";

        public AgendamentoRepository()
        {
            if (!File.Exists(PATH))
            {
                File.Create(PATH);
            }
        }

        public bool Inserir (Agendamento agendamento)
        {
            var quantidadePedidos = File.ReadAllLines(PATH).Length;
            agendamento.Id =(ulong) ++quantidadePedidos;
            var linha = new string[] {PrepararPedidoCSV (agendamento)};
            File.AppendAllLines (PATH , linha);
            
            return true;
        }

        public List<Agendamento> ObteTodosPorCliente(string emailCliente)
        {
            var agendamento = ObterAgendamentos();
            List<Agendamento> agendamentosCliente = new List<Agendamento>();

            foreach (var marcar in agendamento)
            {
                if(agendamento.Cliente.Email.Equals(emailCliente))
                {
                    agendamentosCliente.Add(agendamento);
                }
            }
            return agendamentosCliente;
            
        }

        public List<Agendamento> ObterAgendamentos ()
        {
            var linhas = File.ReadAllLines(PATH);
            List<Agendamento> agendamentos = new List<Agendamento>();

            foreach (var linha in linhas )
            {
                Agendamento agendamento = new Agendamento();

                agendamento.Id =
            } 
        }
    }
}