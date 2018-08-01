using System.Windows.Forms;
using System.Collections.Generic;
using REFEstoqueDotNetV3.DAO.DIC;
using REFEstoqueDotNetV3.DAO.EST;
using REFEstoqueDotNetV3.exceptions;
using REFEstoqueDotNetV3.model.DIC;
using REFEstoqueDotNetV3.model.GRL;
using REFEstoqueDotNetV3.model.EST;
using REFEstoqueDotNetV3.REF.forms;

namespace REFEstoqueDotNetV3.cadastros.EST.SaldoProduto
{
    public partial class ViewSaldoProduto : BaseForm
    {
        private TabelaBean _tabela;

        private ProdutoBean _produto;

        public ViewSaldoProduto()
        {
            InitializeComponent();
            tabela = TabelaDAO.getByNome("EST_SALDO_PRODUTO");
            dgvDados.initGrid(tabela.colunas);
        }


        private TabelaBean tabela
        {
            get { return _tabela; }
            set { _tabela = value; }
        }

        public ProdutoBean produto
        {
            get { return _produto; }
            set { _produto = value; }
        }

        private void btnVoltar_Click(object sender, System.EventArgs e)
        {
            this.closeForm();
        }

        private void ViewSaldoProduto_Load(object sender, System.EventArgs e)
        {
            try
            {
                dgvDados.DataSource = produto.saldos;
                double vlr = produto.saldoTotal;

                if (vlr <= produto.qtdEstoqueMin)
                {
                    pnlTotal.status = system.MessageStatus.ALERT;
                    pnlTotal.textMessage = "(SALDO MÍNIMO ATINGIDO) ";
                }
                else
                {
                    pnlTotal.status = system.MessageStatus.NORMAL;
                    pnlTotal.textMessage = "";
                }

                pnlTotal.textMessage += "SALDO TOTAL = " + string.Format("{0:0.00}", vlr);

                dgvDados.Select();
            }
            catch (InvalidPropertyValueException ex)
            {
                MessageBox.Show(ex.Message);
                this.closeForm();
            }
        }
    }
}
