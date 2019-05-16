namespace GerenciamentoTempoLan
{
    partial class FrmSair
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSair));
            this.btnGerarBackup = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGerarBackup
            // 
            this.btnGerarBackup.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGerarBackup.Location = new System.Drawing.Point(12, 38);
            this.btnGerarBackup.Name = "btnGerarBackup";
            this.btnGerarBackup.Size = new System.Drawing.Size(229, 44);
            this.btnGerarBackup.TabIndex = 0;
            this.btnGerarBackup.Text = "Gerar Backup";
            this.btnGerarBackup.UseVisualStyleBackColor = true;
            this.btnGerarBackup.Click += new System.EventHandler(this.btnGerarBackup_Click);
            // 
            // btnSair
            // 
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSair.Location = new System.Drawing.Point(12, 106);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(229, 44);
            this.btnSair.TabIndex = 1;
            this.btnSair.Text = "Sair e Fechar";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // FrmSair
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(261, 186);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnGerarBackup);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSair";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sair do sistema";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGerarBackup;
        private System.Windows.Forms.Button btnSair;
    }
}