using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GerenciamentoTempoLan.Properties;

namespace GerenciamentoTempoLan
{
    public partial class FrmGerenciarTempo : Form
    {
        Timer timer = new Timer();
        DataTable dtStopwatches = new DataTable();
        Dictionary<int, Stopwatch> swDct = new Dictionary<int, Stopwatch>();
              
        int Id;
        int Cod, Contador = 1, CodCliente;
        string Nome, HoraTerminar;
        string VConta;
        string C = "";

        public FrmGerenciarTempo(string CodCliente, string Nome, string Valor, string C)
        {
            InitializeComponent();
            this.C = C;
            if (CodCliente != "")
            {
                this.CodCliente = int.Parse(CodCliente);
                txtUsuario.Text = Nome;
                txtValor.Text = Valor;
                VConta = "Valor em Conta";
            }
           

            dtStopwatches.Columns.Add("ID", typeof(int));
            dtStopwatches.Columns.Add("Cód. Cliente", typeof(int));
            dtStopwatches.Columns.Add("Usuário", typeof(string));
            dtStopwatches.Columns.Add("Tempo", typeof(string));
            dtStopwatches.Columns.Add("Tempo Livre", typeof(string));
            dtStopwatches.Columns.Add("Hora Inicial", typeof(string));
            dtStopwatches.Columns.Add("Hora a terminar", typeof(string));
            dtStopwatches.Columns.Add("Valor Conjugado", typeof(string));
            dtStopwatches.Columns.Add("Valor Informado", typeof(string));
            dgv_Gerenciar.DataSource = dtStopwatches;

            foreach (string buttonName in new string[] { "Iniciar Contagem", "Parar Tempo", "Pausar Tempo" })
            {
                DataGridViewButtonColumn colTemp = new DataGridViewButtonColumn();
                colTemp.Name = buttonName + "Col";
                colTemp.HeaderText = buttonName;
                colTemp.Width = 50;
                dgv_Gerenciar.Columns.Add(colTemp);
                timer.Tick += (timer_Tick);
                timer.Interval = 50;
                timer.Start();
            }
        }

        string Vr;

        private void btn_Adicionar_Click(object sender, EventArgs e)
        {
            try
            {                
                txtValor_Leave(sender, e);
                string TU;
                if (cb_Tempo.Checked)
                {
                    TU = "Tempo Livre";
                }
                else
                {
                    TU = "";
                }
                if (!cb_Tempo.Checked)
                {
                    if (CodCliente != 0 && txtUsuario.Text != "" && txtValor.Text != "")
                    {
                        foreach (DataGridViewRow dataGridViewRow in dgv_Gerenciar.Rows)
                        {
                            //Acessar valor da coluna
                            Id = int.Parse(dataGridViewRow.Cells["Cód. Cliente"].Value.ToString());
                            Cod = int.Parse(Id.ToString());

                            if (Cod == CodCliente)
                            {
                                MessageBox.Show("Já foi adicionado tempo ao usuário!", "Mensagem dos sistema 'Gerenciamento Tempos Lan'", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                break;
                            }
                        }

                        int I = Convert.ToInt32(Id);
                        if (I != CodCliente)
                        {
                            if (C == "")
                            {
                                VerificarValor();
                            }
                            DeterminarTempoValor();
                            SomarTempo();
                            Vr = txtValor.Text;
                            Vr = decimal.Parse(Vr).ToString("0.00");
                            if (TC > 0)
                            {
                                double VC = double.Parse(txtValor.Text);
                                TC += VC;                                
                                Vr = TC.ToString();
                                Vr = decimal.Parse(Vr).ToString("0.00");                                
                            }
                            if (C != "")
                            {                               
                                dtStopwatches.Rows.Add(Contador, CodCliente, txtUsuario.Text, "00:00:00.00", TU, DateTime.Now.ToLongTimeString(), HoraTerminar, txtValor.Text, "0,00");
                            }
                            else
                            {                               
                                dtStopwatches.Rows.Add(Contador, CodCliente, txtUsuario.Text, "00:00:00.00", TU, DateTime.Now.ToLongTimeString(), HoraTerminar, Vr, txtValor.Text);
                            }
                            
                            swDct.Add(Contador, new Stopwatch());
                            Contador++;
                            txtUsuario.Clear();
                            txtValor.Clear();
                            CodCliente = 0;
                            VConta = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Preencha todos os campos!", "Mensagem do sistema 'Gerenciamento Tempo Lan'", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    if (CodCliente != 0 && txtUsuario.Text != "")
                    {
                        foreach (DataGridViewRow dataGridViewRow in dgv_Gerenciar.Rows)
                        {
                            //Acessar valor da coluna
                            Id = int.Parse(dataGridViewRow.Cells["Cód. Cliente"].Value.ToString());
                            Cod = int.Parse(Id.ToString());

                            if (Cod == CodCliente)
                            {
                                MessageBox.Show("Já foi adicionado tempo ao usuário!", "Mensagem dos sistema 'Gerenciamento Tempos Lan'", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                break;
                            }
                        }
                        int I = Convert.ToInt32(Id);
                        if (I != CodCliente)
                        {
                            dtStopwatches.Rows.Add(Contador, CodCliente, txtUsuario.Text, "00:00:00.00", TU, DateTime.Now.ToLongTimeString(), "Hora indeterminada", "0,00", "0,00");
                            swDct.Add(Contador, new Stopwatch());
                            Contador++;
                            txtUsuario.Clear();
                            txtValor.Clear();
                            CodCliente = 0;
                            VConta = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Preencha o 'Usuário'!", "Mensagem do sistema 'Gerenciamento Tempo Lan'", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            cb_Tempo.Checked = false;
            cbBuscarTempoGuardado.Checked = false;
            TC = 0;
            C = "";
            Vr = "";
        }

        double TC;
        private void VerificarValor()
        {
            SqlConnection conexao = new SqlConnection(ClassSecurity.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdH3HJzljHsInLMfbDP8Mk6iZnCtTwMLKgd+ySDR6WmGnFgI0uyLIUqcvKS107S/G6x"));
            _sql = "select * from CadastroCliente inner join GerenciarTempo on GerenciarTempo.Cod_cliente = CadastroCliente.Cod_Cliente where CadastroCliente.Cod_Cliente = @Cod_Cliente and GerenciarTempo.ValorRestante > 0.00";
            SqlDataAdapter adapter = new SqlDataAdapter(_sql, conexao);
            adapter.SelectCommand.Parameters.AddWithValue("@Cod_Cliente", CodCliente);
            DataTable Tabela = new DataTable();
            adapter.Fill(Tabela);
            if (Tabela.Rows.Count > 0)
            {
                TC = double.Parse(Tabela.Rows[0]["ValorRestante"].ToString());
            }
            else
            {
                TC = 0;
            }
        }

        //O método vai realizar a soma entre datas
        private void SomarTempo()
        {
            DateTime Horario = DateTime.Now;
            int hr = Horario.Hour, min = Horario.Minute, sec = Horario.Second;
            TimeSpan Horainicio = new TimeSpan(hr, min, sec);
            TimeSpan HoraTermino = new TimeSpan(HH, MM, SS);
            HoraTerminar = HoraTermino.Add(Horainicio).ToString();
        }

        double Valor, tu, tp, vr;
        string Tempo;
        int HH,MM,SS;
        private void DeterminarTempoValor()
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
                tp = TimeSpan.Parse(Tempo).TotalMinutes;
                vr = double.Parse(txtValor.Text);
                if (TC > 0)
                {
                    vr += TC;
                }
                tu = (tp * vr) / Valor;

                var Time = TimeSpan.FromMinutes(tu);
                HH = Time.Hours;
                MM = Time.Minutes;
                SS = Time.Seconds;
            }
        }

        string TimeTermino, TimeParar;
        double ValorRestante;
        double T, Pa, Te;
        private bool ConverterTempoValor()
        {
            Pa = TimeSpan.Parse(TimeParar).TotalMinutes;
            Te = TimeSpan.Parse(TimeTermino).TotalMinutes;

            if (Pa < Te)
            {
                try
                {
                    DateTime TParar = Convert.ToDateTime(TimeParar);
                    int hr = TParar.Hour, min = TParar.Minute, sec = TParar.Second;
                    TimeSpan tP = new TimeSpan(hr, min, sec);
                    DateTime TTermino = Convert.ToDateTime(TimeTermino);
                    hr = TTermino.Hour;
                    min = TTermino.Minute; sec = TTermino.Second;
                    TimeSpan tt = new TimeSpan(hr, min, sec);
                    TimeSpan ts = tt.Subtract(tP);
                    string s = ts.ToString();
                    T = TimeSpan.Parse(s).TotalMinutes;
                    Tempo = Settings.Default["Tempo"].ToString();
                    Valor = double.Parse(Settings.Default["Valor"].ToString());
                    ValorRestante = (T * Valor) / tp;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        string _sql;

        private void GravarTempo()
        {
            SqlConnection conexao = new SqlConnection(ClassSecurity.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdH3HJzljHsInLMfbDP8Mk6iZnCtTwMLKgd+ySDR6WmGnFgI0uyLIUqcvKS107S/G6x"));
            _sql = "Select * from GerenciarTempo where Cod_Cliente = @Cod_Cliente";
            SqlDataAdapter adapter = new SqlDataAdapter(_sql, conexao);
            adapter.SelectCommand.Parameters.AddWithValue("@Cod_Cliente", CodCliente);
            DataTable Tabela = new DataTable();
            adapter.Fill(Tabela);
            if (Tabela.Rows.Count > 0)
            {
                _sql = "Update GerenciarTempo set ValorRestante =  @ValorRestante where Cod_Cliente = @Cod_Cliente";
                SqlCommand comando = new SqlCommand(_sql, conexao);
                comando.Parameters.AddWithValue("@ValorRestante", ValorRestante);
                comando.Parameters.AddWithValue("@Cod_Cliente", CodCliente);
                comando.CommandText = _sql;
                try
                {
                    conexao.Open();
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Tempo armazenado na conta de " + Nome, "Mensagem do sistema 'Gerenciamento Tempo Lan'", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Gerenciamento Tempo Lan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conexao.Close();
                }

            }
            else
            {
                _sql = "Insert into GerenciarTempo values (@ValorRestante, @Cod_Cliente)";
                SqlCommand comando = new SqlCommand(_sql, conexao);
                comando.Parameters.AddWithValue("@ValorRestante", ValorRestante);
                comando.Parameters.AddWithValue("@Cod_Cliente", CodCliente);
                comando.CommandText = _sql;
                try
                {
                    conexao.Open();
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Tempo armazenado na conta de " + Nome, "Mensagem do sistema 'Gerenciamento Tempo Lan'", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Gerenciamento Tempo Lan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conexao.Close();
                }
            }
        }

        private void FrmGerenciarTempo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dgv_Gerenciar.Rows.Count > 0)
            {
                MessageBox.Show("Esta janela está em uso! É necessário que o tempo de cada usuário esteja esgotado ou cancelado pelo administrador", "Mensagem do sistema 'Gerenciamento Tempo Lan'", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void cb_Tempo_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_Tempo.Checked)
            {
                txtValor.Enabled = false;
            }
            else
            {
                txtValor.Enabled = true;
            }
        }

        SoundPlayer sound;
        string Acionar;

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            FrmCadastroCliente cadastroCliente = new FrmCadastroCliente();
            cadastroCliente.ShowDialog();
        }

        private void btnBuscarConversor_Click(object sender, EventArgs e)
        {
            FrmConversao conversao = new FrmConversao();
            conversao.ShowDialog();
        }

        string localToque32 = @"C:\Program Files (x86)\LAS Technology\Gerenciamento Tempo Lan\Som padrao iPhone Toque + download.wav", localToque64 = @"C:\Program Files\LAS Technology\Gerenciamento Tempo Lan\Som padrao iPhone Toque + download.wav";
        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            foreach (DataRow dRow in dtStopwatches.Rows)
            {
                string elapsedString = swDct[(int)dRow["ID"]].Elapsed.ToString(@"hh\:mm\:ss\.ff");
                dRow["Tempo"] = elapsedString;

                foreach (DataGridViewRow row in dgv_Gerenciar.Rows)
                {
                    string id = row.Cells["Cód. Cliente"].Value.ToString();
                    string Nome = row.Cells["Usuário"].Value.ToString();
                    string DataTermino = row.Cells["Hora a terminar"].Value.ToString();
                    string DataNow = DateTime.Now.ToLongTimeString();
                    string TL = row.Cells["Tempo Livre"].Value.ToString();
                    if (DataTermino == DataNow && Acionar == "Acionado" && TL == "")
                    {
                        sound = new SoundPlayer();
                        
                        if (File.Exists(localToque64))
                        {
                            sound.SoundLocation = localToque64;
                        }
                        else
                        {
                            sound.SoundLocation = localToque32;
                        }
                        sound.PlayLooping();
                        Termino = "Acabou";
                        MessageBox.Show("Tempo de: " + Nome + " foi esgotado!", "Mensagem do sistema 'Gerenciamento Tempo Lan'", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       
                    }
                }
            }
            timer.Start();            
        }
        string Termino = "";

        private bool Pesquisarclientes()
        {
            SqlConnection conexao = new SqlConnection(ClassSecurity.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdH3HJzljHsInLMfbDP8Mk6iZnCtTwMLKgd+ySDR6WmGnFgI0uyLIUqcvKS107S/G6x"));
            _sql = "Select * from CadastroCliente";
            SqlDataAdapter Comando = new SqlDataAdapter(_sql, conexao);
            Comando.SelectCommand.CommandText = _sql;
            DataTable Tabela = new DataTable();
            Comando.Fill(Tabela);
            if (Tabela.Rows.Count > 0)
                return true;
            else
                return false;
        }

        private string PesquisarTempoGuardados()
        {
            try
            {
                SqlConnection conexao = new SqlConnection(ClassSecurity.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdH3HJzljHsInLMfbDP8Mk6iZnCtTwMLKgd+ySDR6WmGnFgI0uyLIUqcvKS107S/G6x"));
                SqlDataAdapter adapter = new SqlDataAdapter("", conexao);
                adapter.SelectCommand.CommandText = "select CadastroCliente.Cod_Cliente, CadastroCliente.Nome, CadastroCliente.Logradouro, CadastroCliente.Número, GerenciarTempo.ValorRestante from CadastroCliente inner join GerenciarTempo on GerenciarTempo.Cod_cliente = CadastroCliente.Cod_Cliente where GerenciarTempo.ValorRestante >= 0.00";
                DataTable Tabela = new DataTable();
                adapter.Fill(Tabela);
                if (Tabela.Rows.Count > 0)
                    return "1";
                else
                    return "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "-1";
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbBuscarTempoGuardado.Checked)
            {
                if (PesquisarTempoGuardados() == "1")
                {
                    frmPesquisarClienteTempo pct = new frmPesquisarClienteTempo(false);
                    pct.ShowDialog();
                    if (pct.Valor == "0,00")
                    {
                        MessageBox.Show("Adicione tempo na conta do cliente!", "Mensagem do sistema 'Gerenciamento Tempo Lan'", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else if (PesquisarTempoGuardados() == "1")
                    {
                        if (pct.CodCliente != null)
                        {
                            CodCliente = int.Parse(pct.CodCliente);
                            txtUsuario.Text = pct.Nome;
                            txtValor.Text = pct.Valor;
                            C = pct.C;
                        }
                    }
                }
                else
                    MessageBox.Show("Não há dados de clientes com valores guardados!", "Mensagem do sistema 'Gerenciamento Tempo Lan'", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (Pesquisarclientes() == true)
                {
                    FrmPesquisarCliente pesquisarCliente = new FrmPesquisarCliente();
                    pesquisarCliente.ShowDialog();

                    if (pesquisarCliente.Codigo >= 1)
                    {
                        CodCliente = pesquisarCliente.Codigo;
                        txtUsuario.Text = pesquisarCliente.Nome;
                        C = "";
                    }
                }
                else
                    MessageBox.Show("Não há clientes cadastrados!", "Mensagem do sistema 'Gerenciamento Tempo Lan'", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        Stopwatch swTemp;
        string Tmp;
        decimal ValorVista, ValorConjugado;

        private void cbBuscarTempoGuardado_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBuscarTempoGuardado.Checked)
            {
                txtValor.ReadOnly = true;
                txtValor.BackColor = Color.White;
            }
            else
                txtValor.ReadOnly = false;
        }

        private void dgv_Gerenciar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;

            if (index > -1)
            {
                DataGridViewRow linhas = dgv_Gerenciar.Rows[e.RowIndex];
                Nome = linhas.Cells["Usuário"].Value.ToString();
                CodCliente = int.Parse(linhas.Cells["Cód. Cliente"].Value.ToString());
                TimeTermino = linhas.Cells["Hora a terminar"].Value.ToString();
                TimeParar = DateTime.Now.ToLongTimeString();
                ValorVista = decimal.Parse(linhas.Cells["Valor Informado"].Value.ToString());
                ValorConjugado = decimal.Parse(linhas.Cells["Valor Conjugado"].Value.ToString());
                string TempoLivre = linhas.Cells["Tempo Livre"].Value.ToString();
                 Tmp = linhas.Cells["Tempo"].Value.ToString();
                int cont = e.RowIndex;
                if (cont >= 0)
                {
                    swTemp = swDct[(int)dgv_Gerenciar.Rows[e.RowIndex].Cells["ID"].Value];
                    switch (dgv_Gerenciar.Columns[e.ColumnIndex].HeaderText)
                    {
                        case "Iniciar Contagem":
                            swTemp.Start();
                            Acionar = "Acionado";
                            break;
                        case "Pausar Tempo":
                            if (TempoLivre != "")
                            {
                                swTemp.Stop();
                            }
                            else
                            {
                                Pa = TimeSpan.Parse(TimeParar).TotalMinutes;
                                Te = TimeSpan.Parse(TimeTermino).TotalMinutes;

                                if (Termino != "")
                                {
                                    sound.Stop();
                                    dgv_Gerenciar.Rows.Remove(dgv_Gerenciar.CurrentRow);
                                    VerificarTempo();
                                    Termino = "";
                                }
                                else
                                {
                                    if (Tmp != "00:00:00.00")
                                    {
                                        if (ConverterTempoValor() == true)
                                        {
                                            swTemp.Stop();
                                            GravarTempo();
                                            dgv_Gerenciar.Rows.Remove(dgv_Gerenciar.CurrentRow);
                                            string VR = Convert.ToString(ValorRestante);
                                            VR = decimal.Parse(VR).ToString("0.00");
                                            MessageBox.Show("O cliente tem R$ " + VR + " em sua conta.", "Mensagem do sistema 'Gerenciamento Tempo Lan'", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                    else
                                    {
                                        dgv_Gerenciar.Rows.Remove(dgv_Gerenciar.CurrentRow);
                                    }
                                }
                            }
                            break;
                        case "Parar Tempo":
                            if (TempoLivre == "")
                            {
                                Pa = TimeSpan.Parse(TimeParar).TotalMinutes;
                                Te = TimeSpan.Parse(TimeTermino).TotalMinutes;

                                if (Termino != "")
                                {
                                    sound.Stop();
                                    dgv_Gerenciar.Rows.Remove(dgv_Gerenciar.CurrentRow);
                                    VerificarTempo();
                                    Termino = "";
                                }
                                else
                                {                                    
                                    if (Tmp != "00:00:00.00")
                                    {
                                        if (ConverterTempoValor() == true)
                                        {   swTemp.Stop();
                                            GravarTempo();
                                            dgv_Gerenciar.Rows.Remove(dgv_Gerenciar.CurrentRow);
                                            string VR = Convert.ToString(ValorRestante);
                                            VR = decimal.Parse(VR).ToString("0.00");
                                            MessageBox.Show("O cliente tem R$ " + VR + " em sua conta.", "Mensagem do sistema 'Gerenciamento Tempo Lan'", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                    else
                                    {                                        
                                        dgv_Gerenciar.Rows.Remove(dgv_Gerenciar.CurrentRow);
                                    }                                 
                                }
                            }
                            else
                            {
                                swTemp.Stop();
                                InformarValor();
                                ValorVista = decimal.Parse(ValorPagar);
                                dgv_Gerenciar.Rows.Remove(dgv_Gerenciar.CurrentRow);
                                Termino = "";
                            }
                            break;
                    }
                }
            }
        }

        string ValorPagar;
        private void InformarValor()
        {
            Tempo = Settings.Default["Tempo"].ToString();
            Valor = double.Parse(Settings.Default["Valor"].ToString());
            double tp = TimeSpan.Parse(Tempo).TotalMinutes;
            double vr = TimeSpan.Parse(Tmp).TotalMinutes;

            double tu = (Valor * vr) / tp;

            ValorPagar = tu.ToString();
            ValorPagar = decimal.Parse(ValorPagar).ToString("0.00");
            MessageBox.Show("Valor a Receber: R$ " + ValorPagar);            
        }

        private void VerificarTempo()
        {
            SqlConnection conexao = new SqlConnection(ClassSecurity.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdH3HJzljHsInLMfbDP8Mk6iZnCtTwMLKgd+ySDR6WmGnFgI0uyLIUqcvKS107S/G6x"));
            _sql = "Select * from GerenciarTempo where Cod_Cliente = @Cod_Cliente";
            SqlDataAdapter adapter = new SqlDataAdapter(_sql, conexao);
            adapter.SelectCommand.Parameters.AddWithValue("@Cod_Cliente", CodCliente);
            DataTable Tabela = new DataTable();
            adapter.Fill(Tabela);
            if (Tabela.Rows.Count > 0)
            {
                _sql = "Update GerenciarTempo set ValorRestante = 0.00 where Cod_Cliente = @Cod_Cliente";
                SqlCommand comando = new SqlCommand(_sql, conexao);
                comando.Parameters.AddWithValue("@Cod_Cliente", CodCliente);
                comando.CommandText = _sql;
                try
                {
                    conexao.Open();
                    comando.ExecuteNonQuery();               
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Gerenciamento Tempo Lan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conexao.Close();
                }
            }
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

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            //aceita só caracteres alfabética
            if (char.IsDigit(e.KeyChar) && (e.KeyChar != (char)8))
            {
                e.Handled = true;
            }
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
    }
}
