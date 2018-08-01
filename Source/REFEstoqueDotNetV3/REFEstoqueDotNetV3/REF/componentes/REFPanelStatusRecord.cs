using System;
using System.Drawing;
using System.Windows.Forms;
using REFEstoqueDotNetV3.system;

namespace REFEstoqueDotNetV3.REF.componentes
{
    public class REFPanelStatusRecord : Panel
    {
        private DataStatus _dataStatus;
        private Label _lblStatus;

        public REFPanelStatusRecord()
            : base()
        {
            this.Resize += new System.EventHandler(this.posicionar);

            this._lblStatus = new System.Windows.Forms.Label();
            this._lblStatus.AutoSize = true;
            this._lblStatus.Size = new System.Drawing.Size(35, 13);
            this._lblStatus.TabIndex = 0;

            this.Controls.Add(this._lblStatus);
            this.dataStatus = DataStatus.EXIBICAO;
            this._lblStatus.Resize += new System.EventHandler(this.posicionar);
        }

        private void posicionar(object sender, EventArgs e)
        {
            this._lblStatus.Location = new Point((this.Size.Width - this._lblStatus.Size.Width) / 2, 1);
        }
       
        public DataStatus dataStatus
        {
            get { return _dataStatus; }
            set
            {
                _dataStatus = value;
                switch (_dataStatus)
                {
                    case DataStatus.ALTERADO:
                        this.BackColor = Color.Yellow;
                        this._lblStatus.Text = "Registro Alterado";
                        this._lblStatus.Visible = true;
                        break;
                    case DataStatus.EXCLUIDO:
                        this.BackColor = Color.LightCoral;
                        this._lblStatus.Text = "Registro Excluido";
                        this._lblStatus.Visible = true;
                        break;
                    case DataStatus.EXIBICAO:
                        this.BackColor = SystemColors.Control;
                        this._lblStatus.Text = "Registro não Alterado";
                        this._lblStatus.Visible = false;
                        break;
                    case DataStatus.NOVO:
                        this.BackColor = Color.LawnGreen;
                        this._lblStatus.Text = "Registro Novo";
                        this._lblStatus.Visible = true;
                        break;
                }
            }
        }
    }

}
