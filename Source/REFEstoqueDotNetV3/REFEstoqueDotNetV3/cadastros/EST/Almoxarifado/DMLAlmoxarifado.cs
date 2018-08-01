using System;
using System.Windows.Forms;
using REFEstoqueDotNetV3.DAO.EST;
using REFEstoqueDotNetV3.model.EST;
using REFEstoqueDotNetV3.system;

namespace REFEstoqueDotNetV3.cadastros.EST.Almoxarifado
{
    public partial class DMLAlmoxarifado : BaseDMLForm
    {
        private AlmoxarifadoBean bean;
        public DMLAlmoxarifado()
        {
            InitializeComponent();
            bean = new AlmoxarifadoBean();
            tipoDML = TipoDMLForm.INSERT;
        }

        public void init(AlmoxarifadoBean paramBean, TipoDMLForm tipoDMLForm)
        {
            bean = paramBean;
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
                int qtdregistros = AlmoxarifadoDAO.insert(bean);
                txtId.Text = bean.idAlmoxarifado.ToString();
                pnlMessage.status = MessageStatus.SUCCESS;
                pnlMessage.textMessage = "Almoxarifado inserido com sucesso.";
                pnlPrincipal.Enabled = false;
                isCommited = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                pnlMessage.status = MessageStatus.ERROR;
                pnlMessage.textMessage = "Erro ao inserir o Almoxarifado.";
            }
        }

        private void excluir()
        {
            try
            {
                int qtdregistros = AlmoxarifadoDAO.delete(bean.idAlmoxarifado);
                pnlMessage.status = MessageStatus.SUCCESS;
                pnlMessage.textMessage = "Almoxarifado excluido com sucesso.";
                pnlPrincipal.Enabled = false;
                isCommited = true;
                bean = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                pnlMessage.status = MessageStatus.ERROR;
                pnlMessage.textMessage = "Erro ao excluir o Almoxarifado.";
            }
        }

        private void alterar()
        {
            try
            {
                validarRegistro(this);
                setTextBoxIntoBean();
                int qtdregistros = AlmoxarifadoDAO.update(bean);
                pnlMessage.status = MessageStatus.SUCCESS;
                pnlMessage.textMessage = "Almoxarifado alterado com sucesso.";
                pnlPrincipal.Enabled = false;
                isCommited = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                pnlMessage.status = MessageStatus.ERROR;
                pnlMessage.textMessage = "Erro ao alterar o Almoxarifado.";
            }
        }

        #region Setters
        private void setBeanIntoTextBox()
        {
            txtId.Text = bean.idAlmoxarifado.ToString();
            txtDescr.Text = bean.descr;
        }

        private void setTextBoxIntoBean()
        {
            try
            {
                if (bean.idAlmoxarifado == 0)
                {
                    bean.idAlmoxarifado = Uteis.stringToInt(txtId.Text);
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
