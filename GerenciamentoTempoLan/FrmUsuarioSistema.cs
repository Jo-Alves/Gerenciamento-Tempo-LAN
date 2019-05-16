using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GerenciamentoTempoLan
{
    public partial class FrmUsuarioSistema : Form
    {
        public FrmUsuarioSistema()
        {
            InitializeComponent();
        }

        int id;
        // instância da classUsuario
        ClassUsuario usuario = new ClassUsuario();

        // instância do objeto ErroProvider
        ErrorProvider errorProvider = new ErrorProvider();

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                errorProvider.Clear();
                MessageBox.Show("O nome do usuário deve ser preenchido!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                errorProvider.SetError(txtUsuario, "Campo obrigatório");
                txtUsuario.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(txtSenha.Text))
            {
                errorProvider.Clear();
                MessageBox.Show("A senha deve ser informada!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                errorProvider.SetError(txtSenha, "Campo obrigatório");
                txtSenha.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(txtCloneSenha.Text) && !string.IsNullOrEmpty(txtSenha.Text))
            {
                errorProvider.Clear();
                MessageBox.Show("Repita a senha novamente!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                errorProvider.SetError(txtCloneSenha, "Campo obrigatório");
                txtCloneSenha.Focus();
                return;
            }
            
            else
            {
                if (txtSenha.Text == txtCloneSenha.Text)
                {
                    try
                    {
                        usuario._usuario = txtUsuario.Text.Trim();
                        usuario._senha = ClassSecurityPassword.Pass(txtSenha.Text);
                        if (usuario.Salvar() == false)
                        {
                            MessageBox.Show("Usuario e senha cadastrado com sucesso!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimparCampos();
                            txtUsuario.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Usuário já existe no banco de dados! Crie outro usuário!", "Aviso do sistema Gerenciamento Subsede", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Senhas não correspondem!", "Aviso do sistema Gerenciamento subSede", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }  

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                errorProvider.Clear();
                MessageBox.Show("O nome do usuário deve ser preenchido!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                errorProvider.SetError(txtUsuario, "Campo obrigatório");
                txtUsuario.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(txtSenha.Text))
            {
                errorProvider.Clear();
                MessageBox.Show("A senha deve ser informada!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                errorProvider.SetError(txtSenha, "Campo obrigatório");
                txtSenha.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(txtCloneSenha.Text) && !string.IsNullOrEmpty(txtSenha.Text))
            {
                errorProvider.Clear();
                MessageBox.Show("Repita a senha novamente!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                errorProvider.SetError(txtCloneSenha, "Campo obrigatório");
                txtCloneSenha.Focus();
                return;
            }
            else
            {
                if (txtSenha.Text == txtCloneSenha.Text)
                {
                    try
                        // Antes da alteração o sistema irá fazer uma autenticação
                    {   usuario._usuario = txtUsuario.Text.Trim();                        
                        usuario._senha = ClassSecurityPassword.Pass(txtSenha.Text.Trim());

                        if (usuario.Autenticar() == true)
                        {
                            FrmConfirmarSenha confirmarSenha = new FrmConfirmarSenha();
                            confirmarSenha.ShowDialog();
                            if (!string.IsNullOrEmpty(confirmarSenha.Senha))
                            {
                                usuario._usuario = txtUsuario.Text.Trim();
                                usuario._senha = confirmarSenha.Senha;
                                usuario.editar();
                                MessageBox.Show("Usuario e senha alterado com sucesso!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LimparCampos();
                                txtUsuario.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Usuário ou Senha incorreto! Tente novamente.", "Aviso do sistema Gerenciamento SubSede", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Senhas não correspondem!", "Aviso do sistema Gerenciamento subSede", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                errorProvider.Clear();
                MessageBox.Show("O nome do usuário deve ser preenchido!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                errorProvider.SetError(txtUsuario, "Campo obrigatório");
                txtUsuario.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(txtSenha.Text))
            {
                errorProvider.Clear();
                MessageBox.Show("A senha deve ser informada!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                errorProvider.SetError(txtSenha, "Campo obrigatório");
                txtSenha.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(txtCloneSenha.Text) && !string.IsNullOrEmpty(txtSenha.Text))
            {
                errorProvider.Clear();
                MessageBox.Show("Repita a senha novamente!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                errorProvider.SetError(txtCloneSenha, "Campo obrigatório");
                txtCloneSenha.Focus();
                return;
            }
            else
            {
                try
                {
                    usuario._usuario = txtUsuario.Text.Trim();
                    usuario._senha = ClassSecurityPassword.Pass(txtSenha.Text.Trim());
                    if (usuario.Autenticar() == true)
                    {
                        if (MessageBox.Show("Tem certeza que deseja excluir o Usuário " + txtUsuario.Text.Trim() + "?", "Aviso do sistema Gerenciamento SubSede", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            // Antes da alteração o sistema irá fazer uma autenticação

                            usuario._usuario = txtUsuario.Text.Trim();
                            usuario._senha = ClassSecurityPassword.Pass(txtSenha.Text.Trim());
                            usuario.Excluir();
                            MessageBox.Show("Usuario excluido com sucesso!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimparCampos();
                            txtUsuario.Focus();
                        }
                    }
                    else
                        MessageBox.Show("Usuário ou senha incorreto! Tente novamente!", "Aviso do sistema Gerenciamento SubSede", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LimparCampos()
        {
            foreach (Control camposTexto in this.Controls)
            {
                if (camposTexto is TextBox)
                {
                    camposTexto.Text = "";
                }
                id = 0;
                errorProvider.Clear();
            }
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void txtCloneSenha_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void FrmUsuarioSistema_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btnSalvar_Click(sender, e);
            }

             if (e.KeyCode == Keys.F2)
            {
                btnAlterar_Click(sender, e);
            }

            if (e.KeyCode == Keys.F3)
            {
                btnExcluir_Click(sender, e);
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Aceita letras e broqueia número
            if (char.IsDigit(e.KeyChar) && (e.KeyChar != (char)8))
            {
                e.Handled = true;
            }
        }
    }
}
