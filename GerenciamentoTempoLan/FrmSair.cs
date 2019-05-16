using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GerenciamentoTempoLan.Properties;

namespace GerenciamentoTempoLan
{
    public partial class FrmSair : Form
    {
        public FrmSair()
        {
            InitializeComponent();
        }
        public bool Closed { get; set; }
        string stringConn = ClassSecurity.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdH3HJzljHsInLMfbDP8Mk6iZnCtTwMLKgd+ySDR6WmGnFgI0uyLIUqcvKS107S/G6x"), _sql, LocalPasta = Settings.Default["Disco"].ToString() + @"\Gerenciamento-Tempo-Lan\Arquivo-Backup\";

        private void btnSair_Click(object sender, EventArgs e)
        {
            Closed = true;
            Close();
        }

        private void CriarPasta()
        {
            if (!Directory.Exists(LocalPasta))
            {
                Directory.CreateDirectory(LocalPasta);
            }
        }

        private string InformarHorarioBackup()
        {
            DateTime dateTimeAtual = DateTime.Now;
            string dia = dateTimeAtual.Day.ToString();
            string mes = dateTimeAtual.Month.ToString();
            string ano = dateTimeAtual.Year.ToString();
            string hora = dateTimeAtual.Hour.ToString();
            string minuto = dateTimeAtual.Minute.ToString();
            string segundo = dateTimeAtual.Second.ToString();

            if (dia.Length == 1) {
                dia = "0" + dia;
            }
            if(mes.Length == 1)
            {
                mes = "0" + mes;
            }

            if (hora.Length == 1)
            {
                hora = "0" + hora;
            }
            if (minuto.Length == 1)
            {
                minuto = "0" + minuto;
            }
            if (segundo.Length == 1)
            {
                segundo = "0" + segundo;
            }

            return dia + "-" + mes + "-" + ano + "_" + hora + "_" + minuto + "_" + segundo;

        }

        private void btnGerarBackup_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            CriarPasta();
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "backup database dbGerenciamentoLan to disk = '" + LocalPasta + "Arquivo de Seguranca -" + InformarHorarioBackup() + ".bak'";
            SqlCommand comando = new SqlCommand(_sql, conexao);
            try
            {
                conexao.Open();
                comando.ExecuteNonQuery();
                MessageBox.Show("Backup gerado com sucesso! O arquivo de backup se encontra em '" + LocalPasta + "Arquivo de Seguranca -" + InformarHorarioBackup() + ".bak'", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                conexao.Close();
            }
        }
    }
}
