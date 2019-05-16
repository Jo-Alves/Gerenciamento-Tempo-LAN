using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GerenciamentoTempoLan
{
    public partial class FrmRetirar_adicionar : Form
    {
        public FrmRetirar_adicionar(string CodCliente, string Nome)
        {
            InitializeComponent();
            this.CodCliente = CodCliente;
            txtNome.Text = Nome;
            txtValor.Focus();
        }

        string CodCliente;
        private void rbAdicionar_CheckedChanged(object sender, EventArgs e)
        {
            btn.Text = "Adicionar";
            txtValor.Focus();
        }

        private void rbRetirar_CheckedChanged(object sender, EventArgs e)
        {
            btn.Text = "Retirar";
            txtValor.Focus();
        }

        decimal Vl;
        ErrorProvider errorProvider = new ErrorProvider();
        private void btn_Click(object sender, EventArgs e)
        {
            if (txtValor.Text == "")
            {
                errorProvider.Clear();
                MessageBox.Show("Preencha o campo 'Valor'", "Mensagem do sistema 'Gerenciamento Tempo Lan'", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                errorProvider.SetError(txtValor, "Campo obrigatório!");
                txtValor.Focus();
                return;
            }
            else
            {
                Vl = decimal.Parse(txtValor.Text);
                if (rbAdicionar.Checked)
                {
                    AdicionarGerenciarTempo();
                    this.Close();
                }
                else if (rbRetirar.Checked)
                {
                    VerificarValor();
                    if (Vl <= Valor)
                    {
                        RetirarValor();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Valor digitado é maior que o valor guardado na conta do cliente!", "Mensagem do sistema 'gerenciamento Tempo Lan'", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }             
            }
        }

        decimal Valor;
        private void VerificarValor()
        {
            SqlConnection conexao = new SqlConnection(ClassSecurity.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdH3HJzljHsInLMfbDP8Mk6iZnCtTwMLKgd+ySDR6WmGnFgI0uyLIUqcvKS107S/G6x"));
            _sql = "Select ValorRestante from GerenciarTempo where Cod_Cliente = @Cod_Cliente";
            SqlCommand Comando = new SqlCommand(_sql, conexao);
            Comando.Parameters.AddWithValue("@Cod_Cliente", CodCliente);
            Comando.CommandText = _sql;
            try
            {
                conexao.Open();
                SqlDataReader dr = Comando.ExecuteReader();
                if (dr.Read())
                {
                    Valor = decimal.Parse(dr["ValorRestante"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();
            }
        }

        private void AdicionarGerenciarTempo()
        {
            SqlConnection conexao = new SqlConnection(ClassSecurity.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdH3HJzljHsInLMfbDP8Mk6iZnCtTwMLKgd+ySDR6WmGnFgI0uyLIUqcvKS107S/G6x"));
            SqlCommand comando = new SqlCommand("", conexao);
            comando.Parameters.AddWithValue("@ValorRestante", Vl);
            comando.CommandText = "Update GerenciarTempo set ValorRestante = ValorRestante + @ValorRestante where Cod_Cliente = " + CodCliente;
            try
            {
                conexao.Open();
                comando.ExecuteNonQuery();
                MessageBox.Show("Valor Adicionado com sucesso!", "Mensagem do sistema 'Gerenciamento Tempo Lan'", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();
            }
        }

        private void RetirarValor()
        {
            SqlConnection conexao = new SqlConnection(ClassSecurity.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdH3HJzljHsInLMfbDP8Mk6iZnCtTwMLKgd+ySDR6WmGnFgI0uyLIUqcvKS107S/G6x"));
            SqlCommand comando = new SqlCommand("", conexao);
            comando.Parameters.AddWithValue("@ValorRestante", Vl);
            comando.CommandText = "Update GerenciarTempo set ValorRestante = ValorRestante - @ValorRestante where Cod_Cliente = " + CodCliente;
            try
            {
                conexao.Open();
                comando.ExecuteNonQuery();
                MessageBox.Show("Valor retirado com sucesso!", "Mensagem do sistema 'Gerenciamento Tempo Lan'", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();
            }
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    if (((int)e.KeyChar) != ((int)Keys.Back))
                        if (e.KeyChar != ',')
                            e.Handled = true;
                        else if (txtValor.Text.IndexOf(',') > 0)
                            e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtValor_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtValor.Text != "")
                {
                    txtValor.Text = decimal.Parse(txtValor.Text.Trim()).ToString("0.00");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        string _sql;       

       private void txtValor_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }
    }
}
