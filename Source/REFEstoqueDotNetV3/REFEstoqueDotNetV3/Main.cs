using System.Windows.Forms;
using REFEstoqueDotNetV3.cadastros.EST.Almoxarifado;
using REFEstoqueDotNetV3.cadastros.EST.Venda;
using REFEstoqueDotNetV3.cadastros.GRL.GrupoPessoas;
using REFEstoqueDotNetV3.cadastros.GRL.GrupoProduto;
using REFEstoqueDotNetV3.cadastros.GRL.Pessoa;
using REFEstoqueDotNetV3.cadastros.GRL.Produto;
using REFEstoqueDotNetV3.cadastros.SYS.Usuario;
using REFEstoqueDotNetV3.login;
using REFEstoqueDotNetV3.model.SYS;
using REFEstoqueDotNetV3.REF.forms;
using REFEstoqueDotNetV3.system;

namespace REFEstoqueDotNetV3
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        #region comportamento
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SYSConfig.usrLogado != null)
            {
                DialogResult result = MessageBox.Show("Deseja sair do sistema?",
                       "Confirma Saída?",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question,
                       MessageBoxDefaultButton.Button2,
                       MessageBoxOptions.DefaultDesktopOnly,
                       false);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void showForm(BaseForm frm)
        {
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }
        #endregion

        #region menus
        private void cadastroDeGruposDePessoasToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            //showForm(new CadGrupoPessoa());
            showForm(new ListGrupoPessoa());
        }
        #endregion

        private void cadastrosDePessoasToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            showForm(new ListPessoa());
        }

        private void cadastroDeUsuariosToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            showForm(new ListUsuario());
        }

        private void grupoDeProdutosToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            showForm(new ListGrupoProduto());
        }

        private void protutosToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            showForm(new ListProduto());
        }

        private void almoxarifadoToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            showForm(new ListAlmoxarifado());
        }

        private void registrarVendaToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            showForm(new SelectCliente());
        }


        private void Main_Shown(object sender, System.EventArgs e)
        {
            /*FrmLogin login = new FrmLogin();
            login.ShowDialog();

            UsuarioBean usr = login.usrLogado;

            if (usr == null)
            {
                Application.Exit();
            }
            else
            {
                lblUsrLogado.Text = "Usuário: "+ usr.ToString();
                SYSConfig.initSys(usr,lblMessage);
            }*/
        }

    }
}
