using System.IO;
using RoleTopMvc.Models;

namespace RoleTopMvc.Repositories
{
    public class ClienteRepository : RepositoryBase
    {
        private const string PATH = "Database/Cliente.csv";

        public ClienteRepository()
        {
            if(!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
        }

        public bool Inserir(Cliente cliente)
        {
            var linha = new string[] {PrepararRegistroCSV(cliente)};
            File.AppendAllLines(PATH, linha);

            return true;
        }

        public Cliente ObterPor(string email)
        {
            var linhas = File.ReadAllLines(PATH);
            foreach(var item in linhas)
            {
                if(ExtrairValorDoCampo("email", item).Equals(email))
                {
                    Cliente c = new Cliente();
                    c.Nome = ExtrairValorDoCampo("nome", item);
                    c.Email = ExtrairValorDoCampo("email", item);
                    c.Senha = ExtrairValorDoCampo("senha", item);
                    c.Endereco = ExtrairValorDoCampo("endereco", item);
                    c.Telefone = ExtrairValorDoCampo("telefone", item);
                    c.TipoUsuario = uint.Parse(ExtrairValorDoCampo("tipo usuario" , item));
                 return c;   
                }
                
            }
            return null;
        }

        public string PrepararRegistroCSV(Cliente cliente)
        {
            return $"tipo-usuario{cliente.TipoUsuario};nome={cliente.Nome};email={cliente.Email};senha={cliente.Senha};endereco={cliente.Endereco};telefone={cliente.Telefone}";
        }
        
    }
}