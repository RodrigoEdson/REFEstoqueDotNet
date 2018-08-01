namespace REFEstoqueDotNetV3.cadastros.EST.SaldoProduto
{
    partial class ViewSaldoProduto
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlInferior = new System.Windows.Forms.FlowLayoutPanel();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.pnlTotal = new REFEstoqueDotNetV3.REF.componentes.REFPanelMessage();
            this.dgvDados = new REFEstoqueDotNetV3.REF.componentes.REFDataGridView();
            this.pnlInferior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlInferior
            // 
            this.pnlInferior.BackgroundImage = global::REFEstoqueDotNetV3.Properties.Resources.degrade_cinza;
            this.pnlInferior.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlInferior.Controls.Add(this.btnVoltar);
            this.pnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInferior.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnlInferior.Location = new System.Drawing.Point(0, 252);
            this.pnlInferior.Name = "pnlInferior";
            this.pnlInferior.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.pnlInferior.Size = new System.Drawing.Size(564, 50);
            this.pnlInferior.TabIndex = 1;
            // 
            // btnVoltar
            // 
            this.btnVoltar.Image = global::REFEstoqueDotNetV3.Properties.Resources.icoVoltar;
            this.btnVoltar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnVoltar.Location = new System.Drawing.Point(476, 3);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(75, 45);
            this.btnVoltar.TabIndex = 4;
            this.btnVoltar.Text = "Voltar (Esc)";
            this.btnVoltar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // pnlTotal
            // 
            this.pnlTotal.BackColor = System.Drawing.SystemColors.Control;
            this.pnlTotal.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.pnlTotal.Location = new System.Drawing.Point(0, 232);
            this.pnlTotal.Name = "pnlTotal";
            this.pnlTotal.Size = new System.Drawing.Size(564, 20);
            this.pnlTotal.status = REFEstoqueDotNetV3.system.MessageStatus.NORMAL;
            this.pnlTotal.TabIndex = 3;
            this.pnlTotal.textMessage = "";
            // 
            // dgvDados
            // 
            this.dgvDados.AllowUserToAddRows = false;
            this.dgvDados.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGreen;
            this.dgvDados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDados.Location = new System.Drawing.Point(0, 0);
            this.dgvDados.MultiSelect = false;
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.ReadOnly = true;
            this.dgvDados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDados.Size = new System.Drawing.Size(564, 232);
            this.dgvDados.TabIndex = 4;
            // 
            // ViewSaldoProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 302);
            this.Controls.Add(this.dgvDados);
            this.Controls.Add(this.pnlTotal);
            this.Controls.Add(this.pnlInferior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ViewSaldoProduto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lista de Saldo do Produto";
            this.Load += new System.EventHandler(this.ViewSaldoProduto_Load);
            this.pnlInferior.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnlInferior;
        private System.Windows.Forms.Button btnVoltar;
        private REF.componentes.REFPanelMessage pnlTotal;
        private REF.componentes.REFDataGridView dgvDados;
    }
}