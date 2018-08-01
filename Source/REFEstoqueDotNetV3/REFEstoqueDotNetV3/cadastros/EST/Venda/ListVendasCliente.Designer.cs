namespace REFEstoqueDotNetV3.cadastros.EST.Venda
{
    partial class ListVendasCliente
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
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.pnlInferior = new System.Windows.Forms.FlowLayoutPanel();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnVizVendas = new System.Windows.Forms.Button();
            this.dgvDados = new REFEstoqueDotNetV3.REF.componentes.REFDataGridView();
            this.pnlInferior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTitulo
            // 
            this.txtTitulo.BackColor = System.Drawing.Color.MediumBlue;
            this.txtTitulo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitulo.ForeColor = System.Drawing.Color.White;
            this.txtTitulo.Location = new System.Drawing.Point(0, 0);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.ReadOnly = true;
            this.txtTitulo.Size = new System.Drawing.Size(884, 19);
            this.txtTitulo.TabIndex = 5;
            this.txtTitulo.Text = "Lista das vendas registradas para Rodrigo Edson Fernandes";
            this.txtTitulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pnlInferior
            // 
            this.pnlInferior.BackgroundImage = global::REFEstoqueDotNetV3.Properties.Resources.degrade_cinza;
            this.pnlInferior.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlInferior.Controls.Add(this.btnFechar);
            this.pnlInferior.Controls.Add(this.btnCancelar);
            this.pnlInferior.Controls.Add(this.btnVizVendas);
            this.pnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInferior.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnlInferior.Location = new System.Drawing.Point(0, 312);
            this.pnlInferior.Name = "pnlInferior";
            this.pnlInferior.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.pnlInferior.Size = new System.Drawing.Size(884, 50);
            this.pnlInferior.TabIndex = 1;
            // 
            // btnFechar
            // 
            this.btnFechar.Image = global::REFEstoqueDotNetV3.Properties.Resources.fechar;
            this.btnFechar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFechar.Location = new System.Drawing.Point(796, 3);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 45);
            this.btnFechar.TabIndex = 0;
            this.btnFechar.Text = "Fechar (Esc)";
            this.btnFechar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::REFEstoqueDotNetV3.Properties.Resources.excluir;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancelar.Location = new System.Drawing.Point(675, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(115, 45);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar Venda (F3)";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnVizVendas
            // 
            this.btnVizVendas.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnVizVendas.Location = new System.Drawing.Point(594, 3);
            this.btnVizVendas.Name = "btnVizVendas";
            this.btnVizVendas.Size = new System.Drawing.Size(75, 45);
            this.btnVizVendas.TabIndex = 1;
            this.btnVizVendas.Text = "Visualizar Venda (F1)";
            this.btnVizVendas.UseVisualStyleBackColor = true;
            this.btnVizVendas.Click += new System.EventHandler(this.btnVizVendas_Click);
            // 
            // dgvDados
            // 
            this.dgvDados.AllowUserToAddRows = false;
            this.dgvDados.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGreen;
            this.dgvDados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDados.Location = new System.Drawing.Point(0, 19);
            this.dgvDados.MultiSelect = false;
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.ReadOnly = true;
            this.dgvDados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDados.Size = new System.Drawing.Size(884, 293);
            this.dgvDados.TabIndex = 0;
            // 
            // ListVendasCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 362);
            this.Controls.Add(this.dgvDados);
            this.Controls.Add(this.pnlInferior);
            this.Controls.Add(this.txtTitulo);
            this.Name = "ListVendasCliente";
            this.Text = "Lista das vendas registradas para o cliente";
            this.pnlInferior.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.FlowLayoutPanel pnlInferior;
        private System.Windows.Forms.Button btnFechar;
        private REF.componentes.REFDataGridView dgvDados;
        private System.Windows.Forms.Button btnVizVendas;
        private System.Windows.Forms.Button btnCancelar;
    }
}