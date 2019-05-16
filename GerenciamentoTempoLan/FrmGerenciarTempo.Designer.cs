namespace GerenciamentoTempoLan
{
    partial class FrmGerenciarTempo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGerenciarTempo));
            this.label3 = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.dgv_Gerenciar = new System.Windows.Forms.DataGridView();
            this.cb_Tempo = new System.Windows.Forms.CheckBox();
            this.cbBuscarTempoGuardado = new System.Windows.Forms.CheckBox();
            this.btnBuscarConversor = new System.Windows.Forms.Button();
            this.btnCadastro = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btn_Adicionar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Gerenciar)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 19);
            this.label3.TabIndex = 11;
            this.label3.Text = "Valor:";
            // 
            // txtValor
            // 
            this.txtValor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValor.Location = new System.Drawing.Point(31, 127);
            this.txtValor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(107, 26);
            this.txtValor.TabIndex = 10;
            this.txtValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValor_KeyPress);
            this.txtValor.Leave += new System.EventHandler(this.txtValor_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 19);
            this.label1.TabIndex = 9;
            this.label1.Text = "Usuario:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.Color.White;
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuario.Location = new System.Drawing.Point(31, 62);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.ReadOnly = true;
            this.txtUsuario.Size = new System.Drawing.Size(419, 26);
            this.txtUsuario.TabIndex = 8;
            this.txtUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsuario_KeyPress);
            // 
            // dgv_Gerenciar
            // 
            this.dgv_Gerenciar.AllowUserToAddRows = false;
            this.dgv_Gerenciar.AllowUserToDeleteRows = false;
            this.dgv_Gerenciar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_Gerenciar.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Gerenciar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Gerenciar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Gerenciar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgv_Gerenciar.Location = new System.Drawing.Point(31, 175);
            this.dgv_Gerenciar.Name = "dgv_Gerenciar";
            this.dgv_Gerenciar.ReadOnly = true;
            this.dgv_Gerenciar.RowHeadersVisible = false;
            this.dgv_Gerenciar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Gerenciar.Size = new System.Drawing.Size(885, 238);
            this.dgv_Gerenciar.TabIndex = 15;
            this.dgv_Gerenciar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Gerenciar_CellClick);
            // 
            // cb_Tempo
            // 
            this.cb_Tempo.AutoSize = true;
            this.cb_Tempo.Location = new System.Drawing.Point(31, 12);
            this.cb_Tempo.Name = "cb_Tempo";
            this.cb_Tempo.Size = new System.Drawing.Size(99, 23);
            this.cb_Tempo.TabIndex = 16;
            this.cb_Tempo.Text = "Tempo livre";
            this.cb_Tempo.UseVisualStyleBackColor = true;
            this.cb_Tempo.CheckedChanged += new System.EventHandler(this.cb_Tempo_CheckedChanged);
            // 
            // cbBuscarTempoGuardado
            // 
            this.cbBuscarTempoGuardado.AutoSize = true;
            this.cbBuscarTempoGuardado.Location = new System.Drawing.Point(136, 12);
            this.cbBuscarTempoGuardado.Name = "cbBuscarTempoGuardado";
            this.cbBuscarTempoGuardado.Size = new System.Drawing.Size(173, 23);
            this.cbBuscarTempoGuardado.TabIndex = 17;
            this.cbBuscarTempoGuardado.Text = "Buscar tempo guardado";
            this.cbBuscarTempoGuardado.UseVisualStyleBackColor = true;
            this.cbBuscarTempoGuardado.CheckedChanged += new System.EventHandler(this.cbBuscarTempoGuardado_CheckedChanged);
            // 
            // btnBuscarConversor
            // 
            this.btnBuscarConversor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBuscarConversor.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarConversor.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarConversor.Image")));
            this.btnBuscarConversor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarConversor.Location = new System.Drawing.Point(224, 419);
            this.btnBuscarConversor.Name = "btnBuscarConversor";
            this.btnBuscarConversor.Size = new System.Drawing.Size(169, 43);
            this.btnBuscarConversor.TabIndex = 19;
            this.btnBuscarConversor.Text = "Buscar Conversor";
            this.btnBuscarConversor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscarConversor.UseVisualStyleBackColor = true;
            this.btnBuscarConversor.Click += new System.EventHandler(this.btnBuscarConversor_Click);
            // 
            // btnCadastro
            // 
            this.btnCadastro.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCadastro.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastro.Image = global::GerenciamentoTempoLan.Properties.Resources.Hopstarter_Sleek_Xp_Basic_Clients;
            this.btnCadastro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCadastro.Location = new System.Drawing.Point(31, 419);
            this.btnCadastro.Name = "btnCadastro";
            this.btnCadastro.Size = new System.Drawing.Size(187, 43);
            this.btnCadastro.TabIndex = 18;
            this.btnCadastro.Text = "Cadastro de Cliente";
            this.btnCadastro.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCadastro.UseVisualStyleBackColor = true;
            this.btnCadastro.Click += new System.EventHandler(this.btnCadastro_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBuscar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(457, 52);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(98, 43);
            this.btnBuscar.TabIndex = 14;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btn_Adicionar
            // 
            this.btn_Adicionar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Adicionar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Adicionar.Image = global::GerenciamentoTempoLan.Properties.Resources.Actions_list_add_icon;
            this.btn_Adicionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Adicionar.Location = new System.Drawing.Point(145, 119);
            this.btn_Adicionar.Name = "btn_Adicionar";
            this.btn_Adicionar.Size = new System.Drawing.Size(114, 38);
            this.btn_Adicionar.TabIndex = 12;
            this.btn_Adicionar.Text = "Adicionar";
            this.btn_Adicionar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Adicionar.UseVisualStyleBackColor = true;
            this.btn_Adicionar.Click += new System.EventHandler(this.btn_Adicionar_Click);
            // 
            // FrmGerenciarTempo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(943, 489);
            this.Controls.Add(this.btnBuscarConversor);
            this.Controls.Add(this.btnCadastro);
            this.Controls.Add(this.cbBuscarTempoGuardado);
            this.Controls.Add(this.cb_Tempo);
            this.Controls.Add(this.dgv_Gerenciar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btn_Adicionar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUsuario);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FrmGerenciarTempo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerenciar Tempo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmGerenciarTempo_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Gerenciar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Adicionar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgv_Gerenciar;
        private System.Windows.Forms.CheckBox cb_Tempo;
        private System.Windows.Forms.CheckBox cbBuscarTempoGuardado;
        private System.Windows.Forms.Button btnCadastro;
        private System.Windows.Forms.Button btnBuscarConversor;
    }
}