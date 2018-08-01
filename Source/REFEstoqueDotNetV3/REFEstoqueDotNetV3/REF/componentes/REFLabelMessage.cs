using System.Drawing;
using System.Windows.Forms;
using REFEstoqueDotNetV3.system;

namespace REFEstoqueDotNetV3.REF.componentes
{
    class REFLabelMessage : Label
    {
        private MessageStatus _status;

        public REFLabelMessage()
        {
            status = MessageStatus.NORMAL;
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
                        this.BackColor = Color.Green;
                        this.ForeColor = Color.White;
                        break;
                    case MessageStatus.ERROR:
                        this.BackColor = Color.OrangeRed;
                        this.ForeColor = Color.Black;
                        break;
                    case MessageStatus.ALERT:
                        this.BackColor = Color.Yellow;
                        this.ForeColor = Color.Black;
                        break;
                    case MessageStatus.NORMAL:
                        this.BackColor = SystemColors.Control;
                        this.ForeColor = Color.Black;
                        break;
                }
            }
        }
    }
}
