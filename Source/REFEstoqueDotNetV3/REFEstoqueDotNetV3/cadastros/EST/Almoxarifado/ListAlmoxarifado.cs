using System;
using System.Collections.Generic;
using System.Windows.Forms;
using REFEstoqueDotNetV3.DAO.DIC;
using REFEstoqueDotNetV3.DAO.EST;
using REFEstoqueDotNetV3.exceptions;
using REFEstoqueDotNetV3.model.DIC;
using REFEstoqueDotNetV3.model.EST;
using REFEstoqueDotNetV3.system;


namespace REFEstoqueDotNetV3.cadastros.EST.Almoxarifado
{
    public partial class ListAlmoxarifado : BaseFilterForm
    {
        private TabelaBean _tabela;


        public ListAlmoxarifado()
        {
            InitializeComponent();
            tabela = TabelaDAO.getByNome("EST_ALMOXARIFADO");
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
                AlmoxarifadoBean bean = new AlmoxarifadoBean();

                bean.idAlmoxarifado = Uteis.stringToInt(txtId.Text);

                bean.descr = txtDescr.Text;

                List<AlmoxarifadoBean> list = AlmoxarifadoDAO.getRecords(bean);

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
            DMLAlmoxarifado form = new DMLAlmoxarifado();
            form.ShowDialog(this);
        }
        protected override void alterar()
        {
            if (dgvDados.SelectedRows.Count > 0)
            {
                DMLAlmoxarifado form = new DMLAlmoxarifado();
                AlmoxarifadoBean bean = (dgvDados.DataSource as List<AlmoxarifadoBean>)[dgvDados.SelectedRows[0].Index];
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
                DMLAlmoxarifado form = new DMLAlmoxarifado();
                AlmoxarifadoBean bean = (dgvDados.DataSource as List<AlmoxarifadoBean>)[dgvDados.SelectedRows[0].Index];
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
