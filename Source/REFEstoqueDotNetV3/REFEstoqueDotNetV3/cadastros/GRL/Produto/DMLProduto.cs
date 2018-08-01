using System;
using System.Collections.Generic;
using System.Windows.Forms;
using REFEstoqueDotNetV3.DAO.GRL;
using REFEstoqueDotNetV3.model.GRL;
using REFEstoqueDotNetV3.system;


namespace REFEstoqueDotNetV3.cadastros.GRL.Produto
{
    public partial class DMLProduto : BaseDMLForm
    {
        private ProdutoBean bean;

        public DMLProduto()
        {
            InitializeComponent();
            bean = new ProdutoBean();
            tipoDML = TipoDMLForm.INSERT;
            setCombpGrupoProduto();
        }

        public void init(ProdutoBean produtoBean, TipoDMLForm tipoDMLForm)
        {
            bean = produtoBean;
            setBeanIntoTextBox();
            tipoDML = tipoDMLForm;
            if (tipoDML == TipoDMLForm.DELETE)
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
                        excluir();
                        break;
                    case TipoDMLForm.UPDATE:
                        alterar();
                        break;
                }
        }

        private void incluir()
        {
            try
            {
                validarRegistro(this);
                setTextBoxIntoBean();
                int qtdregistros = ProdutoDAO.insert(bean);

                txtIdProduto.Text = bean.idProduto.ToString();
                pnlMessage.status = MessageStatus.SUCCESS;
                pnlMessage.textMessage = "Produto inserido com sucesso.";
                pnlPrincipal.Enabled = false;
                isCommited = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                pnlMessage.status = MessageStatus.ERROR;
                pnlMessage.textMessage = "Erro ao inserir o Produto.";
            }
        }
        private void excluir()
        {
            try
            {
                int qtdregistros = ProdutoDAO.delete(bean.idProduto);
                pnlMessage.status = MessageStatus.SUCCESS;
                pnlMessage.textMessage = "Produto excluido com sucesso.";
                pnlPrincipal.Enabled = false;
                isCommited = true;
                bean = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                pnlMessage.status = MessageStatus.ERROR;
                pnlMessage.textMessage = "Erro ao excluir o Produto.";
            }
        }
        private void alterar()
        {
            try
            {
                validarRegistro(this);
                setTextBoxIntoBean();
                int qtdregistros = ProdutoDAO.update(bean);
                pnlMessage.status = MessageStatus.SUCCESS;
                pnlMessage.textMessage = "Produto alterado com sucesso.";
                pnlPrincipal.Enabled = false;
                isCommited = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                pnlMessage.status = MessageStatus.ERROR;
                pnlMessage.textMessage = "Erro ao alterar o Produto.";
            }
        }

        #region Setters
        private void setCombpGrupoProduto()
        {
            cmbGrupoProduto.DataSource = GrupoProdutoDAO.getRecords(new GrupoProdutoBean());
        }

        private void setBeanIntoTextBox()
        {
            txtIdProduto.Text = bean.idProduto.ToString();
            cmbGrupoProduto.SelectedItem = bean.grupoProduto;
            txtDescr.Text = bean.descr;
            txtUnidade.Text = bean.unidade;
            txtEstoqueMin.Text = bean.qtdEstoqueMin.ToString();
            txtEstoqueIdeal.Text = bean.qtdEstoqueMin.ToString();
            txtVlrUnitario.Text = bean.vlrUnitario.ToString();
            txtVlrMedio.Text = bean.vlrUnitarioMedio.ToString();
            txtPctLucro.Text = bean.pctLucro.ToString();
            txtCodBarras.Text = bean.codBarras;
            txtObs.Text = bean.obs;

        }

        private void setTextBoxIntoBean()
        {
            try
            {
                if (bean.idProduto == 0)
                {
                    bean.idProduto = Uteis.stringToInt(txtIdProduto.Text);
                }
                GrupoProdutoBean g = (GrupoProdutoBean)cmbGrupoProduto.SelectedItem;
                bean.grupoProduto = g;

                bean.descr = txtDescr.Text;
                bean.unidade = txtUnidade.Text;
                bean.qtdEstoqueMin = Uteis.stringToDouble(txtEstoqueMin.Text);
                bean.qtdEstoqueIdeal = Uteis.stringToDouble(txtEstoqueIdeal.Text);
                bean.vlrUnitario = Uteis.stringToDouble(txtVlrUnitario.Text);
                bean.vlrUnitarioMedio = Uteis.stringToDouble(txtVlrMedio.Text);
                bean.pctLucro = Uteis.stringToDouble(txtPctLucro.Text);
                bean.codBarras = txtCodBarras.Text;
                bean.obs = txtObs.Text;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        #endregion
    }
}
