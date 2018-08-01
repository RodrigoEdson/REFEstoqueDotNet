using System;
using System.Windows.Forms;
using System.Collections.Generic;
using REFEstoqueDotNetV3.model.DIC;
using REFEstoqueDotNetV3.model.GRL;
using REFEstoqueDotNetV3.DAO.DIC;
using REFEstoqueDotNetV3.exceptions;
using REFEstoqueDotNetV3.DAO.GRL;
using REFEstoqueDotNetV3.system;
using REFEstoqueDotNetV3.cadastros.EST.SaldoProduto;

namespace REFEstoqueDotNetV3.cadastros.GRL.Produto
{
    public partial class ListProduto : BaseFilterForm
    {
        private TabelaBean _tabela;
        private ViewSaldoProduto frmSaldo;

        private Button btnListSaldo;

        public ListProduto()
        {
            InitializeComponent();
            initBotoes();
            base.addBotaoPainel(btnListSaldo);
            tabela = TabelaDAO.getByNome("GRL_PRODUTO");
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
                ProdutoBean prod = new ProdutoBean();

                prod.idProduto = Uteis.stringToInt(txtId.Text);
                prod.descr= txtDescr.Text;
                prod.codBarras = txtCodBarras.Text;
                GrupoProdutoBean grupo = new GrupoProdutoBean();
                grupo.descr = txtGrupo.Text;
                prod.grupoProduto= grupo;


                List<ProdutoBean> list = ProdutoDAO.getRecords(prod);

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
            DMLProduto form = new DMLProduto();
            form.ShowDialog(this);
        }
        protected override void alterar()
        {
            if (dgvDados.SelectedRows.Count > 0)
            {
                DMLProduto form = new DMLProduto();
                ProdutoBean bean = (dgvDados.DataSource as List<ProdutoBean>)[dgvDados.SelectedRows[0].Index];
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
                DMLProduto form = new DMLProduto();
                ProdutoBean bean = (dgvDados.DataSource as List<ProdutoBean>)[dgvDados.SelectedRows[0].Index];
                form.init(bean, TipoDMLForm.DELETE);
                form.ShowDialog(this);
                filtrar();
            }
            else
            {
                MessageBox.Show("Selecione um registro para excluí-lo.");
            }
        }

        private void initBotoes()
        {
            btnListSaldo = new Button();
            btnListSaldo.Text = "Saldo do Produto";
            btnListSaldo.Name = "btnListSaldo";
            btnListSaldo.Click += new System.EventHandler(this.btnListSaldo_Click);
        }

        private void btnListSaldo_Click(object sender, System.EventArgs e)
        {
            if (dgvDados.SelectedRows.Count > 0)
            {
                if (frmSaldo == null)
                    frmSaldo = new ViewSaldoProduto();
                frmSaldo.produto = (dgvDados.DataSource as List<ProdutoBean>)[dgvDados.SelectedRows[0].Index];
                frmSaldo.ShowDialog();
                dgvDados.Select();
            }
            else
            {
                MessageBox.Show("Selecione um registro para consultar o saldo.");
            }
            
        }

        private TabelaBean tabela
        {
            get { return _tabela; }
            set { _tabela = value; }
        }
        
    }
}
