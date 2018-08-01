using System;
using System.Windows.Forms;
using System.Collections.Generic;
using REFEstoqueDotNetV3.model.DIC;
using REFEstoqueDotNetV3.model.GRL;
using REFEstoqueDotNetV3.DAO.DIC;
using REFEstoqueDotNetV3.exceptions;
using REFEstoqueDotNetV3.DAO.GRL;
using REFEstoqueDotNetV3.system;

namespace REFEstoqueDotNetV3.cadastros.GRL.GrupoProduto
{
    public partial class ListGrupoProduto : BaseFilterForm
    {
        private TabelaBean _tabela;
        public ListGrupoProduto()
        {
            InitializeComponent();
            tabela = TabelaDAO.getByNome("GRL_GRUPO_PRODUTO");
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
                GrupoProdutoBean grupo = new GrupoProdutoBean();

                grupo.idGrupoProduto = Uteis.stringToInt(txtId.Text);

                grupo.descr = txtDescr.Text;

                List<GrupoProdutoBean> list = GrupoProdutoDAO.getRecords(grupo);

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
            DMLGrupoProduto form = new DMLGrupoProduto();
            form.ShowDialog(this);
        }
        protected override void alterar()
        {
            if (dgvDados.SelectedRows.Count > 0)
            {
                DMLGrupoProduto form = new DMLGrupoProduto();
                GrupoProdutoBean bean = (dgvDados.DataSource as List<GrupoProdutoBean>)[dgvDados.SelectedRows[0].Index];
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
                DMLGrupoProduto form = new DMLGrupoProduto();
                GrupoProdutoBean bean = (dgvDados.DataSource as List<GrupoProdutoBean>)[dgvDados.SelectedRows[0].Index];
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
