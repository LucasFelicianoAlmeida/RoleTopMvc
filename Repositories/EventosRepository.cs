// using System;
// using System.Collections.Generic;
// using System.IO;
// using RoleTopMvc.Models;

// namespace RoleTopMvc.Repositories
// {
//     public class EventosRepository : RepositoryBase
//     {
//         private const string PATH = "Eventos/Agendamento.csv";

//         public EventosRepository () {
//             if (!File.Exists (PATH)) {
//                 File.Create (PATH).Close ();
//             }
//         }
//         public List<Evento> ObterTodosPorCliente(string emailCliente)
//         {
//             var agendamentos = ObterTodos();
//             List<Evento> agendamentosCliente = new List<Evento>();

//             foreach (var agendamento in agendamentos)
//             {
//                 if(agendamentos.Cliente.Email.Equals(emailCliente))
//                 {
//                     agendamentosCliente.Add(agendamento);
//                 }
//             }
//             return agendamentosCliente;
//         }
        
        
//         public List<Agendamento> ObterTodos() {
//             var linhas = File.ReadAllLines (PATH);
//             List<Agendamento> agendamentos = new List<Agendamento>();

//             foreach (var linha in linhas) {
//                 Agendamento agendamento = new Agendamento ();

//                 agendamento.Id = ulong.Parse(ExtrairValorDoCampo("id", linha));
//                 agendamento.Status = uint.Parse(ExtrairValorDoCampo("status_pedido", linha));
//                 agendamento.Cliente.Nome = ExtrairValorDoCampo("cliente_nome", linha);
//                 agendamento.Cliente.Endereco = ExtrairValorDoCampo("cliente_endereco",linha);
//                 agendamento.Cliente.Telefone = ExtrairValorDoCampo("cliente_telefone", linha);
//                 agendamento.Cliente.Email = ExtrairValorDoCampo("cliente_email", linha);
//                 agendamento.PrecoTotal = double.Parse(ExtrairValorDoCampo("preco_total", linha));
//                 agendamento.DataDoEvento = DateTime.Parse(ExtrairValorDoCampo("data_datadoevento", linha));

//                 agendamentos.Add(agendamento);
//             }
//             return agendamentos;
//         }
//         private string PrepararPedidoCSV (Agendamento a) {
//             return $"id={a.Id};status_pedido={a.Status};cliente_nome={a.Cliente.Nome};cliente_endereco={a.Cliente.Endereco};cliente_telefone={a.Cliente.Telefone};cliente_email={a.Cliente.Email};nome_evento={a.NomeEvento};";
//         }
        
//     }
// }