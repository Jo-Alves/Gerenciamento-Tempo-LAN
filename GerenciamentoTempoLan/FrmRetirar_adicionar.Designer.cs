namespace GerenciamentoTempoLan
{
    partial class FrmRetirar_adicionar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRetirar_adicionar));
            this.label1 = new System.Windows.Forms.Label();
            this.btn = new System.Windows.Forms.Button();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rbAdicionar = new System.Windows.Forms.RadioButton();
            this.rbRetirar = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 19);
            this.label1.TabIndex = 30;
            this.label1.Text = "Cliente:";
            // 
            // btn
            // 
            this.btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn.Image = global::GerenciamentoTempoLan.Properties.Resources.Actions_list_add_icon;
            this.btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn.Location = new System.Drawing.Point(291, 175);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(107, 36);
            this.btn.TabIndex = 1;
            this.btn.Text = "Adicionar";
            this.btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn.UseVisualStyleBackColor = true;
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // txtNome
            // 
            this.txtNome.BackColor = System.Drawing.Color.White;
            this.txtNome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNome.Location = new System.Drawing.Point(51, 66);
            this.txtNome.Name = "txtNome";
            this.txtNome.ReadOnly = true;
            this.txtNome.Size = new System.Drawing.Size(347, 26);
            this.txtNome.TabIndex = 22;
            // 
            // txtValor
            // 
            this.txtValor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValor.Location = new System.Drawing.Point(51, 130);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(103, 26);
            this.txtValor.TabIndex = 0;
            this.txtValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValor.TextChanged += new System.EventHandler(this.txtValor_TextChanged);
            this.txtValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValor_KeyPress);
            this.txtValor.Leave += new System.EventHandler(this.txtValor_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Valor a Retirar ou adicionar(R$):";
            // 
            // rbAdicionar
            // 
            this.rbAdicionar.AutoSize = true;
            this.rbAdicionar.Checked = true;
            this.rbAdicionar.Location = new System.Drawing.Point(15, 12);
            this.rbAdicionar.Name = "rbAdicionar";
            this.rbAdicionar.Size = new System.Drawing.Size(86, 23);
            this.rbAdicionar.TabIndex = 5;
            this.rbAdicionar.TabStop = true;
            this.rbAdicionar.Text = "Adicionar";
            this.rbAdicionar.UseVisualStyleBackColor = true;
            this.rbAdicionar.CheckedChanged += new System.EventHandler(this.rbAdicionar_CheckedChanged);
            // 
            // rbRetirar
            // 
            this.rbRetirar.AutoSize = true;
            this.rbRetirar.Location = new System.Drawing.Point(125, 13);
            this.rbRetirar.Name = "rbRetirar";
            this.rbRetirar.Size = new System.Drawing.Size(68, 23);
            this.rbRetirar.TabIndex = 6;
            this.rbRetirar.Text = "Retirar";
            this.rbRetirar.UseVisualStyleBackColor = true;
            this.rbRetirar.CheckedChanged += new System.EventHandler(this.rbRetirar_CheckedChanged);
            // 
            // FrmRetirar_adicionar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(410, 214);
            this.Controls.Add(this.rbRetirar);
            this.Controls.Add(this.rbAdicionar);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.btn);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FrmRetirar_adicionar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbAdicionar;
        private System.Windows.Forms.RadioButton rbRetirar;
    }
}