using System;
using System.Collections.Generic;
using System.Windows.Forms;
using REFEstoqueDotNetV3.DAO.DIC;
using REFEstoqueDotNetV3.DAO.SYS;
using REFEstoqueDotNetV3.exceptions;
using REFEstoqueDotNetV3.model.DIC;
using REFEstoqueDotNetV3.model.SYS;
using REFEstoqueDotNetV3.system;



namespace REFEstoqueDotNetV3.cadastros.SYS.Usuario
{
    public partial class ListUsuario : BaseFilterForm
    {
        private TabelaBean _tabela;

        public ListUsuario()
        {
            InitializeComponent();
            tabela = TabelaDAO.getByNome("SYS_USUARIO");
            dgvDados.initGrid(tabela.colunas);
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            filtrar();
        }

        protected override void focarFiltro()
        {
            txtId.Select();
        }
        protected override void filtrar()
        {
            try
            {
                UsuarioBean usr = new UsuarioBean();

                usr.idUsuario = Uteis.stringToInt(txtId.Text);
                usr.pessoa.nome = txtNome.Text;
                usr.login = txtLogin.Text;

                List<UsuarioBean> list = UsuarioDAO.getRecords(usr);

                dgvDados.DataSource = list;

                dgvDados.Select();
            }
            catch (InvalidPropertyValueException e)
            {
                MessageBox.Show(e.Message);
                txtId.Select();
            }
        }

        protected override void novo()
        {
            if (SYSConfig.usrLogado.idUsuario == 1)
            {
                DMLUsuario form = new DMLUsuario();
                form.ShowDialog(this);
            }
            else
            {
                MessageBox.Show("Apenas o Administrador pode cadastrar usuários.");
            }
        }
        protected override void alterar()
        {
            if (dgvDados.SelectedRows.Count > 0)
            {
                UsuarioBean bean = (dgvDados.DataSource as List<UsuarioBean>)[dgvDados.SelectedRows[0].Index];
                if (SYSConfig.usrLogado.idUsuario == 1 || SYSConfig.usrLogado.idUsuario == bean.idUsuario)
                {
                    DMLUsuario form = new DMLUsuario();
                    form.init(bean, TipoDMLForm.UPDATE);
                    form.ShowDialog(this);
                }
                else
                {
                    MessageBox.Show("Apenas o Administrador pode alter outros usuários.");
                }
            }
            else
            {
                MessageBox.Show("Selecione um registro para alterá-lo.");
            }
        }
        protected override void excluir()
        {
            if (SYSConfig.usrLogado.idUsuario == 1)
            {
                if (dgvDados.SelectedRows.Count > 0)
                {
                    DMLUsuario form = new DMLUsuario();
                    UsuarioBean bean = (dgvDados.DataSource as List<UsuarioBean>)[dgvDados.SelectedRows[0].Index];
                    form.init(bean, TipoDMLForm.DELETE);
                    form.ShowDialog(this);
                    filtrar();
                }
                else
                {
                    MessageBox.Show("Selecione um registro para excluí-lo.");
                }
            }
            else
            {
                MessageBox.Show("Apenas o Administrador pode excluir usuários.");
            }
        }


        private TabelaBean tabela
        {
            get { return _tabela; }
            set { _tabela = value; }
        }
    }
}
