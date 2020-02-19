using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcTeste.DAL
{
    public class ProcTesteCommand : IDisposable
    {
        public SqlCommand CriarComando(string procedure, List<SqlParameter> parameters)
        {
            var command = new SqlCommand();

            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = procedure;
            command.Parameters.AddRange(parameters.ToArray());
            command.Connection = Conexao.CriarConexao();
            command.Connection.Open();

            return command;
        }

        public void Dispose()
        {
            if (Conexao.CriarConexao().State == System.Data.ConnectionState.Open)
                Conexao.CriarConexao().Close();
        }
    }
}
