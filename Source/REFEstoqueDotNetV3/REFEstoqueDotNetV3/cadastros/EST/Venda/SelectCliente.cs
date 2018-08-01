using System.Collections.Generic;
using System.Windows.Forms;
using REFEstoqueDotNetV3.DAO.DIC;
using REFEstoqueDotNetV3.DAO.GRL;
using REFEstoqueDotNetV3.exceptions;
using REFEstoqueDotNetV3.model.DIC;
using REFEstoqueDotNetV3.model.EST;
using REFEstoqueDotNetV3.model.GRL;
using REFEstoqueDotNetV3.REF.forms;
using REFEstoqueDotNetV3.system;

namespace REFEstoqueDotNetV3.cadastros.EST.Venda
{
    public partial class SelectCliente : BaseForm
    {
        private TabelaBean _tabela;

        public SelectCliente()
        {
            InitializeComponent();

            tabela = TabelaDAO.getByNome("GRL_PESSOA");
            dgvDados.initGrid(tabela.colunas);

            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDownForm);

            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        }

        #region Controle_TECLAS
        private new void keyDownForm(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    listarVendas();
                    break;
                case Keys.F8:
                    filtrar();
                    break;
                case Keys.F7:
                    focarFiltro();
                    break;
                case Keys.F6:
                    if (btnNovaVenda.Enabled)
                        this.novaVenda();
                    break;
            }
        }
        private void focarFiltro()
        {
            txtId.Select();
        }
        private void filtrar()
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
        #endregion

        #region Botoes
        private void novaVenda()
        {
            if (dgvDados.SelectedRows.Count > 0)
            {
                DMLVenda frm = new DMLVenda();
                VendaBean v = new VendaBean();
                v.cliente = (dgvDados.DataSource as List<PessoaBean>)[dgvDados.SelectedRows[0].Index];
                frm.init(v, TipoDMLForm.INSERT);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selecione um cliente para registrar a venda.");
            }
            dgvDados.Select();
        }
        private void listarVendas()
        {
            if (dgvDados.SelectedRows.Count > 0)
            {
                ListVendasCliente form = new ListVendasCliente();
                form.init((dgvDados.DataSource as List<PessoaBean>)[dgvDados.SelectedRows[0].Index]);
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selecione um cliente para listar as vendas.");
            }
            dgvDados.Select();
        }
        #endregion

        private TabelaBean tabela
        {
            get { return _tabela; }
            set { _tabela = value; }
        }

        private void btnNovo_Click(object sender, System.EventArgs e)
        {
            this.novaVenda();
        }

        private void btnListarVendas_Click(object sender, System.EventArgs e)
        {
            this.listarVendas();
        }

        private void btnFechar_Click(object sender, System.EventArgs e)
        {
            this.closeForm();
        }

        private void btnNovaVenda_Click(object sender, System.EventArgs e)
        {
            novaVenda();
        }

    }
}
