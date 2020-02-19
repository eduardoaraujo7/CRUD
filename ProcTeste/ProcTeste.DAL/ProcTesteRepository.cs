using ProcTeste.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcTeste.DAL
{
    public class ProcTesteRepository
    {
        public bool InserirUsuario(Usuario usuario)
        {
            var procedure = "sp_inserir_cliente";

            var parameter = new List<SqlParameter>()
            {
                new SqlParameter(){DbType = System.Data.DbType.String, ParameterName = "@nome", Value = usuario.Nome},
                new SqlParameter(){DbType = System.Data.DbType.String, ParameterName = "@login", Value = usuario.Login},
                new SqlParameter() {DbType = System.Data.DbType.String, ParameterName = "@senha", Value = usuario.Senha},
                new SqlParameter() {DbType = System.Data.DbType.String, ParameterName = "@endereco", Value = usuario.Endereco}
            };

            using (var dbHelper = new ProcTesteCommand())
            {
                var command = dbHelper.CriarComando(procedure, parameter);

                var retornaLinhas = command.ExecuteNonQuery();

                if (retornaLinhas > 0)
                    return true;
                return false;
            }
        }
    }
}
