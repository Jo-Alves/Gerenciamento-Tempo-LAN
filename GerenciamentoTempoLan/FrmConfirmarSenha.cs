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
    public partial class FrmConfirmarSenha : Form
    {
        public FrmConfirmarSenha()
        {
            InitializeComponent();
        }

        public string Senha { get; set; }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNovaSenha.Text) && !string.IsNullOrEmpty(txtDigiteNovamenteSenha.Text))
            {
                if (txtNovaSenha.Text == txtDigiteNovamenteSenha.Text)
                {
                    Senha = ClassSecurityPassword.Pass(txtNovaSenha.Text);
                    this.Close();
                }
                else
                MessageBox.Show("A senha não correspondem! Digite a senha iguais nos campos", "Aviso do sistema Gerenciamento SubSede", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                MessageBox.Show("Preencha todos os campos!", "Aviso do sistema Gerenciamento SubSede", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void FrmConfirmarSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnConfirmar_Click(sender, e);
        }
    }
}
