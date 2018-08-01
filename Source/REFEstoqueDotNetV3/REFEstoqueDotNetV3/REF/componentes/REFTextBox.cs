using System.Drawing;
using System.Windows.Forms;
using REFEstoqueDotNetV3.system;

namespace REFEstoqueDotNetV3.REF.componentes
{
    public class REFTextBox : TextBox
    {
        private bool _isPK;

        private bool _isDataBaseItem;

        private bool _isFilterItem;

        private TipoTextBox _tipo;

        private string _beanItemName;

        private string _oldText;

        public REFTextBox()
        {
            if (this.PasswordChar.ToString() == "")
            {
                base.CharacterCasing = CharacterCasing.Upper;
            }
            else
            {
                base.CharacterCasing = CharacterCasing.Normal;
            }
        }

        public void setText(string txt)
        {
            this.Text = txt;
            this.oldText = txt;
        }

        public bool isAltered
        {
            get
            {
                return this.Text == this.oldText ? false : true;
            }
        }

        public bool isPK
        {
            get { return _isPK; }
            set
            {
                _isPK = value;
                if (_isPK)
                {
                    this.MaxLength = 10;
                    this.tipo = TipoTextBox.DISPLAY;
                    this.isDataBaseItem = true;
                    this.isFilterItem = true;
                }
                else
                {
                    this.MaxLength = 100;
                    this.tipo = TipoTextBox.NORMAL;
                }
            }
        }

        public bool isDataBaseItem
        {
            get { return _isDataBaseItem; }
            set
            {
                if (isPK)
                    _isDataBaseItem = true;
                else
                    _isDataBaseItem = value;
            }
        }

        public bool isFilterItem
        {
            get { return _isFilterItem; }
            set
            {
                if (isPK)
                    _isFilterItem = true;
                else
                    _isFilterItem = value;
            }
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

        public string beanItemName
        {
            get { return _beanItemName; }
            set { _beanItemName = value; }
        }

        public string oldText
        {
            get { return _oldText; }
            set { _oldText = value; }
        }
    }
}
