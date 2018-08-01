namespace REFEstoqueDotNetV3.cadastros.GRL
{
    partial class CadGrupoPessoa
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIdGrupoPessoa = new REFEstoqueDotNetV3.REF.componentes.REFTextBox();
            this.txtDescr = new REFEstoqueDotNetV3.REF.componentes.REFTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(97, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "ID.:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Descrição:";
            // 
            // txtIdGrupoPessoa
            // 
            this.txtIdGrupoPessoa.BackColor = System.Drawing.Color.LightGray;
            this.txtIdGrupoPessoa.beanItemName = "idGrupoPessoa";
            this.txtIdGrupoPessoa.isDataBaseItem = true;
            this.txtIdGrupoPessoa.isFilterItem = true;
            this.txtIdGrupoPessoa.isPK = true;
            this.txtIdGrupoPessoa.Location = new System.Drawing.Point(127, 85);
            this.txtIdGrupoPessoa.MaxLength = 10;
            this.txtIdGrupoPessoa.Name = "txtIdGrupoPessoa";
            this.txtIdGrupoPessoa.ReadOnly = true;
            this.txtIdGrupoPessoa.Size = new System.Drawing.Size(100, 20);
            this.txtIdGrupoPessoa.TabIndex = 4;
            this.txtIdGrupoPessoa.tipo = REFEstoqueDotNetV3.system.TipoTextBox.DISPLAY;
            // 
            // txtDescr
            // 
            this.txtDescr.BackColor = System.Drawing.Color.LightBlue;
            this.txtDescr.beanItemName = "descr";
            this.txtDescr.isDataBaseItem = true;
            this.txtDescr.isFilterItem = true;
            this.txtDescr.isPK = false;
            this.txtDescr.Location = new System.Drawing.Point(127, 115);
            this.txtDescr.MaxLength = 100;
            this.txtDescr.Name = "txtDescr";
            this.txtDescr.Size = new System.Drawing.Size(319, 20);
            this.txtDescr.TabIndex = 0;
            this.txtDescr.tipo = REFEstoqueDotNetV3.system.TipoTextBox.REQUIRED;
            // 
            // CadGrupoPessoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 261);
            this.Controls.Add(this.txtDescr);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIdGrupoPessoa);
            this.Name = "CadGrupoPessoa";
            this.Text = "Cadastro de Grupo de Pessoas";
            this.Controls.SetChildIndex(this.txtIdGrupoPessoa, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtDescr, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private REFEstoqueDotNetV3.REF.componentes.REFTextBox txtIdGrupoPessoa;
        private REFEstoqueDotNetV3.REF.componentes.REFTextBox txtDescr;
    }
}