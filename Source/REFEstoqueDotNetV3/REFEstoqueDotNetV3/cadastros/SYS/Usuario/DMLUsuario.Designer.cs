namespace REFEstoqueDotNetV3.cadastros.SYS.Usuario
{
    partial class DMLUsuario
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtNomePessoa = new REFEstoqueDotNetV3.REF.componentes.REFTextBox();
            this.txtIdPessoa = new REFEstoqueDotNetV3.REF.componentes.REFTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSenha2 = new REFEstoqueDotNetV3.REF.componentes.REFTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSenha1 = new REFEstoqueDotNetV3.REF.componentes.REFTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIdUsuario = new REFEstoqueDotNetV3.REF.componentes.REFTextBox();
            this.pnlMessage = new REFEstoqueDotNetV3.REF.componentes.REFPanelMessage();
            this.txtLogin = new REFEstoqueDotNetV3.REF.componentes.REFTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.Controls.Add(this.button1);
            this.pnlPrincipal.Controls.Add(this.txtNomePessoa);
            this.pnlPrincipal.Controls.Add(this.txtIdPessoa);
            this.pnlPrincipal.Controls.Add(this.label5);
            this.pnlPrincipal.Controls.Add(this.txtSenha2);
            this.pnlPrincipal.Controls.Add(this.label4);
            this.pnlPrincipal.Controls.Add(this.txtSenha1);
            this.pnlPrincipal.Controls.Add(this.label3);
            this.pnlPrincipal.Controls.Add(this.txtIdUsuario);
            this.pnlPrincipal.Controls.Add(this.pnlMessage);
            this.pnlPrincipal.Controls.Add(this.txtLogin);
            this.pnlPrincipal.Controls.Add(this.label1);
            this.pnlPrincipal.Controls.Add(this.label2);
            this.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrincipal.Location = new System.Drawing.Point(0, 0);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(419, 189);
            this.pnlPrincipal.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Image = global::REFEstoqueDotNetV3.Properties.Resources.consultar;
            this.button1.Location = new System.Drawing.Point(138, 82);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 30);
            this.button1.TabIndex = 3;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtNomePessoa
            // 
            this.txtNomePessoa.BackColor = System.Drawing.Color.LightGray;
            this.txtNomePessoa.beanItemName = "descr";
            this.txtNomePessoa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomePessoa.isDataBaseItem = true;
            this.txtNomePessoa.isFilterItem = true;
            this.txtNomePessoa.isPK = false;
            this.txtNomePessoa.Location = new System.Drawing.Point(171, 87);
            this.txtNomePessoa.MaxLength = 100;
            this.txtNomePessoa.Name = "txtNomePessoa";
            this.txtNomePessoa.oldText = null;
            this.txtNomePessoa.ReadOnly = true;
            this.txtNomePessoa.Size = new System.Drawing.Size(214, 20);
            this.txtNomePessoa.TabIndex = 4;
            this.txtNomePessoa.tipo = REFEstoqueDotNetV3.system.TipoTextBox.DISPLAY;
            // 
            // txtIdPessoa
            // 
            this.txtIdPessoa.BackColor = System.Drawing.Color.LightBlue;
            this.txtIdPessoa.beanItemName = "descr";
            this.txtIdPessoa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdPessoa.isDataBaseItem = true;
            this.txtIdPessoa.isFilterItem = true;
            this.txtIdPessoa.isPK = false;
            this.txtIdPessoa.Location = new System.Drawing.Point(82, 87);
            this.txtIdPessoa.MaxLength = 100;
            this.txtIdPessoa.Name = "txtIdPessoa";
            this.txtIdPessoa.oldText = null;
            this.txtIdPessoa.Size = new System.Drawing.Size(55, 20);
            this.txtIdPessoa.TabIndex = 2;
            this.txtIdPessoa.tipo = REFEstoqueDotNetV3.system.TipoTextBox.REQUIRED;
            this.txtIdPessoa.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdPessoa_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Pessoa:";
            // 
            // txtSenha2
            // 
            this.txtSenha2.BackColor = System.Drawing.Color.LightBlue;
            this.txtSenha2.beanItemName = "descr";
            this.txtSenha2.isDataBaseItem = true;
            this.txtSenha2.isFilterItem = true;
            this.txtSenha2.isPK = false;
            this.txtSenha2.Location = new System.Drawing.Point(285, 115);
            this.txtSenha2.MaxLength = 100;
            this.txtSenha2.Name = "txtSenha2";
            this.txtSenha2.oldText = null;
            this.txtSenha2.PasswordChar = '*';
            this.txtSenha2.Size = new System.Drawing.Size(100, 20);
            this.txtSenha2.TabIndex = 6;
            this.txtSenha2.tipo = REFEstoqueDotNetV3.system.TipoTextBox.REQUIRED;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(210, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Conf. Senha:";
            // 
            // txtSenha1
            // 
            this.txtSenha1.BackColor = System.Drawing.Color.LightBlue;
            this.txtSenha1.beanItemName = "descr";
            this.txtSenha1.isDataBaseItem = true;
            this.txtSenha1.isFilterItem = true;
            this.txtSenha1.isPK = false;
            this.txtSenha1.Location = new System.Drawing.Point(82, 115);
            this.txtSenha1.MaxLength = 100;
            this.txtSenha1.Name = "txtSenha1";
            this.txtSenha1.oldText = null;
            this.txtSenha1.PasswordChar = '*';
            this.txtSenha1.Size = new System.Drawing.Size(100, 20);
            this.txtSenha1.TabIndex = 5;
            this.txtSenha1.tipo = REFEstoqueDotNetV3.system.TipoTextBox.REQUIRED;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Senha:";
            // 
            // txtIdUsuario
            // 
            this.txtIdUsuario.BackColor = System.Drawing.Color.LightGray;
            this.txtIdUsuario.beanItemName = null;
            this.txtIdUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdUsuario.isDataBaseItem = true;
            this.txtIdUsuario.isFilterItem = true;
            this.txtIdUsuario.isPK = true;
            this.txtIdUsuario.Location = new System.Drawing.Point(82, 31);
            this.txtIdUsuario.MaxLength = 10;
            this.txtIdUsuario.Name = "txtIdUsuario";
            this.txtIdUsuario.oldText = null;
            this.txtIdUsuario.ReadOnly = true;
            this.txtIdUsuario.Size = new System.Drawing.Size(100, 20);
            this.txtIdUsuario.TabIndex = 0;
            this.txtIdUsuario.tipo = REFEstoqueDotNetV3.system.TipoTextBox.DISPLAY;
            // 
            // pnlMessage
            // 
            this.pnlMessage.BackColor = System.Drawing.SystemColors.Control;
            this.pnlMessage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.pnlMessage.Location = new System.Drawing.Point(0, 169);
            this.pnlMessage.Name = "pnlMessage";
            this.pnlMessage.Size = new System.Drawing.Size(419, 20);
            this.pnlMessage.status = REFEstoqueDotNetV3.system.MessageStatus.NORMAL;
            this.pnlMessage.TabIndex = 13;
            this.pnlMessage.textMessage = "";
            // 
            // txtLogin
            // 
            this.txtLogin.BackColor = System.Drawing.Color.LightBlue;
            this.txtLogin.beanItemName = "descr";
            this.txtLogin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLogin.isDataBaseItem = true;
            this.txtLogin.isFilterItem = true;
            this.txtLogin.isPK = false;
            this.txtLogin.Location = new System.Drawing.Point(82, 59);
            this.txtLogin.MaxLength = 100;
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.oldText = null;
            this.txtLogin.Size = new System.Drawing.Size(100, 20);
            this.txtLogin.TabIndex = 1;
            this.txtLogin.tipo = REFEstoqueDotNetV3.system.TipoTextBox.REQUIRED;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "ID.:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Login:";
            // 
            // DMLUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 234);
            this.Controls.Add(this.pnlPrincipal);
            this.Name = "DMLUsuario";
            this.Text = "Manutenção de Usuários";
            this.Controls.SetChildIndex(this.pnlPrincipal, 0);
            this.pnlPrincipal.ResumeLayout(false);
            this.pnlPrincipal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlPrincipal;
        private REF.componentes.REFTextBox txtIdUsuario;
        private REF.componentes.REFPanelMessage pnlMessage;
        private REF.componentes.REFTextBox txtLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private REF.componentes.REFTextBox txtNomePessoa;
        private REF.componentes.REFTextBox txtIdPessoa;
        private System.Windows.Forms.Label label5;
        private REF.componentes.REFTextBox txtSenha2;
        private System.Windows.Forms.Label label4;
        private REF.componentes.REFTextBox txtSenha1;
        private System.Windows.Forms.Label label3;
    }
}