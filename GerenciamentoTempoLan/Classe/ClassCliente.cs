using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoTempoLan
{
    class ClassCliente
    {
        string stringConn = ClassSecurity.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdH3HJzljHsInLMfbDP8Mk6iZnCtTwMLKgd+ySDR6WmGnFgI0uyLIUqcvKS107S/G6x"), _sql;

        private int CodCliente;
        private string Nome;
        private string Logradouro;
        private string Numero;

        public int _CodCliente
        {
            get { return CodCliente; }
            set { CodCliente = value; }
        }
        public string _Nome
        {
            get { return Nome; }
            set { Nome = value; }
        }
        public string _Logradouro
        {
            get { return Logradouro; }
            set { Logradouro = value; }
        }
        public string _Numero
        {
            get { return Numero; }
            set { Numero = value; }
        }

        public void Cadastrar()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "insert into CadastroCliente Values (@CodigoCliente, @Nome, @Logradouro, @Numero)";
            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@CodigoCliente", _CodCliente);
            comando.Parameters.AddWithValue("@Nome", _Nome);
            comando.Parameters.AddWithValue("@Logradouro", _Logradouro);
            comando.Parameters.AddWithValue("@Numero", _Numero);
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

        public void Atualizar()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "Update CadastroCliente set Nome = @Nome, Logradouro = @Logradouro, Número = @Numero where Cod_Cliente = @CodigoCliente";
            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@CodigoCliente", _CodCliente);
            comando.Parameters.AddWithValue("@Nome", _Nome);
            comando.Parameters.AddWithValue("@Logradouro", _Logradouro);
            comando.Parameters.AddWithValue("@Numero", _Numero);
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
            _sql = "Delete from CadastroCliente where Cod_Cliente = @CodigoCliente";
            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@CodigoCliente", _CodCliente);
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
    }
}
