using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GerenciamentoTempoLan.Properties;

namespace GerenciamentoTempoLan
{
    public partial class FrmGravarTempo : Form
    {
        public FrmGravarTempo()
        {
            InitializeComponent();
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

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            bool Validacao;
            try
            {
                DateTime dt = Convert.ToDateTime(mskTempo.Text);
                Validacao = true;
            }
            catch
            {
                Validacao = false;
            }
            if (!mskTempo.MaskCompleted)
            {
                errorProvider.Clear();
                MessageBox.Show("Complete todo o campo 'Tempo(H)'", "Mensagem do sistema 'Gerenciamento Tempo Lan'", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                errorProvider.SetError(mskTempo, "Campo obrigatório");
                mskTempo.Focus();
                return;
            }
            else if (txtValor.Text == "")
            {
                errorProvider.Clear();
                MessageBox.Show("Preencha o campo 'Valor'", "Mensagem do sistema 'Gerenciamento Tempo Lan'", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                errorProvider.SetError(txtValor, "Campo obrigatório");
                txtValor.Focus();
                return;
            }
            if (Validacao == true)
            {
                Settings.Default["Tempo"] = mskTempo.Text;
                Settings.Default["Valor"] = txtValor.Text;
                Settings.Default.Save();
                MessageBox.Show("Valores gravados com sucesso!", "Mensagem do sistema 'Gerenciamento Tempo Lan'", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data inválida!", "Mensagem do sistema 'Gerenciamento Tempo Lan'", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        ErrorProvider errorProvider = new ErrorProvider();
        private void FrmGravarTempo_Load(object sender, EventArgs e)
        {

            txtValor.Text = Settings.Default["Valor"].ToString();
            mskTempo.Text = Settings.Default["Tempo"].ToString();
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
                MessageBox.Show(ex.Message, "Mensagem de erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mskTempo_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            errorProvider.Clear();
        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }
    }
}
