using System.Drawing;
using System.Windows.Forms;
using REFEstoqueDotNetV3.system;

namespace REFEstoqueDotNetV3.REF.componentes
{
    public class REFMaskedTextBox : MaskedTextBox
    {
        private TipoTextBox _tipo;

        public REFMaskedTextBox()
        {
            this.Mask = "###,###,##0.00";
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
                        this.ReadOnly = true;
                        this.BackColor = Color.White;
                        break;
                    case TipoTextBox.DISPLAY:
                        this.Enabled = false;
                        this.ReadOnly = true;
                        this.BackColor = Color.LightGray;
                        break;
                    case TipoTextBox.NORMAL:
                        this.Enabled = true;
                        this.ReadOnly = false;
                        this.BackColor = Color.White;
                        break;
                    case TipoTextBox.READY_ONLY:
                        this.Enabled = true;
                        this.ReadOnly = true;
                        this.BackColor = Color.White;
                        break;
                    case TipoTextBox.REQUIRED:
                        this.Enabled = true;
                        this.ReadOnly = false;
                        this.BackColor = Color.LightBlue;
                        break;
                }
            }
        }
    }
}
