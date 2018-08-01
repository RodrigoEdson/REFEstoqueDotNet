using System.Drawing;
using System.Windows.Forms;
using REFEstoqueDotNetV3.system;

namespace REFEstoqueDotNetV3.REF.componentes
{
    public class REFDateTimePicker : DateTimePicker
    {
        private TipoTextBox _tipo;
        private TipoDateTimePicker _tipoDado;


        public REFDateTimePicker() 
        {
            this.tipo = TipoTextBox.NORMAL;
            this.tipoDado = TipoDateTimePicker.DATE;
        }

        public TipoTextBox tipo
        {
            get { return _tipo; }
            set
            {
                _tipo = value;
                switch (_tipo)
                {
                    case TipoTextBox.DISABLE:
                        this.Enabled = false;
                        this.BackColor = Color.White;
                        break;
                    case TipoTextBox.DISPLAY:
                        this.Enabled = false;
                        this.BackColor = Color.LightGray;
                        break;
                    case TipoTextBox.NORMAL:
                        this.Enabled = true;
                        this.BackColor = Color.White;
                        break;
                    case TipoTextBox.READY_ONLY:
                        this.Enabled = false;
                        this.BackColor = Color.White;
                        break;
                    case TipoTextBox.REQUIRED:
                        this.Enabled = true;
                        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        this.BackColor = Color.LightBlue;
                        break;
                }
            }
        }

        public TipoDateTimePicker tipoDado
        {
            get { return _tipoDado; }
            set
            {
                _tipoDado = value;
                this.Format = DateTimePickerFormat.Custom;
                switch (_tipoDado)
                {
                    case TipoDateTimePicker.DATE:
                        this.CustomFormat = "dd/MM/yyyy";
                        break;
                    case TipoDateTimePicker.DATETIME:
                        this.CustomFormat = "dd/MM/yyyy HH:mm:ss";
                        break;
                    case TipoDateTimePicker.TIME:
                        this.CustomFormat = "5HH:mm:ss";
                        break;
                }
            }
        }
    }
}
