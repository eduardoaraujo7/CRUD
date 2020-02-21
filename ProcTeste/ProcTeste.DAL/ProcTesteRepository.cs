using ProcTeste.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

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

        public List<Usuario> ListarUsuario()
        {
            var usuarios = new List<Usuario>();
            var procedure = "sp_listar_usuario";

            using (var dbHelper = new ProcTesteCommand())
            {
                var command = dbHelper.CriarComando(procedure);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    usuarios.Add(new Usuario
                    {
                        Nome = reader["nome"].ToString(),
                        Login = reader["login"].ToString(),
                        Senha = reader["senha"].ToString(),
                        Endereco = reader["endereco"].ToString()
                    }  );
                }
                return usuarios;
            }
        }

        public Usuario ObterUsuario(int id)
        {
            var usuario = new Usuario();
            var procedure = "sp_obter_usuario_id";

            var parameters = new List<SqlParameter>()
            {
                new SqlParameter() {DbType = System.Data.DbType.Int32, ParameterName = "@id", Value = id}
            };

            using (var dbHelper = new ProcTesteCommand())
            {
                var command = dbHelper.CriarComando(procedure, parameters);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    usuario.Id = Convert.ToInt32(reader["id"]);
                    usuario.Nome = reader["@nome"].ToString();
                    usuario.Login = reader["@login"].ToString();
                    usuario.Senha = reader["@senha"].ToString();
                    usuario.Endereco = reader["@endereco"].ToString();
                }

                return usuario;
            }
        }

        public bool AlterarUsuario(Usuario usuario)
        {
            var procedure = "sp_alterar_usuario";
            var parameters = new List<SqlParameter>()
            {
                new SqlParameter() {SqlDbType = SqlDbType.Int, ParameterName = "@id", Value = usuario.Id },
                new SqlParameter() {SqlDbType =  SqlDbType.VarChar, ParameterName = "@nome", Value = usuario.Nome},
                new SqlParameter() {SqlDbType = SqlDbType.VarChar, ParameterName = "@login", Value = usuario.Login},
                new SqlParameter() {SqlDbType = SqlDbType.VarChar, ParameterName = "@senha", Value = usuario.Senha},
                new SqlParameter() {SqlDbType = SqlDbType.VarChar, ParameterName = "@endereco", Value = usuario.Endereco}
            };

            using (var dbHelper = new ProcTesteCommand())
            {
                var command = dbHelper.CriarComando(procedure, parameters);
                var retorno = command.ExecuteNonQuery();
                if (retorno > 0)
                    return true;
                return false;
            }
        }

        public bool ExcluirUsuario(int id)
        {
            var procedure = "sp_excluir_usuario";

            var parameters = new List<SqlParameter>()
            {
                new SqlParameter() {SqlDbType = SqlDbType.Int, ParameterName = "@id", Value = id}
            };

            using (var dbHelper = new ProcTesteCommand())
            {
                var command = dbHelper.CriarComando(procedure, parameters);
                var retorno = command.ExecuteNonQuery();

                if (retorno > 0)
                    return true;
                return false;
            }
        }
    }
}
