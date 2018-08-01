using System;
using System.Windows.Forms;
using REFEstoqueDotNetV3.DAO.GRL;
using REFEstoqueDotNetV3.model.GRL;
using REFEstoqueDotNetV3.system;


namespace REFEstoqueDotNetV3.cadastros.GRL.GrupoProduto
{
    public partial class DMLGrupoProduto : BaseDMLForm
    {
        private GrupoProdutoBean bean;

        public DMLGrupoProduto()
        {
            InitializeComponent();
            bean = new GrupoProdutoBean();
            tipoDML = TipoDMLForm.INSERT;
        }

        public void init(GrupoProdutoBean grupoPessoaBean, TipoDMLForm tipoDMLForm)
        {
            bean = grupoPessoaBean;
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
                int qtdregistros = GrupoProdutoDAO.insert(bean);

                txtIdGrupoProduto.Text = bean.idGrupoProduto.ToString();
                pnlMessage.status = MessageStatus.SUCCESS;
                pnlMessage.textMessage = "Grupo de Produto inserido com sucesso.";
                pnlPrincipal.Enabled = false;
                isCommited = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                pnlMessage.status = MessageStatus.ERROR;
                pnlMessage.textMessage = "Erro ao inserir o Grupo de Produto.";
            }
        }

        private void excluir()
        {
            try
            {
                int qtdregistros = GrupoProdutoDAO.delete(bean.idGrupoProduto);
                pnlMessage.status = MessageStatus.SUCCESS;
                pnlMessage.textMessage = "Grupo de Produto excluido com sucesso.";
                pnlPrincipal.Enabled = false;
                isCommited = true;
                bean = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                pnlMessage.status = MessageStatus.ERROR;
                pnlMessage.textMessage = "Erro ao excluir o Grupo de Produto.";
            }
        }

        private void alterar()
        {
            try
            {
                validarRegistro(this);
                setTextBoxIntoBean();
                int qtdregistros = GrupoProdutoDAO.update(bean);
                pnlMessage.status = MessageStatus.SUCCESS;
                pnlMessage.textMessage = "Grupo de Produto alterado com sucesso.";
                pnlPrincipal.Enabled = false;
                isCommited = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                pnlMessage.status = MessageStatus.ERROR;
                pnlMessage.textMessage = "Erro ao alterar o Grupo de Produto.";
            }
        }

        #region Setters
        private void setBeanIntoTextBox()
        {
            txtIdGrupoProduto.Text = bean.idGrupoProduto.ToString();
            txtDescr.Text = bean.descr;
        }

        private void setTextBoxIntoBean()
        {
            try
            {
                if (bean.idGrupoProduto == 0)
                {
                    bean.idGrupoProduto = Uteis.stringToInt(txtIdGrupoProduto.Text);
                }
                bean.descr = txtDescr.Text;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        #endregion
    }
}
