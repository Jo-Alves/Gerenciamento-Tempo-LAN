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
    public partial class FrmCadastroCliente : Form
    {
        //Crio aqui a variável que vai receber a string de conexão com o banco de dados e outra váriável que recebe a intrução do comando com o banco de dados
        string stringConn = ClassSecurity.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdH3HJzljHsInLMfbDP8Mk6iZnCtTwMLKgd+ySDR6WmGnFgI0uyLIUqcvKS107S/G6x"), _sql;
        //instacia a classe 'ClassCliente'
        ClassCliente cliente = new ClassCliente();

        public FrmCadastroCliente()
        {
            InitializeComponent();
        }

        // Método que vai receber o valor máximo do Cod_Cliente da tabela CadastroCliente 
        int CodCliente;
        private void CodigoCliente()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql="Select Max(Cod_Cliente) from CadastroCliente";
            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.CommandText = _sql;
            try
            {
                conexao.Open();
                if (comando.ExecuteScalar() == DBNull.Value)
                {
                    CodCliente = 1;
                }
                else
                {
                    CodCliente = Convert.ToInt32(comando.ExecuteScalar()) + 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem do sistema 'Gere'Gerenciamento Tempo Lan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();
            }
        }

        ErrorProvider errorProvider = new ErrorProvider();

        //Ao clicar no botão limpar os elementos serã limpos e reabilita os elementos para a escrita
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            txtCodigo.Clear();
            txtLogradouro.Clear();
            txtNome.Clear();
            txtNumero.Clear();
            txtNome.ReadOnly = false;
            txtLogradouro.ReadOnly = false;
            txtNumero.ReadOnly = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigo.Text != "")
                {
                    if (txtNome.Text == string.Empty)
                    {
                        MessageBox.Show("Campo 'Nome' vazio!", "Campo obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        errorProvider.Clear();
                        errorProvider.SetError(txtNome, "Campo obrigatório!");
                        txtNome.Focus();
                        return;
                    }
                    else
                    {
                        cliente._CodCliente = int.Parse(txtCodigo.Text);
                        cliente._Nome = txtNome.Text.Trim();
                        cliente._Logradouro = txtLogradouro.Text.Trim();
                        cliente._Numero = txtNumero.Text;
                        cliente.Atualizar();
                        MessageBox.Show("Dados atualizado com sucesso!", "Mensagem do sistema 'Gerenciamento Tempo Lan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNome.ReadOnly = true;
                        txtLogradouro.ReadOnly = true;
                        txtNumero.ReadOnly = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem de erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool Pesquisarclientes()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "Select * from CadastroCliente";
            SqlDataAdapter Comando = new SqlDataAdapter(_sql, conexao);
            Comando.SelectCommand.CommandText = _sql;
            DataTable Tabela = new DataTable();
            Comando.Fill(Tabela);
            if (Tabela.Rows.Count > 0)
                return true;
            else
                return false;
        }
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (Pesquisarclientes() == true)
            {
                FrmPesquisarCliente pesquisarCliente = new FrmPesquisarCliente();
                pesquisarCliente.ShowDialog();

                if (pesquisarCliente.Codigo >= 1)
                {
                    txtCodigo.Text = pesquisarCliente.Codigo.ToString();
                    txtNome.Text = pesquisarCliente.Nome;
                    txtLogradouro.Text = pesquisarCliente.Logradouro;
                    txtNumero.Text = pesquisarCliente.Numero;
                }
            }
            else
                MessageBox.Show("Não há clientes cadastrados!", "Mensagem do sistema 'Gerenciamento Tempo Lan'", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        ClassGerenciarTempo GT = new ClassGerenciarTempo();
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigo.Text != "")
                {
                    cliente._CodCliente = int.Parse(txtCodigo.Text);
                    GT._CodCliente = int.Parse(txtCodigo.Text);
                    if (MessageBox.Show("Deseja realmente excluir os dados do cliente?", "Aviso do sistema 'Gerenciamento Tempo Lan'", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        GT.Excluir();
                        cliente.Excluir();
                        MessageBox.Show("Dados excluido do banco de dados com sucesso!", "Mensagem do sistema 'Gerenciamento Tempo Lan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnLimpar_Click(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem de erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            CodigoCliente();
            if (txtNome.Text == string.Empty)
            {
                MessageBox.Show("Campo 'Nome' vazio!", "Campo obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                errorProvider.Clear();
                errorProvider.SetError(txtNome, "Campo obrigatório!");
                txtNome.Focus();
                return;
            }
            else
            {
               

                //Os propriedades do objeto Cliente recebem os respectivos dados do elementos
                try
                {
                    cliente._CodCliente = CodCliente;
                    cliente._Nome = txtNome.Text.Trim();
                    cliente._Logradouro = txtLogradouro.Text.Trim();
                    cliente._Numero = txtNumero.Text.Trim();
                    //Aqui é  chamado o método cadastrar da classe ClasseCliente
                    cliente.Cadastrar();
                    //Aqui exibimos uma mensagem para o usuário do sistema que o cadatro foi realizado com sucesso
                    MessageBox.Show("Cadastro realizado com sucesso!", "Mensagem do sistema 'Gerenciamento de Tempo Lan'", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCodigo.Text = CodCliente.ToString();
                    txtNome.ReadOnly = true;
                    txtLogradouro.ReadOnly = true;
                    txtNumero.ReadOnly = true;
                }
                catch
                (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Mensagem de erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
