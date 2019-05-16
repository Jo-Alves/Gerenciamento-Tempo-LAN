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
    public partial class FrmOpcaoDiretorio : Form
    {
        public FrmOpcaoDiretorio()
        {
            InitializeComponent();            
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (cbDiretorio.SelectedIndex >= 0)
            {
                Settings.Default["Disco"] = cbDiretorio.Text;
                Settings.Default.Save();
                Close();
            }
            else
                MessageBox.Show("Informe o local em que será armazenado as possíveis fotos e arquivos de segurança!", "Mensagem do sistema Gerenciamento Sub Sede", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);            
        }

        private void FrmOpcaoDiretorio_Load(object sender, EventArgs e)
        {
            cbDiretorio.Text = Settings.Default["Disco"].ToString();
        }
    }
}
