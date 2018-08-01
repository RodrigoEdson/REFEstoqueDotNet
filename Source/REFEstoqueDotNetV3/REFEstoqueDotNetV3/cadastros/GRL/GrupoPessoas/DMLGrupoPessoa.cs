using System;
using System.Windows.Forms;
using REFEstoqueDotNetV3.DAO.GRL;
using REFEstoqueDotNetV3.model.GRL;
using REFEstoqueDotNetV3.system;

namespace REFEstoqueDotNetV3.cadastros.GRL.GrupoPessoas
{
    public partial class DMLGrupoPessoa : BaseDMLForm
    {
        private GrupoPessoaBean bean;
        public DMLGrupoPessoa()
        {
            InitializeComponent();
            bean = new GrupoPessoaBean();
            tipoDML = TipoDMLForm.INSERT;
        }
        public void init(GrupoPessoaBean grupoPessoaBean, TipoDMLForm tipoDMLForm)
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
                int qtdregistros = GrupoPessoaDAO.insert(bean);

                txtIdGrupoPessoa.Text = bean.idGrupoPessoa.ToString();
                pnlMessage.status = MessageStatus.SUCCESS;
                pnlMessage.textMessage = "Grupo de Pessoa inserido com sucesso.";
                pnlPrincipal.Enabled = false;
                isCommited = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                pnlMessage.status = MessageStatus.ERROR;
                pnlMessage.textMessage = "Erro ao inserir o Grupo de Pessoa.";
            }
        }

        private void excluir()
        {
            try
            {
                int qtdregistros = GrupoPessoaDAO.delete(bean.idGrupoPessoa);
                pnlMessage.status = MessageStatus.SUCCESS;
                pnlMessage.textMessage = "Grupo de Pessoa excluido com sucesso.";
                pnlPrincipal.Enabled = false;
                isCommited = true;
                bean = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                pnlMessage.status = MessageStatus.ERROR;
                pnlMessage.textMessage = "Erro ao excluir o Grupo de Pessoa.";
            }
        }

        private void alterar()
        {
            try
            {
                validarRegistro(this);
                setTextBoxIntoBean();
                int qtdregistros = GrupoPessoaDAO.update(bean);
                pnlMessage.status = MessageStatus.SUCCESS;
                pnlMessage.textMessage = "Grupo de Pessoa alterado com sucesso.";
                pnlPrincipal.Enabled = false;
                isCommited = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                pnlMessage.status = MessageStatus.ERROR;
                pnlMessage.textMessage = "Erro ao alterar o Grupo de Pessoa.";
            }
        }

        #region Setters
        private void setBeanIntoTextBox()
        {
            txtIdGrupoPessoa.Text = bean.idGrupoPessoa.ToString();
            txtDescr.Text = bean.descr;
        }

        private void setTextBoxIntoBean()
        {
            try
            {
                if (bean.idGrupoPessoa == 0)
                {
                    bean.idGrupoPessoa = Uteis.stringToInt(txtIdGrupoPessoa.Text);
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
