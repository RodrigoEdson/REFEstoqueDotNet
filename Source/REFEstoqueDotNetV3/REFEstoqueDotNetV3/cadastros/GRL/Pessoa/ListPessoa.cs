using System;
using System.Collections.Generic;
using System.Windows.Forms;
using REFEstoqueDotNetV3.DAO.DIC;
using REFEstoqueDotNetV3.DAO.GRL;
using REFEstoqueDotNetV3.exceptions;
using REFEstoqueDotNetV3.model.DIC;
using REFEstoqueDotNetV3.model.GRL;
using REFEstoqueDotNetV3.system;

namespace REFEstoqueDotNetV3.cadastros.GRL.Pessoa
{
    public partial class ListPessoa : BaseFilterForm
    {
        private TabelaBean _tabela;

        public ListPessoa()
        {
            InitializeComponent();
            tabela = TabelaDAO.getByNome("GRL_PESSOA");
            dgvDados.initGrid(tabela.colunas);
        }

        private TabelaBean tabela
        {
            get { return _tabela; }
            set { _tabela = value; }
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
                PessoaBean pessoa = new PessoaBean();

                pessoa.idPessoa = Uteis.stringToInt(txtId.Text);
                pessoa.nome = txtNome.Text;
                pessoa.apelido = txtApelido.Text;
                pessoa.logradouro = txtLogradouro.Text;
                pessoa.numDoc = txtDocumento.Text;
                GrupoPessoaBean grupo = new GrupoPessoaBean();
                grupo.descr = txtGrupo.Text;
                pessoa.grupoPessoa = grupo;


                List<PessoaBean> list = PessoaDAO.getRecords(pessoa);

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
            DMLPessoa form = new DMLPessoa();
            form.ShowDialog(this);
        }
        protected override void alterar()
        {
            if (dgvDados.SelectedRows.Count > 0)
            {
                DMLPessoa form = new DMLPessoa();
                PessoaBean bean = (dgvDados.DataSource as List<PessoaBean>)[dgvDados.SelectedRows[0].Index];
                form.init(bean, TipoDMLForm.UPDATE);
                form.ShowDialog(this);
            }
            else
            {
                MessageBox.Show("Selecione um registro para alterá-lo.");
            }
        }
        protected override void excluir()
        {
            if (dgvDados.SelectedRows.Count > 0)
            {
                DMLPessoa form = new DMLPessoa();
                PessoaBean bean = (dgvDados.DataSource as List<PessoaBean>)[dgvDados.SelectedRows[0].Index];
                form.init(bean, TipoDMLForm.DELETE);
                form.ShowDialog(this);
                filtrar();
            }
            else
            {
                MessageBox.Show("Selecione um registro para excluí-lo.");
            }
        }
    }
}
