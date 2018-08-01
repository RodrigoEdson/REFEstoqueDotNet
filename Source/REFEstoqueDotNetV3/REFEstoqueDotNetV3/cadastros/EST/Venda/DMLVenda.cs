using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using REFEstoqueDotNetV3.DAO.DIC;
using REFEstoqueDotNetV3.DAO.EST;
using REFEstoqueDotNetV3.DAO.GRL;
using REFEstoqueDotNetV3.exceptions;
using REFEstoqueDotNetV3.model.DIC;
using REFEstoqueDotNetV3.model.EST;
using REFEstoqueDotNetV3.model.GRL;
using REFEstoqueDotNetV3.system;

namespace REFEstoqueDotNetV3.cadastros.EST.Venda
{
    public partial class DMLVenda : BaseDMLForm
    {
        private VendaBean bean;
        private TabelaBean _tabela;

        public DMLVenda()
        {
            InitializeComponent();

            bean = new VendaBean();
            tipoDML = TipoDMLForm.INSERT;

            tabela = TabelaDAO.getByNome("EST_ITEM_VENDA");
            dgvItens.initGrid(tabela.colunas);
        }

        private int CompareItensByProduto(ItemVendaBean x, ItemVendaBean y)
        {
            return x.produto.ToString().CompareTo(y.produto.ToString());
        }
        public void init(VendaBean paramBean, TipoDMLForm tipoDMLForm)
        {
            bean = paramBean;
            setBeanIntoTextBox();
            bean.itens.Sort(CompareItensByProduto);
            dgvItens.DataSource = bean.itens;
            tipoDML = tipoDMLForm;
            setBtnConfirmarText("Cancelar");
            if (tipoDML == TipoDMLForm.DELETE || tipoDML == TipoDMLForm.VIEW)
            {
                pnlPrincipal.Enabled = false;
            }
        }

        protected override void confirmar()
        {
            if (isCommited)
            {
                MessageBox.Show("Ação já confirmada. Pressione ESC para voltar!");
            }
            else
                switch (tipoDML)
                {
                    case TipoDMLForm.INSERT:
                        incluir();
                        break;
                    case TipoDMLForm.DELETE:
                        cancelar();
                        break;
                    //case TipoDMLForm.UPDATE:
                    //    alterar();
                    //    break;
                    case TipoDMLForm.VIEW:
                        closeForm();
                        break;
                }
        }

        private void incluir()
        {
            try
            {
                validarRegistro(this);
                setTextBoxIntoBean();
                int qtdregistros = VendaDAO.insert(bean);
                txtIdVenda.Text = bean.idVenda.ToString();
                pnlMessage.status = MessageStatus.SUCCESS;
                pnlMessage.textMessage = "Venda registrada com sucesso.";
                pnlPrincipal.Enabled = false;
                isCommited = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                pnlMessage.status = MessageStatus.ERROR;
                pnlMessage.textMessage = "Erro ao registrar a Venda.";
            }
        }

        private void cancelar()
        {
            try
            {
                /*int qtdregistros = AlmoxarifadoDAO.delete(bean.idAlmoxarifado);
                pnlMessage.status = MessageStatus.SUCCESS;
                pnlMessage.textMessage = "Venda excluida com sucesso.";
                pnlPrincipal.Enabled = false;
                isCommited = true;
                bean = null;*/
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                pnlMessage.status = MessageStatus.ERROR;
                pnlMessage.textMessage = "Erro ao cancelar a Venda.";
            }
        }

        private void alterar()
        {
            try
            {
                validarRegistro(this);
                setTextBoxIntoBean();
                //int qtdregistros = VendaDAO.update(bean);
                pnlMessage.status = MessageStatus.SUCCESS;
                pnlMessage.textMessage = "Venda alterada com sucesso.";
                pnlPrincipal.Enabled = false;
                isCommited = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                pnlMessage.status = MessageStatus.ERROR;
                pnlMessage.textMessage = "Erro ao alterar a Venda.";
            }
        }

        #region Setters
        private void setBeanIntoTextBox()
        {
            //cliente
            txtIdCliente.Text = bean.cliente.idPessoa.ToString();
            txtGrupoCliente.Text = bean.cliente.grupoPessoa.ToString();
            txtStatus.Text = bean.status.ToString();
            txtNomeCliente.Text = bean.cliente.nome;
            txtApelidoCliente.Text = bean.cliente.apelido;
            txtTel1.Text = bean.cliente.tel1;
            txtTel2.Text = bean.cliente.tel2;
            txtTel3.Text = bean.cliente.tel3;
            txtLogradouro.Text = bean.cliente.logradouro;
            txtNum.Text = bean.cliente.numero;
            //venda
            txtIdVenda.Text = bean.idVenda.ToString();
            txtObs.Text = bean.obs;
            dtpDtVenda.Value = bean.dtVenda;
            dtpDtEmissao.Value = bean.dtEmissao;
            dtpDtUltAlteracao.Value = bean.dtUltAlteracao;
            if (bean.dtVencParcela1.HasValue)
                dtpVencParcela1.Value = bean.dtVencParcela1.Value;
            txtNotaVenda.Text = bean.notaVenda;
            cmbTipoVenda.Text = bean.tipoVenda;
            txtQtdParcelas.Text = bean.qtdParcelas.ToString();
            txtVlrDesconnto.Text = bean.vlrDesconto.ToString();
            txtVlrProduto.Text = bean.vlrProdutos.ToString();
            txtVlrTotal.Text = bean.vlrTotal.ToString();
            //itens
        }

        private void setTextBoxIntoBean()
        {
            try
            {
                if (bean.idVenda == 0)
                {
                    bean.idVenda = Uteis.stringToInt(txtIdVenda.Text);
                }
                bean.dtVenda = dtpDtVenda.Value;
                bean.status = txtStatus.Text;
                bean.dtEmissao = dtpDtEmissao.Value;
                bean.dtUltAlteracao = dtpDtUltAlteracao.Value;
                bean.dtVencParcela1 = dtpVencParcela1.Value;
                bean.notaVenda = txtNotaVenda.Text;
                bean.vlrDesconto = Uteis.stringToDouble(txtVlrDesconnto.Text);
                bean.tipoVenda = cmbTipoVenda.Text;
                bean.qtdParcelas = Uteis.stringToInt(txtQtdParcelas.Text);
                bean.obs = txtObs.Text;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        #endregion
        private TabelaBean tabela
        {
            get { return _tabela; }
            set { _tabela = value; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            inserirProduto();
        }

        private void trocaDataSource(List<ItemVendaBean> list)
        {
            List<ItemVendaBean> data = new List<ItemVendaBean>();

            data.AddRange(list);

            dgvItens.DataSource = data;

            atualizaVenda();
        }

        private void atualizaVenda()
        {
            setTextBoxIntoBean();
            txtVlrProduto.Text = bean.vlrProdutos.ToString();
            txtVlrTotal.Text = bean.vlrTotal.ToString();
        }

        private void txtVlrDesconnto_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            atualizaVenda();
        }

        private void txtCodBarras_KeyDown(object sender, KeyEventArgs e)
        {
            tratarEnterProduto(e);
        }

        private void txtIdProduto_KeyDown(object sender, KeyEventArgs e)
        {
            tratarEnterProduto(e);
        }

        private void tratarEnterProduto(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                inserirProduto();
                txtCodBarras.Text = "";
                txtIdProduto.Text = "";
            }
        }
        private void inserirProduto()
        {
            try
            {

                if (txtQtdProd.Text == "" || Uteis.stringToDouble(txtQtdProd.Text) <= 0)
                {
                    throw new ValueRequiredException("Informe um valor numérico válido para a quantidade do produto.");
                }

                ProdutoBean pro = null;

                if (txtCodBarras.Text != "")
                {
                    pro = ProdutoDAO.getRecord(txtCodBarras.Text);
                }
                else if (Uteis.stringToInt(txtIdProduto.Text) > 0)
                {
                    pro = ProdutoDAO.getRecord(Uteis.stringToInt(txtIdProduto.Text));
                }
                else
                {
                    throw new ValueRequiredException("Para adicionar um produto, informe seu ID ou seu Código de Barras!");
                }

                if (pro.idProduto <= 0)
                {
                    MessageBox.Show("Produto não encontrado. Confirme o ID ou o Código de Barras.");
                }
                else
                {
                    dgvItens.Refresh();
                    ItemVendaBean item = new ItemVendaBean();
                    item.venda = bean;
                    item.produto = pro;
                    item.qtdProduto = Uteis.stringToDouble(txtQtdProd.Text);
                    if (bean.itens.Contains(item))
                    {
                        bean.itens[bean.itens.IndexOf(item)].qtdProduto += Uteis.stringToDouble(txtQtdProd.Text);
                        //bean.itens[bean.itens.IndexOf(item)].produto = pro;
                    }
                    else
                    {
                        bean.itens.Add(item);
                    }
                    trocaDataSource(bean.itens);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvItens_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DialogResult result = MessageBox.Show("Exclusão de Item",
                      "Confirma a exclusão do Item ?",
                      MessageBoxButtons.YesNo,
                      MessageBoxIcon.Question,
                      MessageBoxDefaultButton.Button2,
                      MessageBoxOptions.ServiceNotification,
                      false);
                if (result == DialogResult.Yes)
                {
                    //bean.itens.RemoveAt(dgvItens.SelectedRows[0].Index);
                    bean.itens[dgvItens.SelectedRows[0].Index].qtdProduto = 0;
                    trocaDataSource(bean.itens);
                }
            }
        }

        private void dgvItens_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //mudar cor dos itens zerados "Excluidos"
            if (bean.itens[e.RowIndex].qtdProduto == 0)
            {
                e.CellStyle.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Strikeout);
                e.CellStyle.BackColor = Color.LightGray;
            }
        }

    }
}
