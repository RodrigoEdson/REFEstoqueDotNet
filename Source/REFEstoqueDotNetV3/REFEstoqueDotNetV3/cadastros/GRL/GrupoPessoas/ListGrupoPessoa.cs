using System;
using System.Windows.Forms;
using System.Collections.Generic;
using REFEstoqueDotNetV3.model.DIC;
using REFEstoqueDotNetV3.model.GRL;
using REFEstoqueDotNetV3.DAO.DIC;
using REFEstoqueDotNetV3.exceptions;
using REFEstoqueDotNetV3.DAO.GRL;
using REFEstoqueDotNetV3.system;

namespace REFEstoqueDotNetV3.cadastros.GRL.GrupoPessoas
{
    public partial class ListGrupoPessoa : BaseFilterForm
    {
        private TabelaBean _tabela;

        public ListGrupoPessoa()
        {
            InitializeComponent();
            tabela = TabelaDAO.getByNome("GRL_GRUPO_PESSOA");
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
                GrupoPessoaBean grupoPessoa = new GrupoPessoaBean();

                grupoPessoa.idGrupoPessoa = Uteis.stringToInt(txtId.Text);

                grupoPessoa.descr = txtDescr.Text;

                List<GrupoPessoaBean> list = GrupoPessoaDAO.getRecords(grupoPessoa);

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
            DMLGrupoPessoa form = new DMLGrupoPessoa();
            form.ShowDialog(this);
        }
        protected override void alterar()
        {
            if (dgvDados.SelectedRows.Count > 0)
            {
                DMLGrupoPessoa form = new DMLGrupoPessoa();
                GrupoPessoaBean bean = (dgvDados.DataSource as List<GrupoPessoaBean>)[dgvDados.SelectedRows[0].Index];
                form.init(bean, TipoDMLForm.UPDATE);
                form.ShowDialog(this);
            }
            else
            {
                MessageBox.Show("Selecione um registro para alterá-lo.");
            }
        }
        protected override void  excluir()
        {
            if (dgvDados.SelectedRows.Count > 0)
            {
                DMLGrupoPessoa form = new DMLGrupoPessoa();
                GrupoPessoaBean bean = (dgvDados.DataSource as List<GrupoPessoaBean>)[dgvDados.SelectedRows[0].Index];
                form.init(bean, TipoDMLForm.DELETE);
                form.ShowDialog(this);
                filtrar();
            }
            else
            {
                MessageBox.Show("Selecione um registro para excluí-lo.");
            }
        }

        private TabelaBean tabela
        {
            get { return _tabela; }
            set { _tabela = value; }
        }
    }
}
