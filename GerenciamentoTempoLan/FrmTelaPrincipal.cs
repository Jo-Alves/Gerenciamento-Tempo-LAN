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
    public partial class FrmTelaPrincipal : Form
    {
        bool closed = false;
        public FrmTelaPrincipal()
        {
            InitializeComponent();
        }

        private void MenuGerenciarTempo_Click(object sender, EventArgs e)
        {
            FrmGerenciarTempo GerenciaTempo = new FrmGerenciarTempo("", "", "", "");
            GerenciaTempo.ShowDialog();
        }

        private void MenuCadastroCliente_Click(object sender, EventArgs e)
        {
            FrmCadastroCliente cadastroCliente = new FrmCadastroCliente();
            cadastroCliente.ShowDialog();
        }

        private void MenuSair_Click(object sender, EventArgs e)
        {
            try
            {
                FrmSair sair = new FrmSair();
                sair.ShowDialog();
                if (sair.Closed == true)
                {
                    closed = true;
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MenuCadastroTempo_Click(object sender, EventArgs e)
        {
            FrmGravarTempo gravarTempo = new FrmGravarTempo();
            gravarTempo.ShowDialog();
        }


        private bool PesquisarTempoGuardados()
        {
            SqlConnection conexao = new SqlConnection(ClassSecurity.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdH3HJzljHsInLMfbDP8Mk6iZnCtTwMLKgd+ySDR6WmGnFgI0uyLIUqcvKS107S/G6x"));
            SqlDataAdapter adapter = new SqlDataAdapter("", conexao);
            adapter.SelectCommand.CommandText = "select CadastroCliente.Cod_Cliente, CadastroCliente.Nome, CadastroCliente.Logradouro, CadastroCliente.Número, GerenciarTempo.ValorRestante from CadastroCliente inner join GerenciarTempo on GerenciarTempo.Cod_cliente = CadastroCliente.Cod_Cliente where GerenciarTempo.ValorRestante >= 0.00";
            DataTable Tabela = new DataTable();
            adapter.Fill(Tabela);
            if (Tabela.Rows.Count > 0)
                return true;
            else
                return false;
        }

        private void buscarClienteComTempoGuardadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PesquisarTempoGuardados() == true)
            {
                frmPesquisarClienteTempo pesquisarCliente = new frmPesquisarClienteTempo(true);
                pesquisarCliente.ShowDialog();
            }
            else
                MessageBox.Show("Não há dados de clientes com valores guardados!", "Mensagem do sistema 'Gerenciamento Tempo Lan'", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void conversãoDeValoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConversao conversao = new FrmConversao();
            conversao.ShowDialog();
        }

        private void FrmTelaPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                MenuSair_Click(sender, e);
            }
        }

        private void FrmTelaPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (closed == false)
                {
                    FrmSair sair = new FrmSair();
                    sair.ShowDialog();
                    if (sair.Closed == true)
                    {
                        closed = true;
                        Application.Exit();
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MenuTrocarOpcaoDeDiretorio_Click(object sender, EventArgs e)
        {
            FrmOpcaoDiretorio opcaoDiretorio = new FrmOpcaoDiretorio();
            opcaoDiretorio.ShowDialog();
        }
    }
}
