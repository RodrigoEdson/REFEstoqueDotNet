using System.Drawing;
using System.Windows.Forms;
using REFEstoqueDotNetV3.system;

namespace REFEstoqueDotNetV3.REF.componentes
{
    public class REFLabelStatusRecord : Label
    {
        private DataStatus _status;
        

        public REFLabelStatusRecord()
            : base()
        {
            this.status = DataStatus.EXIBICAO;
        }

        public DataStatus status
        {
            get { return _status; }
            set
            {
                _status = value;
                switch (_status)
                {
                    case DataStatus.ALTERADO:
                        this.BackColor = Color.Yellow;
                        this.Text = "Registro Alterado";
                        break;
                    case DataStatus.EXCLUIDO:
                        this.BackColor = Color.LightCoral;
                        this.Text = "Registro Excluido";
                        break;
                    case DataStatus.EXIBICAO:
                        this.BackColor = Color.LawnGreen;
                        this.Text = "Registro não Alterado";
                        break;
                    case DataStatus.NOVO:
                        this.BackColor = Color.LightBlue;
                        this.Text = "Registro Novo";
                        break;
                }
            }
        }
    }
}
