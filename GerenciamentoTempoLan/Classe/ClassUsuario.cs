using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoTempoLan
{
    class ClassUsuario
    {
        string stringConn = ClassSecurity.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdH3HJzljHsInLMfbDP8Mk6iZnCtTwMLKgd+ySDR6WmGnFgI0uyLIUqcvKS107S/G6x"), _sql;

        private int id;
        private string usuario;
        private string senha;

        public int _id
        {
            get { return id; }
            set { id = value; }
        }
        public string _usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
        public string _senha
        {
            get { return senha; }
            set { senha = value; }
        }

        public bool Salvar()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "select Descricao_Usuario from Usuario where Descricao_Usuario = @Usuario" ;
            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@Usuario", _usuario);
            try
            {
                conexao.Open();
                SqlDataReader dr = comando.ExecuteReader();
              
                if (!dr.Read())
                {
                    conexao.Close();

                    _sql = "insert into Usuario values (@usuario, @senha)";
                    conexao = new SqlConnection(stringConn);
                    comando = new SqlCommand(_sql, conexao);
                    comando.Parameters.AddWithValue("@usuario", _usuario);
                    comando.Parameters.AddWithValue("@senha", _senha);
                    comando.CommandText = _sql;
                    conexao.Open();
                    comando.ExecuteNonQuery();

                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                conexao.Close();
            }
        }

        public void editar()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "update Usuario set Descricao_Usuario = @usuario, Senha_Usuario = @senha where descricao_Usuario = @usuario";
            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@usuario", _usuario);
            comando.Parameters.AddWithValue("@senha", _senha);
            comando.CommandText = _sql;
            try
            {
                conexao.Open();
                comando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                conexao.Close();
            }
        }

        public void Excluir()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "delete from Usuario where Descricao_Usuario = @usuario and Senha_Usuario = @senha";
            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@usuario", _usuario);
            comando.Parameters.AddWithValue("@senha", _senha);
            comando.CommandText = _sql;
            try
            {
                conexao.Open();
                comando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                conexao.Close();
            }
        }
        public bool Autenticar()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "Select Descricao_Usuario, Senha_Usuario from Usuario where Descricao_usuario = @Usuario and Senha_Usuario= @Senha";
            SqlDataAdapter comando = new SqlDataAdapter(_sql, conexao);
            comando.SelectCommand.Parameters.AddWithValue("@Usuario", _usuario);
            comando.SelectCommand.Parameters.AddWithValue("@Senha", _senha);
            comando.SelectCommand.CommandText = _sql;
            try
            {
                conexao.Open();
                DataTable Tabela = new DataTable();
                comando.Fill(Tabela);
                if (Tabela.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}
