using System.Collections.Generic;
using System.Windows.Forms;
using REFEstoqueDotNetV3.DAO.DIC;
using REFEstoqueDotNetV3.DAO.EST;
using REFEstoqueDotNetV3.exceptions;
using REFEstoqueDotNetV3.model.DIC;
using REFEstoqueDotNetV3.model.EST;
using REFEstoqueDotNetV3.model.GRL;
using REFEstoqueDotNetV3.REF.forms;
using REFEstoqueDotNetV3.system;

namespace REFEstoqueDotNetV3.cadastros.EST.Venda
{
    public partial class ListVendasCliente : BaseForm
    {
        private TabelaBean _tabela;
        private PessoaBean _cliente;

        public ListVendasCliente()
        {
            InitializeComponent();
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDownForm);

            tabela = TabelaDAO.getByNome("EST_VENDA");
            dgvDados.initGrid(tabela.colunas);

            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        }

        public void init(PessoaBean cli)
        {
            cliente = cli;
            txtTitulo.Text = "Lista das vendas registradas para " + cliente;

            try
            {
                List<VendaBean> list = VendaDAO.getRecordsByCliente(cliente);
                dgvDados.DataSource = list;
                dgvDados.Select();
            }
            catch (InvalidPropertyValueException e)
            {
                MessageBox.Show(e.Message);
                btnFechar.Select();
            }
        }

        private void btnFechar_Click(object sender, System.EventArgs e)
        {
            this.closeForm();
        }


        private void btnVizVendas_Click(object sender, System.EventArgs e)
        {
            vizualizarVenda();
        }

        private void btnAlterar_Click(object sender, System.EventArgs e)
        {
            alterarVenda();
        }

        private void vizualizarVenda()
        {
            if (dgvDados.SelectedRows.Count > 0)
            {
                DMLVenda frm = new DMLVenda();
                frm.init((dgvDados.DataSource as List<VendaBean>)[dgvDados.SelectedRows[0].Index], TipoDMLForm.VIEW);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selecione a venda para exibí-la.");
            }
            dgvDados.Select();
        }

        private void alterarVenda()
        {
            if (dgvDados.SelectedRows.Count > 0)
            {
                DMLVenda frm = new DMLVenda();
                frm.init((dgvDados.DataSource as List<VendaBean>)[dgvDados.SelectedRows[0].Index], TipoDMLForm.UPDATE);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selecione a venda para alterá-la.");
            }
            dgvDados.Select();
        }

        #region Controle_TECLAS
        private new void keyDownForm(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    vizualizarVenda();
                    break;
                case Keys.F3:
                    if (btnCancelar.Enabled)
                        this.cancelar();
                    break;
            }
        }
        private void cancelar()
        {
            if (dgvDados.SelectedRows.Count > 0)
            {
                DMLVenda form = new DMLVenda();
                VendaBean bean = (dgvDados.DataSource as List<VendaBean>)[dgvDados.SelectedRows[0].Index];
                form.init(bean, TipoDMLForm.DELETE);
                form.ShowDialog(this);
            }
            else
            {
                MessageBox.Show("Selecione um registro para alterá-lo.");
            }
            dgvDados.Select();
        }
        #endregion

        private TabelaBean tabela
        {
            get { return _tabela; }
            set { _tabela = value; }
        }

        private PessoaBean cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }




    }
}
