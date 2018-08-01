namespace REFEstoqueDotNetV3.cadastros.GRL.GrupoProduto
{
    partial class DMLGrupoProduto
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
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.pnlMessage = new REFEstoqueDotNetV3.REF.componentes.REFPanelMessage();
            this.txtDescr = new REFEstoqueDotNetV3.REF.componentes.REFTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIdGrupoProduto = new REFEstoqueDotNetV3.REF.componentes.REFTextBox();
            this.pnlPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.Controls.Add(this.pnlMessage);
            this.pnlPrincipal.Controls.Add(this.txtDescr);
            this.pnlPrincipal.Controls.Add(this.label1);
            this.pnlPrincipal.Controls.Add(this.label2);
            this.pnlPrincipal.Controls.Add(this.txtIdGrupoProduto);
            this.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrincipal.Location = new System.Drawing.Point(0, 0);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(506, 260);
            this.pnlPrincipal.TabIndex = 0;
            // 
            // pnlMessage
            // 
            this.pnlMessage.BackColor = System.Drawing.SystemColors.Control;
            this.pnlMessage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.pnlMessage.Location = new System.Drawing.Point(0, 240);
            this.pnlMessage.Name = "pnlMessage";
            this.pnlMessage.Size = new System.Drawing.Size(506, 20);
            this.pnlMessage.status = REFEstoqueDotNetV3.system.MessageStatus.NORMAL;
            this.pnlMessage.TabIndex = 13;
            this.pnlMessage.textMessage = "";
            // 
            // txtDescr
            // 
            this.txtDescr.BackColor = System.Drawing.Color.LightBlue;
            this.txtDescr.beanItemName = "descr";
            this.txtDescr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescr.isDataBaseItem = true;
            this.txtDescr.isFilterItem = true;
            this.txtDescr.isPK = false;
            this.txtDescr.Location = new System.Drawing.Point(90, 95);
            this.txtDescr.MaxLength = 100;
            this.txtDescr.Name = "txtDescr";
            this.txtDescr.oldText = null;
            this.txtDescr.Size = new System.Drawing.Size(319, 20);
            this.txtDescr.TabIndex = 1;
            this.txtDescr.tipo = REFEstoqueDotNetV3.system.TipoTextBox.REQUIRED;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "ID.:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Descrição:";
            // 
            // txtIdGrupoProduto
            // 
            this.txtIdGrupoProduto.BackColor = System.Drawing.Color.LightGray;
            this.txtIdGrupoProduto.beanItemName = "idGrupoPessoa";
            this.txtIdGrupoProduto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdGrupoProduto.isDataBaseItem = true;
            this.txtIdGrupoProduto.isFilterItem = true;
            this.txtIdGrupoProduto.isPK = true;
            this.txtIdGrupoProduto.Location = new System.Drawing.Point(90, 65);
            this.txtIdGrupoProduto.MaxLength = 10;
            this.txtIdGrupoProduto.Name = "txtIdGrupoProduto";
            this.txtIdGrupoProduto.oldText = null;
            this.txtIdGrupoProduto.ReadOnly = true;
            this.txtIdGrupoProduto.Size = new System.Drawing.Size(100, 20);
            this.txtIdGrupoProduto.TabIndex = 0;
            this.txtIdGrupoProduto.tipo = REFEstoqueDotNetV3.system.TipoTextBox.DISPLAY;
            // 
            // DMLGrupoProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 305);
            this.Controls.Add(this.pnlPrincipal);
            this.Name = "DMLGrupoProduto";
            this.Text = "DMLGrupoProduto";
            this.Controls.SetChildIndex(this.pnlPrincipal, 0);
            this.pnlPrincipal.ResumeLayout(false);
            this.pnlPrincipal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlPrincipal;
        private REF.componentes.REFPanelMessage pnlMessage;
        private REF.componentes.REFTextBox txtDescr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private REF.componentes.REFTextBox txtIdGrupoProduto;
    }
}