namespace REFEstoqueDotNetV3.cadastros.EST.Venda
{
    partial class SelectCliente
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLogradouro = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGrupo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtApelido = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlInferior = new System.Windows.Forms.FlowLayoutPanel();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnNovaVenda = new System.Windows.Forms.Button();
            this.btnListarVendas = new System.Windows.Forms.Button();
            this.dgvDados = new REFEstoqueDotNetV3.REF.componentes.REFDataGridView();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlInferior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(884, 20);
            this.panel1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.MediumBlue;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(884, 19);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "Selecione o cliente para registrar a venda.";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDocumento);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtLogradouro);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtGrupo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtApelido);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtNome);
            this.groupBox1.Controls.Add(this.txtId);
            this.groupBox1.Controls.Add(this.btnFiltrar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(884, 83);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // txtDocumento
            // 
            this.txtDocumento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDocumento.Location = new System.Drawing.Point(577, 53);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(185, 20);
            this.txtDocumento.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(513, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Documento:";
            // 
            // txtLogradouro
            // 
            this.txtLogradouro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLogradouro.Location = new System.Drawing.Point(316, 53);
            this.txtLogradouro.Name = "txtLogradouro";
            this.txtLogradouro.Size = new System.Drawing.Size(185, 20);
            this.txtLogradouro.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(247, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Logradouro:";
            // 
            // txtGrupo
            // 
            this.txtGrupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGrupo.Location = new System.Drawing.Point(51, 54);
            this.txtGrupo.Name = "txtGrupo";
            this.txtGrupo.Size = new System.Drawing.Size(185, 20);
            this.txtGrupo.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Grupo:";
            // 
            // txtApelido
            // 
            this.txtApelido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtApelido.Location = new System.Drawing.Point(577, 20);
            this.txtApelido.Name = "txtApelido";
            this.txtApelido.Size = new System.Drawing.Size(185, 20);
            this.txtApelido.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(529, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Apelido:";
            // 
            // txtNome
            // 
            this.txtNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNome.Location = new System.Drawing.Point(316, 21);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(185, 20);
            this.txtNome.TabIndex = 1;
            // 
            // txtId
            // 
            this.txtId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtId.Location = new System.Drawing.Point(51, 21);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(100, 20);
            this.txtId.TabIndex = 0;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Image = global::REFEstoqueDotNetV3.Properties.Resources.consultar;
            this.btnFiltrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFiltrar.Location = new System.Drawing.Point(768, 34);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(113, 26);
            this.btnFiltrar.TabIndex = 2;
            this.btnFiltrar.Text = "Consultar (F8)";
            this.btnFiltrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFiltrar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "ID.:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(275, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Nome:";
            // 
            // pnlInferior
            // 
            this.pnlInferior.BackgroundImage = global::REFEstoqueDotNetV3.Properties.Resources.degrade_cinza;
            this.pnlInferior.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlInferior.Controls.Add(this.btnFechar);
            this.pnlInferior.Controls.Add(this.btnNovaVenda);
            this.pnlInferior.Controls.Add(this.btnListarVendas);
            this.pnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInferior.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnlInferior.Location = new System.Drawing.Point(0, 416);
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
            this.btnFechar.TabIndex = 4;
            this.btnFechar.Text = "Fechar (Esc)";
            this.btnFechar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnNovaVenda
            // 
            this.btnNovaVenda.Image = global::REFEstoqueDotNetV3.Properties.Resources.novo;
            this.btnNovaVenda.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNovaVenda.Location = new System.Drawing.Point(684, 3);
            this.btnNovaVenda.Name = "btnNovaVenda";
            this.btnNovaVenda.Size = new System.Drawing.Size(106, 45);
            this.btnNovaVenda.TabIndex = 6;
            this.btnNovaVenda.Text = "Nova Venda (F6)";
            this.btnNovaVenda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNovaVenda.UseVisualStyleBackColor = true;
            this.btnNovaVenda.Click += new System.EventHandler(this.btnNovaVenda_Click);
            // 
            // btnListarVendas
            // 
            this.btnListarVendas.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnListarVendas.Location = new System.Drawing.Point(566, 3);
            this.btnListarVendas.Name = "btnListarVendas";
            this.btnListarVendas.Size = new System.Drawing.Size(112, 45);
            this.btnListarVendas.TabIndex = 5;
            this.btnListarVendas.Text = "Vendas Registradas Para o Cliente (F1)";
            this.btnListarVendas.UseVisualStyleBackColor = true;
            this.btnListarVendas.Click += new System.EventHandler(this.btnListarVendas_Click);
            // 
            // dgvDados
            // 
            this.dgvDados.AllowUserToAddRows = false;
            this.dgvDados.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGreen;
            this.dgvDados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDados.Location = new System.Drawing.Point(0, 103);
            this.dgvDados.MultiSelect = false;
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.ReadOnly = true;
            this.dgvDados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDados.Size = new System.Drawing.Size(884, 313);
            this.dgvDados.TabIndex = 2;
            // 
            // SelectCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 466);
            this.Controls.Add(this.dgvDados);
            this.Controls.Add(this.pnlInferior);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "SelectCliente";
            this.Text = "Seleção de Cliente";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlInferior.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLogradouro;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtGrupo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtApelido;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel pnlInferior;
        private System.Windows.Forms.Button btnFechar;
        private REF.componentes.REFDataGridView dgvDados;
        private System.Windows.Forms.Button btnListarVendas;
        private System.Windows.Forms.Button btnNovaVenda;


    }
}