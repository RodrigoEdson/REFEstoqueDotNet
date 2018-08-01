using System;
using System.Drawing;
using System.Windows.Forms;
using REFEstoqueDotNetV3.system;
using REFEstoqueDotNetV3.REF.componentes;

namespace REFEstoqueDotNetV3.REF.componentes
{
    class REFPanelMessage : Panel
    {
        private Label _textLabel = new Label();
        private MessageStatus _status;

        public REFPanelMessage()
        {
            this.status = MessageStatus.NORMAL;

            this.textLabel.AutoSize = true;
            this.textLabel.Size = new Size(35, 13);
            this.textLabel.TabIndex = 0;

            this.Controls.Add(this.textLabel);
            this.Size = new Size(100, 20);
            this.Dock = DockStyle.Bottom;
            this.textLabel.Resize += new System.EventHandler(this.posicionar);
        }


        private void posicionar(object sender, EventArgs e)
        {
            this.textLabel.Location = new Point((this.Size.Width - this.textLabel.Size.Width) / 2, 1);
        }

        public Label textLabel
        {
            get { return _textLabel; }
            set { _textLabel = value; }
        }

        public string textMessage
        {
            get { return textLabel.Text; }
            set { textLabel.Text = value; }
        }

        public MessageStatus status
        {
            get { return _status; }
            set
            {
                _status = value;
                this.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
                switch (_status)
                {
                    case MessageStatus.SUCCESS:
                        this.BackColor = Color.LightGreen;
                        this.textLabel.ForeColor = Color.White;
                        this.textMessage = "Informações salvas com sucesso.";
                        break;
                    case MessageStatus.ERROR:
                        this.BackColor = Color.OrangeRed;
                        this.textLabel.ForeColor = Color.Black;
                        this.textMessage = "Erro ao salvar informações.";
                        break;
                    case MessageStatus.ALERT:
                        this.BackColor = Color.Yellow;
                        this.textLabel.ForeColor = Color.Black;
                        this.textMessage = "Alerta! Verifique o ocorrido!";
                        break;
                    case MessageStatus.NORMAL:
                        this.BackColor = SystemColors.Control;
                        this.textLabel.ForeColor = Color.Black;
                        this.textMessage = "";
                        break;
                }
            }
        }
    }
}
