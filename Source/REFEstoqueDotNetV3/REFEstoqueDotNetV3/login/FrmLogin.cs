using System.Windows.Forms;
using REFEstoqueDotNetV3.model.SYS;
using REFEstoqueDotNetV3.DAO.SYS;
using REFEstoqueDotNetV3.REF.forms;
using REFEstoqueDotNetV3.system;
using REFEstoqueDotNetV3.system.security;

namespace REFEstoqueDotNetV3.login
{
    public partial class FrmLogin : BaseForm
    {
        private int tentativas = 0;
        private UsuarioBean usr;
        public FrmLogin()
        {
            InitializeComponent();

            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        }

        public UsuarioBean usrLogado
        {
            get { return usr; }
        }

        private void btnCancelar_Click(object sender, System.EventArgs e)
        {
            closeForm();
        }

        private void btnConfirmar_Click(object sender, System.EventArgs e)
        {
            tentativas++;
            if (tentativas >= 3)
            {
                closeForm();
            }
            else
            {
                UsuarioBean u = UsuarioDAO.getByLogin(txtLogin.Text, REFHash.getMD5Hash(txtSenha.Text));

                if (u != null && u.idUsuario != 0)
                {
                    usr = u;
                    closeForm();
                }
                else
                {
                    MessageBox.Show("Login ou Senha inválidos! (" + (3 - tentativas) + " tentativas restantes).");
                }
            }
        }
    }
}
