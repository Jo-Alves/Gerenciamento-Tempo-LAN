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

    public partial class FrmCarregamentoSistema : Form
    {
        public FrmCarregamentoSistema()
        {
            InitializeComponent();
        }

        private void timerCarregar_Tick(object sender, EventArgs e)
        {
            if (pB_Carregar.Value < 100)
            {
                pB_Carregar.Value += 2;
            }
            else
            {
                timerCarregar.Enabled = false;
                this.Visible = false;
                FrmAutenticarUsuario autenticacao = new FrmAutenticarUsuario();
                autenticacao.ShowDialog();
            }
        }
    }
}