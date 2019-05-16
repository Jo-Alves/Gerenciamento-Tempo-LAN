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
    public partial class FrmConversao : Form
    {
        public FrmConversao()
        {
            InitializeComponent();
        }

        private void txt_Valor_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    if (((int)e.KeyChar) != ((int)Keys.Back))
                        if (e.KeyChar != ',')
                            e.Handled = true;
                        else if (txt_Valor.Text.IndexOf(',') > 0)
                            e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_Valor_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txt_Valor.Text != "")
                {
                    txt_Valor.Text = decimal.Parse(txt_Valor.Text.Trim()).ToString("0.00");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        string Tempo;
        double Valor;

        private void btnConverter_Click(object sender, EventArgs e)
        {
            Tempo = Settings.Default["Tempo"].ToString();
            if (string.IsNullOrEmpty(Tempo))
            {
                MessageBox.Show("Informamos que você não definiu o valor da hora. Para prosseguir informe o valor...", "Aviso do sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                FrmGravarTempo gravarTempo = new FrmGravarTempo();
                gravarTempo.ShowDialog();
                return;
            }
            else
            {
                Valor = double.Parse(Settings.Default["Valor"].ToString());

                if (txt_Valor.Text == "")
                {

                    double tp = TimeSpan.Parse(Tempo).TotalMinutes;
                    double vr = TimeSpan.Parse(dtTempo.Text).TotalMinutes;

                    double tu = (Valor * vr) / tp;

                    txt_Valor.Text = tu.ToString();

                    txt_Valor.Text = decimal.Parse(txt_Valor.Text.Trim()).ToString();
                    if (txt_Valor.Text != "")
                    {
                        txt_Valor.Text = decimal.Parse(txt_Valor.Text.Trim()).ToString("0.00");
                    }
                }
                else
                {

                    double tp = TimeSpan.Parse(Tempo).TotalMinutes;
                    double vr = double.Parse(txt_Valor.Text);

                    double tu = (tp * vr) / Valor;

                    DateTime dt = new DateTime();
                    dt = dt.AddMinutes(tu);
                    dtTempo.Text = dt.ToLongTimeString();
                }
            }
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            dtTempo.Value = new DateTime(2018,08, 26, 0, 0, 0);
            txt_Valor.Clear();
        }
    }
}
