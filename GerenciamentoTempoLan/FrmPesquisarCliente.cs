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
    public partial class FrmPesquisarCliente : Form
    {
        //Crio aqui a variável que vai receber a string de conexão com o banco de dados e outra váriável que recebe a intrução do comando com o banco de dados
        string stringConn = ClassSecurity.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdH3HJzljHsInLMfbDP8Mk6iZnCtTwMLKgd+ySDR6WmGnFgI0uyLIUqcvKS107S/G6x"), _sql;

        public int Codigo { get;  set; }
        public string Nome { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }

        public FrmPesquisarCliente()
        {
            InitializeComponent();
        }

        private void FrmPesquisarCliente_Load(object sender, EventArgs e)
        {
            Carregar_dgvDadosCliente();
            dgvDadosCliente.CurrentRow.Selected = false;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "Select * from CadastroCliente where Nome like '" + txtNome.Text.Trim() + "%'";
            SqlDataAdapter Comando = new SqlDataAdapter(_sql, conexao);
            Comando.SelectCommand.CommandText = _sql;
            DataTable Tabela = new DataTable();
            Comando.Fill(Tabela);
            if (Tabela.Rows.Count > 0)
                dgvDadosCliente.DataSource = Tabela;
            else
            {
                MessageBox.Show("Dados não encontrado!", "Mensagem do sistema 'Gerenciamento tempo Lan'", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dgvDadosCliente.CurrentRow.Selected = false;
        }

        private void dgvDadosCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow linhas = dgvDadosCliente.Rows[e.RowIndex];
            Codigo = int.Parse(linhas.Cells[0].Value.ToString());
            Nome = linhas.Cells[1].Value.ToString();
            Logradouro = linhas.Cells[2].Value.ToString();
            Numero = linhas.Cells[3].Value.ToString();
            Close();
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            if(txtNome.Text == "")
            Carregar_dgvDadosCliente();
            dgvDadosCliente.CurrentRow.Selected = false;
        }

        private void txtNome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnPesquisar_Click(sender, e);
            }
        }

        private void Carregar_dgvDadosCliente()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "Select * from CadastroCliente";
            SqlDataAdapter Comando = new SqlDataAdapter(_sql, conexao);
            Comando.SelectCommand.CommandText = _sql;
            DataTable Tabela = new DataTable();
            Comando.Fill(Tabela);
            dgvDadosCliente.DataSource = Tabela;
        }
    }
}
