using System;
using System.Collections.Generic;
using System.Windows.Forms;
using REFEstoqueDotNetV3.cadastros.GRL.Pessoa;
using REFEstoqueDotNetV3.DAO.SYS;
using REFEstoqueDotNetV3.DAO.GRL;
using REFEstoqueDotNetV3.model.SYS;
using REFEstoqueDotNetV3.model.GRL;
using REFEstoqueDotNetV3.exceptions;
using REFEstoqueDotNetV3.system;
using REFEstoqueDotNetV3.system.security;

namespace REFEstoqueDotNetV3.cadastros.SYS.Usuario
{
    public partial class DMLUsuario : BaseDMLForm
    {
        private UsuarioBean bean;
        public DMLUsuario()
        {
            bean = new UsuarioBean();
            InitializeComponent();
        }

        public void init(UsuarioBean beanUsr, TipoDMLForm tipoDMLForm)
        {
            bean = beanUsr;
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
                int qtdregistros = UsuarioDAO.insert(bean);

                txtIdUsuario.Text = bean.idUsuario.ToString();
                pnlMessage.status = MessageStatus.SUCCESS;
                pnlMessage.textMessage = "Usuário inserido com sucesso.";
                pnlPrincipal.Enabled = false;
                isCommited = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                pnlMessage.status = MessageStatus.ERROR;
                pnlMessage.textMessage = "Erro ao inserir o Usuário.";
            }
        }
        private void excluir()
        {
            try
            {
                int qtdregistros = UsuarioDAO.delete(bean.idUsuario);
                pnlMessage.status = MessageStatus.SUCCESS;
                pnlMessage.textMessage = "Usuário excluido com sucesso.";
                pnlPrincipal.Enabled = false;
                isCommited = true;
                bean = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                pnlMessage.status = MessageStatus.ERROR;
                pnlMessage.textMessage = "Erro ao excluir o Usuário.";
            }
        }
        private void alterar()
        {
            try
            {
                validarRegistro(this);
                setTextBoxIntoBean();
                int qtdregistros = UsuarioDAO.update(bean);
                pnlMessage.status = MessageStatus.SUCCESS;
                pnlMessage.textMessage = "Usuário alterado com sucesso.";
                pnlPrincipal.Enabled = false;
                isCommited = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                pnlMessage.status = MessageStatus.ERROR;
                pnlMessage.textMessage = "Erro ao alterar o Usuário.";
            }
        }


        #region Setters
        private void setBeanIntoTextBox()
        {
            txtIdUsuario.Text = bean.idUsuario.ToString();
            txtLogin.Text = bean.login;
            if (bean.pessoa != null)
            {
                txtIdPessoa.Text = bean.pessoa.idPessoa.ToString();
                txtNomePessoa.Text = bean.pessoa.ToString();
            }
        }

        private void setTextBoxIntoBean()
        {
            try
            {
                if (bean.idUsuario == 0)
                {
                    bean.idUsuario = Uteis.stringToInt(txtIdUsuario.Text);
                }
                bean.login = txtLogin.Text;
                int id = Uteis.stringToInt(txtIdPessoa.Text);
                bean.pessoa = PessoaDAO.getRecord(id);

                if ((txtSenha1.Text != "") && (txtSenha2.Text != ""))
                {
                    if (txtSenha1.Text.Trim() == txtSenha2.Text)
                    {
                        bean.senha = REFHash.getMD5Hash(txtSenha1.Text);
                    }
                    else
                    {
                        throw new InvalidPassworldException("Senha não diferente de sua confirmação.");
                    }
                }
            }
            catch (InvalidPassworldException i)
            {
                throw i;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        #endregion

        private void txtIdPessoa_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtIdPessoa.Text != "")
            {
                try
                {
                    int id = Uteis.stringToInt(txtIdPessoa.Text.Trim());
                    PessoaBean pes = PessoaDAO.getRecord(id);
                    if (pes.idPessoa == 0)
                    {
                        throw new Exception("Pessoa não encontrada.");
                    }
                    txtNomePessoa.Text = pes.ToString();
                    bean.pessoa = pes;
                    txtSenha1.Select();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ID de Pessoa inválido. (" + ex.Message + ")");
                    txtIdPessoa.Select();
                    txtNomePessoa.Text = "";
                }
            }
            else
            {
                txtNomePessoa.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FindPessoa f = new FindPessoa();
            f.ShowDialog();
            if (f.isSelected)
            {
                PessoaBean p = f.getSelectedPessoa();
                if (p != null)
                {
                    bean.pessoa = p;
                    txtIdPessoa.Text = p.idPessoa.ToString();
                    txtNomePessoa.Text = p.ToString();
                }
            }
        }
    }
}
