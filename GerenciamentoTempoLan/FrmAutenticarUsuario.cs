using GerenciamentoTempoLan.Properties;
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
    public partial class FrmAutenticarUsuario : Form
    {
        string _sql;
        public FrmAutenticarUsuario()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        ClassUsuario usuario = new ClassUsuario();
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSenha.Text.Trim()))
            {
                usuario._usuario = cbUsuario.Text;
                usuario._senha = ClassSecurityPassword.Pass(txtSenha.Text);
                if (usuario.Autenticar() == true)
                {
                    if (!string.IsNullOrEmpty(Settings.Default["Disco"].ToString()))
                    {
                        string data = Settings.Default["Disco"].ToString();
                        this.Visible = false;
                        FrmTelaPrincipal telaPrincipal = new FrmTelaPrincipal();
                        telaPrincipal.ShowDialog();
                        this.Visible = false;
                    }
                    else
                    {
                        FrmOpcaoDiretorio opcaoDiretorio = new FrmOpcaoDiretorio();
                        opcaoDiretorio.ShowDialog();
                        FrmTelaPrincipal telaPrincipal = new FrmTelaPrincipal();
                        telaPrincipal.ShowDialog();
                        this.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("Senha Incorreta!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtSenha.Clear();
                    txtSenha.Focus();
                }
            }
            else
            {
                MessageBox.Show("Insira a senha! Campo Obrigatório!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtSenha.Focus();
            }
        }

        private void FrmAutenticarUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEntrar_Click(sender, e);
            }
            if (e.KeyCode == Keys.Escape)
            {
                btnCancelar_Click(sender, e);
            }
        }

        private void cbUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSenha.Focus();
        }

        private void FrmAutenticarUsuario_Load(object sender, EventArgs e)
        {
            if (VerificarDataBase() == true)
            {
                if (VerificarUsuario() == true)
                {
                    InformarNomeUsuario();
                }
                else
                {
                    MessageBox.Show("Crie o usuário e senha.", "Aviso do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmUsuarioSistema usuario = new FrmUsuarioSistema();
                    usuario.ShowDialog();
                    if (VerificarUsuario() == true)
                    {
                        InformarNomeUsuario();
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
            }
            else
            {
                DialogResult dr = MessageBox.Show("Verificamos que não existe dados no banco de dados instalado em seu computador. É o seu primeiro acesso a este programa?", "Aviso do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    MessageBox.Show("Criaremos a base necessária para você proseguir", "Aviso do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    criarBancoDados();
                    userDataBase();
                    criarTabelaCliente();
                    criarTabelaGerenciarTempo();
                    criarTabelaUsuario();

                    MessageBox.Show("Crie o usuário e senha.", "Aviso do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmUsuarioSistema usuario = new FrmUsuarioSistema();
                    usuario.ShowDialog();
                    if (VerificarUsuario() == true)
                    {
                        InformarNomeUsuario();
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
                else
                {
                    MessageBox.Show("Selecione o arquivo de backup para a restauração do sistema.", "Aviso do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Filter = "|*.bak";
                    openFileDialog.Title = "Abrir aqrquivo para restauração";

                    if (DialogResult.OK == openFileDialog.ShowDialog())
                    {

                        SqlConnection conexao = new SqlConnection(ClassSecurity.Dry("9UUEoK5YaRaXjDXC9eLqkg7Prh31kSiCYidze0zIx2X787RW+Zpgc9frlclEXhdHJjGrOXTsH7b9NW1qcCpVJxD4wsfhTDR6OXOUSfCqDynZ+0PYEaREWQ=="));
                        _sql = "Restore database dbGerenciamentoLan from disk = '" + openFileDialog.FileName + "'";
                        SqlCommand comando = new SqlCommand(_sql, conexao);
                        comando.CommandText = _sql;
                        try
                        {
                            conexao.Open();
                            comando.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            conexao.Close();
                        }
                        InformarNomeUsuario();
                    }
                    else
                    {
                        MessageBox.Show("É necessário selecionar o arquivo de backup para restaurar o sistema. Reinicie o programa novamente.", "Aviso do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Application.Exit();
                    }
                }
            }
        }

        private bool VerificarDataBase()
        {
            SqlConnection conexao = new SqlConnection(ClassSecurity.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdHJjGrOXTsH7b9NW1qcCpVJxD4wsfhTDR6OXOUSfCqDynZ+0PYEaREWQ=="));
            _sql = "Select * from Sys.Databases where name = 'dbGerenciamentoLan'";
            SqlCommand comando = new SqlCommand(_sql, conexao);
            try
            {
                conexao.Open();
                comando.ExecuteNonQuery();
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                conexao.Close();
            }
        }

        private bool VerificarUsuario()
        {
            SqlConnection conexao = new SqlConnection(ClassSecurity.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdH3HJzljHsInLMfbDP8Mk6iZnCtTwMLKgd+ySDR6WmGnFgI0uyLIUqcvKS107S/G6x"));
            _sql = "Select * from Usuario";
            SqlCommand comando = new SqlCommand(_sql, conexao);
            try
            {
                conexao.Open();
                comando.ExecuteNonQuery();
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                conexao.Close();
            }
        }

        private void InformarNomeUsuario()
        {
            SqlConnection conexao = new SqlConnection(ClassSecurity.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdH3HJzljHsInLMfbDP8Mk6iZnCtTwMLKgd+ySDR6WmGnFgI0uyLIUqcvKS107S/G6x"));
            _sql = "select Descricao_Usuario from Usuario order by Descricao_Usuario";
            SqlDataAdapter adapter = new SqlDataAdapter(_sql, conexao);
            adapter.SelectCommand.CommandText = _sql;
            try
            {
                conexao.Open();
                DataTable Tabela = new DataTable();
                adapter.Fill(Tabela);
                cbUsuario.DataSource = Tabela;
                cbUsuario.DisplayMember = "Descricao_Usuario";
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

        private void criarBancoDados()
        {
            SqlConnection conexao = new SqlConnection(ClassSecurity.Dry("9UUEoK5YaRaXjDXC9eLqkg7Prh31kSiCYidze0zIx2X787RW+Zpgc9frlclEXhdHJjGrOXTsH7b9NW1qcCpVJxD4wsfhTDR6OXOUSfCqDynZ+0PYEaREWQ=="));
            SqlCommand comando = new SqlCommand("", conexao);
            comando.CommandText = "create database dbGerenciamentoLan";
            try
            {
                conexao.Open();
                comando.ExecuteNonQuery();
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
        private void userDataBase()
        {
            SqlConnection conexao = new SqlConnection(ClassSecurity.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdHJjGrOXTsH7b9NW1qcCpVJxD4wsfhTDR6OXOUSfCqDynZ+0PYEaREWQ=="));
            SqlCommand comando = new SqlCommand("", conexao);
            comando.CommandText = "use dbGerenciamentoLan";
            try
            {
                conexao.Open();
                comando.ExecuteNonQuery();
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
        private void criarTabelaCliente()
        {
            SqlConnection conexao = new SqlConnection(ClassSecurity.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdH3HJzljHsInLMfbDP8Mk6iZnCtTwMLKgd+ySDR6WmGnFgI0uyLIUqcvKS107S/G6x"));
            SqlCommand comando = new SqlCommand("", conexao);
            comando.CommandText = "CREATE TABLE [dbo].[CadastroCliente]([Cod_Cliente] INT NOT NULL PRIMARY KEY, [Nome] VARCHAR(100) NULL, [Logradouro] VARCHAR(100) NOT NULL,[Número] VARCHAR(MAX) NOT NULL)";
            try
            {
                conexao.Open();
                comando.ExecuteNonQuery();
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

        private void criarTabelaGerenciarTempo()
        {
            SqlConnection conexao = new SqlConnection(ClassSecurity.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdH3HJzljHsInLMfbDP8Mk6iZnCtTwMLKgd+ySDR6WmGnFgI0uyLIUqcvKS107S/G6x"));
            SqlCommand comando = new SqlCommand("", conexao);
            comando.CommandText = "CREATE TABLE [dbo].[GerenciarTempo] ([Id_Gerencia] INT NOT NULL PRIMARY KEY IDENTITY(1,1),  [ValorRestante] decimal (18,2) NOT NULL, [Cod_cliente] int NOT NULL FOREIGN KEY([Cod_Cliente]) REFERENCES[dbo].[CadastroCliente] ([Cod_Cliente]))";
            try
            {
                conexao.Open();
                comando.ExecuteNonQuery();
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

        private void criarTabelaUsuario()
        {
            SqlConnection conexao = new SqlConnection(ClassSecurity.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdH3HJzljHsInLMfbDP8Mk6iZnCtTwMLKgd+ySDR6WmGnFgI0uyLIUqcvKS107S/G6x"));
            SqlCommand comando = new SqlCommand("", conexao);
            comando.CommandText = "CREATE TABLE Usuario (Id_Usuario int PRIMARY KEY IDENTITY,Descricao_Usuario varchar(30),Senha_Usuario varchar(MAX))";
            try
            {
                conexao.Open();
                comando.ExecuteNonQuery();
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
    }
}