namespace REFEstoqueDotNetV3.cadastros
{
    partial class BaseDMLForm
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
            this.pnlBotoes = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.pnlBotoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBotoes
            // 
            this.pnlBotoes.BackgroundImage = global::REFEstoqueDotNetV3.Properties.Resources.degrade_cinza;
            this.pnlBotoes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlBotoes.Controls.Add(this.btnCancelar);
            this.pnlBotoes.Controls.Add(this.btnConfirmar);
            this.pnlBotoes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotoes.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnlBotoes.Location = new System.Drawing.Point(0, 260);
            this.pnlBotoes.Margin = new System.Windows.Forms.Padding(0);
            this.pnlBotoes.Name = "pnlBotoes";
            this.pnlBotoes.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.pnlBotoes.Size = new System.Drawing.Size(506, 45);
            this.pnlBotoes.TabIndex = 2;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::REFEstoqueDotNetV3.Properties.Resources.icoVoltar;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancelar.Location = new System.Drawing.Point(418, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 40);
            this.btnCancelar.TabIndex = 0;
            this.btnCancelar.Text = "&Voltar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Image = global::REFEstoqueDotNetV3.Properties.Resources.icon_includ;
            this.btnConfirmar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnConfirmar.Location = new System.Drawing.Point(337, 3);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(75, 40);
            this.btnConfirmar.TabIndex = 1;
            this.btnConfirmar.Text = "&Salvar";
            this.btnConfirmar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // BaseDMLForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 305);
            this.Controls.Add(this.pnlBotoes);
            this.Name = "BaseDMLForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.pnlBotoes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnlBotoes;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnConfirmar;
    }
}