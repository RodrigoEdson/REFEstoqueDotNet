using System;
using System.Collections.Generic;
using System.Windows.Forms;
using REFEstoqueDotNetV3.DAO.GRL;
using REFEstoqueDotNetV3.model.GRL;
using REFEstoqueDotNetV3.system;


namespace REFEstoqueDotNetV3.cadastros.GRL.Pessoa
{
    public partial class DMLPessoa : BaseDMLForm
    {
        private PessoaBean bean;
        public DMLPessoa()
        {
            InitializeComponent();
            bean = new PessoaBean();
            tipoDML = TipoDMLForm.INSERT;
            setCombpGrupoPessoa();
        }

        public void init(PessoaBean pessoaBean, TipoDMLForm tipoDMLForm)
        {
            bean = pessoaBean;
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
                int qtdregistros = PessoaDAO.insert(bean);

                txtIdPessoa.Text = bean.idPessoa.ToString();
                pnlMessage.status = MessageStatus.SUCCESS;
                pnlMessage.textMessage = "Pessoa inserida com sucesso.";
                pnlPrincipal.Enabled = false;
                isCommited = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                pnlMessage.status = MessageStatus.ERROR;
                pnlMessage.textMessage = "Erro ao inserir a Pessoa.";
            }
        }
        private void excluir()
        {
            try
            {
                int qtdregistros = PessoaDAO.delete(bean.idPessoa);
                pnlMessage.status = MessageStatus.SUCCESS;
                pnlMessage.textMessage = "Pessoa excluida com sucesso.";
                pnlPrincipal.Enabled = false;
                isCommited = true;
                bean = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                pnlMessage.status = MessageStatus.ERROR;
                pnlMessage.textMessage = "Erro ao excluir a Pessoa.";
            }
        }
        private void alterar()
        {
            try
            {
                validarRegistro(this);
                setTextBoxIntoBean();
                int qtdregistros = PessoaDAO.update(bean);
                pnlMessage.status = MessageStatus.SUCCESS;
                pnlMessage.textMessage = "Pessoa alterada com sucesso.";
                pnlPrincipal.Enabled = false;
                isCommited = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                pnlMessage.status = MessageStatus.ERROR;
                pnlMessage.textMessage = "Erro ao alterar a Pessoa.";
            }
        }

        #region Setters
        private void setCombpGrupoPessoa()
        {
            cmbGrupoPressoa.DataSource = GrupoPessoaDAO.getRecords(new GrupoPessoaBean());
        }

        private void setBeanIntoTextBox()
        {
            txtIdPessoa.Text = bean.idPessoa.ToString();
            cmbGrupoPressoa.SelectedItem = bean.grupoPessoa;
            txtNome.Text = bean.nome;
            txtApelido.Text = bean.apelido;
            txtDocumento.Text = bean.numDoc;
            txtTipoDoc.Text = bean.tipoDoc;
            txtTel1.Text = bean.tel1;
            txtTel2.Text = bean.tel2;
            txtTel3.Text = bean.tel3;
            txtLogradouro.Text = bean.logradouro;
            txtNumero.Text = bean.numero;
            txtComplemento.Text = bean.complemento;
            txtBairro.Text = bean.bairro;
            txtCep.Text = bean.cep;
            txtPontoRefer.Text = bean.pontoRef;
            txtObs.Text = bean.obs;
        }

        private void setTextBoxIntoBean()
        {
            try
            {
                if (bean.idPessoa == 0)
                {
                    bean.idPessoa = Uteis.stringToInt(txtIdPessoa.Text);
                }
                GrupoPessoaBean g = (GrupoPessoaBean)cmbGrupoPressoa.SelectedItem;
                bean.grupoPessoa = g;

                bean.nome = txtNome.Text;
                bean.apelido = txtApelido.Text;
                bean.numDoc = txtDocumento.Text;
                bean.tipoDoc = txtTipoDoc.Text;
                bean.tel1 = txtTel1.Text;
                bean.tel2 = txtTel2.Text;
                bean.tel3 = txtTel3.Text;
                bean.logradouro = txtLogradouro.Text;
                bean.numero = txtNumero.Text;
                bean.complemento = txtComplemento.Text;
                bean.bairro = txtBairro.Text;
                bean.cep = txtCep.Text;
                bean.pontoRef = txtPontoRefer.Text;
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
