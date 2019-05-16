namespace GerenciamentoTempoLan
{
    partial class FrmTelaPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTelaPrincipal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuCadastro = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuCadastroCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuCadastroTempo = new System.Windows.Forms.ToolStripMenuItem();
            this.movimentaaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuGerenciarTempo = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarClienteComTempoGuardadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conversãoDeValoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSair = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.opçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trocarOpçãoDeDiretórioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opçõesToolStripMenuItem,
            this.MenuCadastro,
            this.movimentaaçãoToolStripMenuItem,
            this.MenuSair});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(803, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuCadastro
            // 
            this.MenuCadastro.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuCadastroCliente,
            this.MenuCadastroTempo});
            this.MenuCadastro.Name = "MenuCadastro";
            this.MenuCadastro.Size = new System.Drawing.Size(66, 20);
            this.MenuCadastro.Text = "Cadastro";
            // 
            // MenuCadastroCliente
            // 
            this.MenuCadastroCliente.Name = "MenuCadastroCliente";
            this.MenuCadastroCliente.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.MenuCadastroCliente.Size = new System.Drawing.Size(153, 22);
            this.MenuCadastroCliente.Text = "Cliente";
            this.MenuCadastroCliente.Click += new System.EventHandler(this.MenuCadastroCliente_Click);
            // 
            // MenuCadastroTempo
            // 
            this.MenuCadastroTempo.Name = "MenuCadastroTempo";
            this.MenuCadastroTempo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.MenuCadastroTempo.Size = new System.Drawing.Size(153, 22);
            this.MenuCadastroTempo.Text = "Tempo";
            this.MenuCadastroTempo.Click += new System.EventHandler(this.MenuCadastroTempo_Click);
            // 
            // movimentaaçãoToolStripMenuItem
            // 
            this.movimentaaçãoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuGerenciarTempo,
            this.buscarClienteComTempoGuardadosToolStripMenuItem,
            this.conversãoDeValoresToolStripMenuItem});
            this.movimentaaçãoToolStripMenuItem.Name = "movimentaaçãoToolStripMenuItem";
            this.movimentaaçãoToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
            this.movimentaaçãoToolStripMenuItem.Text = "Movimentação";
            // 
            // MenuGerenciarTempo
            // 
            this.MenuGerenciarTempo.Name = "MenuGerenciarTempo";
            this.MenuGerenciarTempo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.MenuGerenciarTempo.Size = new System.Drawing.Size(314, 22);
            this.MenuGerenciarTempo.Text = "Gerenciar Tempo do Usuário";
            this.MenuGerenciarTempo.Click += new System.EventHandler(this.MenuGerenciarTempo_Click);
            // 
            // buscarClienteComTempoGuardadosToolStripMenuItem
            // 
            this.buscarClienteComTempoGuardadosToolStripMenuItem.Name = "buscarClienteComTempoGuardadosToolStripMenuItem";
            this.buscarClienteComTempoGuardadosToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.buscarClienteComTempoGuardadosToolStripMenuItem.Size = new System.Drawing.Size(314, 22);
            this.buscarClienteComTempoGuardadosToolStripMenuItem.Text = "Buscar Cliente com tempo guardados";
            this.buscarClienteComTempoGuardadosToolStripMenuItem.Click += new System.EventHandler(this.buscarClienteComTempoGuardadosToolStripMenuItem_Click);
            // 
            // conversãoDeValoresToolStripMenuItem
            // 
            this.conversãoDeValoresToolStripMenuItem.Name = "conversãoDeValoresToolStripMenuItem";
            this.conversãoDeValoresToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.conversãoDeValoresToolStripMenuItem.Size = new System.Drawing.Size(314, 22);
            this.conversãoDeValoresToolStripMenuItem.Text = "Conversão de Valores";
            this.conversãoDeValoresToolStripMenuItem.Click += new System.EventHandler(this.conversãoDeValoresToolStripMenuItem_Click);
            // 
            // MenuSair
            // 
            this.MenuSair.Name = "MenuSair";
            this.MenuSair.Size = new System.Drawing.Size(38, 20);
            this.MenuSair.Text = "Sair";
            this.MenuSair.Click += new System.EventHandler(this.MenuSair_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::GerenciamentoTempoLan.Properties.Resources.shutterstock_223373068_810x440;
            this.pictureBox1.Location = new System.Drawing.Point(136, 67);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(606, 295);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // opçõesToolStripMenuItem
            // 
            this.opçõesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trocarOpçãoDeDiretórioToolStripMenuItem});
            this.opçõesToolStripMenuItem.Name = "opçõesToolStripMenuItem";
            this.opçõesToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.opçõesToolStripMenuItem.Text = "Opções";
            // 
            // trocarOpçãoDeDiretórioToolStripMenuItem
            // 
            this.trocarOpçãoDeDiretórioToolStripMenuItem.Name = "trocarOpçãoDeDiretórioToolStripMenuItem";
            this.trocarOpçãoDeDiretórioToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.trocarOpçãoDeDiretórioToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.trocarOpçãoDeDiretórioToolStripMenuItem.Text = "Trocar opção de diretório";
            this.trocarOpçãoDeDiretórioToolStripMenuItem.Click += new System.EventHandler(this.MenuTrocarOpcaoDeDiretorio_Click);
            // 
            // FrmTelaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(803, 453);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmTelaPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Gerenciamento de tempo - Las Technology (lastechnology2018@gmail.com)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmTelaPrincipal_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmTelaPrincipal_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuCadastro;
        private System.Windows.Forms.ToolStripMenuItem MenuCadastroCliente;
        private System.Windows.Forms.ToolStripMenuItem MenuCadastroTempo;
        private System.Windows.Forms.ToolStripMenuItem movimentaaçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuGerenciarTempo;
        private System.Windows.Forms.ToolStripMenuItem MenuSair;
        private System.Windows.Forms.ToolStripMenuItem buscarClienteComTempoGuardadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conversãoDeValoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opçõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trocarOpçãoDeDiretórioToolStripMenuItem;
    }
}