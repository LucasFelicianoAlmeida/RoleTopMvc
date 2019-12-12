using System;
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
            var quantidadeAgendamento = File.ReadAllLines(PATH).Length;
            agendamento.Id =(ulong) ++quantidadeAgendamento;
            var linha = new string[] {PrepararAgendamentoCSV (agendamento)};
            File.AppendAllLines (PATH , linha);
            
            return true;
        }

        public List<Agendamento> ObteTodosPorCliente(string emailCliente)
        {
            
            var agendamento = ObterAgendamentos();
            List<Agendamento> agendamentosCliente = new List<Agendamento>();

            foreach (var linha in agendamento)
            {
                if(linha.Cliente.Email.Equals(emailCliente))
                {
                    agendamentosCliente.Add(linha);
                }
            }
            return agendamentosCliente;
            
        }

        public List<Agendamento> ObterAgendamentos()
        {
            var linhas = File.ReadAllLines(PATH);
            List<Agendamento> agendamentos = new List<Agendamento>();

            foreach (var linha in linhas )
            {
                Agendamento agendamento = new Agendamento();

                agendamento.Cliente.Nome = ExtrairValorDoCampo("cliente_Nome", linha);
                agendamento.Cliente.Endereco = ExtrairValorDoCampo("cliente_Endereco", linha);
                agendamento.Cliente.Telefone = ExtrairValorDoCampo("cliente_Telefone",linha);
                agendamento.Cliente.Senha = ExtrairValorDoCampo("cliente_Senha", linha);
                agendamento.Cliente.Email = ExtrairValorDoCampo("cliente_Email", linha);
                agendamento.NomeEvento = ExtrairValorDoCampo("evento_nome", linha);
                agendamento.Cliente.TipoUsuario = uint.Parse(ExtrairValorDoCampo("cliente_TipoUsuario", linha));
                agendamento.DataDoEvento = DateTime.Parse(ExtrairValorDoCampo("date_pedido", linha));
                agendamento.PrecoTotal = double.Parse(ExtrairValorDoCampo("preco_total", linha));

                agendamentos.Add(agendamento);
             }
        return agendamentos;

        }
        public string PrepararAgendamentoCSV(Agendamento agendamento)
        {
            Cliente c = agendamento.Cliente;
            
            return $"clente_Nome={c.Nome};cliente_Endereco={c.Endereco};cliente_Telefone={c.Telefone};cliente_Senha={c.Senha};cliente_Email={c.Email};evento_Nome={agendamento.NomeEvento};cliente_TipoUsuario={c.TipoUsuario};data_pedido={agendamento.DataDoEvento};preco_Total={agendamento.PrecoTotal}";
        }
    }
}