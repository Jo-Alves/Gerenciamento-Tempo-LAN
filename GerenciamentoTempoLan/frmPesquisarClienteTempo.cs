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
    public partial class frmPesquisarClienteTempo : Form
    {
        public frmPesquisarClienteTempo(bool VemTelaPrincipal)
        {
            InitializeComponent();
            this.VemTelaPrincipal = VemTelaPrincipal;
        }

        bool VemTelaPrincipal;
        private void frmPesquisaUsuario_Load(object sender, EventArgs e)
        {
            CarregarGrid();
            dgvBusca.CurrentRow.Selected = false;
        }

        private void CarregarGrid()
        {
            SqlConnection conexao = new SqlConnection(ClassSecurity.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdH3HJzljHsInLMfbDP8Mk6iZnCtTwMLKgd+ySDR6WmGnFgI0uyLIUqcvKS107S/G6x"));
            SqlDataAdapter adapter = new SqlDataAdapter("", conexao);
            adapter.SelectCommand.CommandText = "select CadastroCliente.Cod_Cliente, CadastroCliente.Nome, CadastroCliente.Logradouro, CadastroCliente.Número, GerenciarTempo.ValorRestante from CadastroCliente inner join GerenciarTempo on GerenciarTempo.Cod_cliente = CadastroCliente.Cod_Cliente where GerenciarTempo.ValorRestante >= 0.00";
            DataTable Tabela = new DataTable();
            adapter.Fill(Tabela);
            if(Tabela.Rows.Count > 0)
            dgvBusca.DataSource = Tabela;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            SqlConnection conexao = new SqlConnection(ClassSecurity.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdH3HJzljHsInLMfbDP8Mk6iZnCtTwMLKgd+ySDR6WmGnFgI0uyLIUqcvKS107S/G6x"));
            SqlDataAdapter adapter = new SqlDataAdapter("", conexao);
            adapter.SelectCommand.CommandText = "select CadastroCliente.Cod_Cliente, CadastroCliente.Nome, CadastroCliente.Logradouro, CadastroCliente.Número, GerenciarTempo.ValorRestante from CadastroCliente inner join GerenciarTempo on GerenciarTempo.Cod_cliente = CadastroCliente.Cod_Cliente where CadastroCliente.Nome like '" + txtNome.Text.Trim() + "%' and GerenciarTempo.ValorRestante >= 0.00";
            DataTable Tabela = new DataTable();
            adapter.Fill(Tabela);
            if (Tabela.Rows.Count > 0)
                dgvBusca.DataSource = Tabela;
            else
            {
                MessageBox.Show("Dados não encontrado!", "Mensagem do sistema 'Gerenciamento Tempo Lan'", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dgvBusca.CurrentRow.Selected = false;
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            if (txtNome.Text == "")
            {
                CarregarGrid();
                dgvBusca.CurrentRow.Selected = false;
            }
        }

        private void btnUsarTempo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CodCliente))
            {
                if (VemTelaPrincipal == true)
                {
                    if (Valor == "0,00")
                    {
                        MessageBox.Show("Adicione tempo na conta do cliente!", "Mensagem do sistema 'Gerenciamento Tempo Lan'", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        if (CodCliente != null)
                        {
                            this.Visible = false;
                            FrmGerenciarTempo gerenciarTempo = new FrmGerenciarTempo(CodCliente, Nome, Valor, ".");
                            gerenciarTempo.ShowDialog();
                            dgvBusca.CurrentRow.Selected = false;
                        }
                        else
                        {
                            MessageBox.Show("Selecione o cliente!", "Mensagem do sistema 'Gerenciamento Tempo Lan'", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
                else
                {
                    Close();
                }
            }
            else
                MessageBox.Show("Selecione o cliente!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        public string CodCliente { get; set; }
        public string Nome { get; set; }
        public string Valor { get; set; }
        public string C { get; set; }

        private void dgvBusca_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (VemTelaPrincipal == true)
            {
                if (Valor == "0,00")
                {
                    MessageBox.Show("Adicione tempo na conta do cliente!", "Mensagem do sistema 'Gerenciamento Tempo Lan'", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    this.Visible = false;
                    if (CodCliente != "")
                    {

                        FrmGerenciarTempo gerenciarTempo = new FrmGerenciarTempo(CodCliente, Nome, Valor, ".");
                        gerenciarTempo.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Selecione o cliente!", "Mensagem do sistema 'Gerenciamento Tempo Lan'", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    this.Close();
                }
            }
            else
            {
                Close();
            }
        }

        private void dgvBusca_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow linhas = dgvBusca.Rows[e.RowIndex];
            CodCliente = linhas.Cells[0].Value.ToString();
            Nome = linhas.Cells[1].Value.ToString();
            Valor = linhas.Cells[4].Value.ToString();
            C = ".";
        }

        private void btnRetirarTempo_Click(object sender, EventArgs e)
        {
            if (CodCliente == null)
            {
                MessageBox.Show("Selecione o cliente!", "Mensagem do sistema 'Gerenciamento Tempo Lan'", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                FrmRetirar_adicionar Ra = new FrmRetirar_adicionar(CodCliente, Nome);
                Ra.ShowDialog();
                CarregarGrid();
                dgvBusca.CurrentRow.Selected = false;
                CodCliente = null;
                Nome = null;
            }
        }
    }
}
