// using System.Collections.Generic;
// using System.IO;

// namespace RoleTopMvc.Repositories
// {
//     public class TiposDeEventoRepositories : RepositoryBase
//     {
//         private const string PATH = "DataBase/Eventos.csv";

//         public TiposDeEventoRepositories () {
//             if (!File.Exists (PATH)) {
//                 File.Create (PATH).Close ();
//             }
//         }

//         public List<string> ObterTodos()
//         {
//             var linhas = File.ReadAllLines(PATH);
            
//             foreach(var linha in linhas)
//             {

//             }
            
//         }
//     }
// }