using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoTempoLan
{
    class ClassGerenciarTempo
    {
        string stringConn = ClassSecurity.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdH3HJzljHsInLMfbDP8Mk6iZnCtTwMLKgd+ySDR6WmGnFgI0uyLIUqcvKS107S/G6x"), _sql;

        private int CodCliente;

        public int _CodCliente
        {
            get { return CodCliente; }
            set { CodCliente = value; }
        }

        public void Excluir()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "Delete from GerenciarTempo where Cod_Cliente = @CodigoCliente";
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
