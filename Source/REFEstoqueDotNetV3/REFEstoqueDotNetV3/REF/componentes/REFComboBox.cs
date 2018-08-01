using System.Drawing;
using System.Windows.Forms;
using REFEstoqueDotNetV3.system;

namespace REFEstoqueDotNetV3.REF.componentes
{
    public class REFComboBox : ComboBox
    {
        private TipoComboBox _tipo = TipoComboBox.NORMAL;

        public REFComboBox()
        {
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public TipoComboBox tipo
        {
            get { return _tipo; }
            set
            {
                _tipo = value;
                switch (_tipo)
                {
                    case TipoComboBox.DISABLE:
                        this.Enabled = false;
                        this.BackColor = Color.White;
                        break;
                    case TipoComboBox.DISPLAY:
                        this.Enabled = false;
                        this.BackColor = Color.LightGray;
                        break;
                    case TipoComboBox.NORMAL:
                        this.Enabled = true;
                        this.BackColor = Color.White;
                        break;
                    case TipoComboBox.REQUIRED:
                        this.Enabled = true;
                        this.BackColor = Color.LightBlue;
                        break;
                }
            }
        }
    }
}
