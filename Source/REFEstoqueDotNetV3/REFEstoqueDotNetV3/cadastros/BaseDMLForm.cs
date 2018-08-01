using System;
using System.Windows.Forms;
using REFEstoqueDotNetV3.system;
using REFEstoqueDotNetV3.exceptions;
using REFEstoqueDotNetV3.REF.componentes;
using REFEstoqueDotNetV3.REF.forms;

namespace REFEstoqueDotNetV3.cadastros
{
    public partial class BaseDMLForm : BaseForm
    {
        private TipoDMLForm _tipoDML = TipoDMLForm.INSERT;
        private bool _isCommited = false;

        public BaseDMLForm()
        {
            InitializeComponent();

            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        }

        #region botoes
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            closeForm();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            confirmar();
        }

        protected virtual void confirmar()
        {
            isCommited = true;
        }

        protected override void closeForm()
        {
            if (tipoDML == TipoDMLForm.DELETE || tipoDML == TipoDMLForm.VIEW || isCommited)
            {
                base.closeForm();
            }
            else
            {
                DialogResult result = MessageBox.Show("Cancelar alterações?",
                      "Deseja voltar e abandonar as alterações não salvas?",
                      MessageBoxButtons.YesNoCancel,
                      MessageBoxIcon.Question,
                      MessageBoxDefaultButton.Button2,
                      MessageBoxOptions.ServiceNotification,
                      false);
                if (result == DialogResult.Yes)
                {
                    base.closeForm();
                }
            }
        }
        #endregion

        #region validacao
        protected void validarRegistro(Control container)
        {
            if (container != null)
            {
                foreach (Control c in container.Controls)
                {
                    if (c.Controls.Count > 0)
                    {
                        validarRegistro(c);
                    }
                    else
                    {
                        if (c is REFTextBox)
                        {
                            REFTextBox t = (REFTextBox)c;
                            if (t.tipo == TipoTextBox.REQUIRED && t.Text == "")
                            {
                                t.Select();
                                throw new ValueRequiredException("Campo de preenchimento obrigatório.");
                            }
                        }
                        else if (c is REFComboBox)
                        {
                            REFComboBox t = (REFComboBox)c;
                            if (t.tipo == TipoComboBox.REQUIRED && t.Text == "")
                            {
                                t.Select();
                                throw new ValueRequiredException("Campo de preenchimento obrigatório.");
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region properties
        public TipoDMLForm tipoDML
        {
            get { return _tipoDML; }
            set
            {
                _tipoDML = value;
                switch (_tipoDML)
                {
                    case TipoDMLForm.INSERT:
                        this.Text = "Inclusão de Registro";
                        this.btnConfirmar.Text = "&Salvar";
                        this.btnConfirmar.Image = global::REFEstoqueDotNetV3.Properties.Resources.icon_includ;
                        break;
                    case TipoDMLForm.UPDATE:
                        this.Text = "Alteração de Registro";
                        this.btnConfirmar.Text = "&Salvar";
                        this.btnConfirmar.Image = global::REFEstoqueDotNetV3.Properties.Resources.icon_includ;
                        break;
                    case TipoDMLForm.DELETE:
                        this.Text = "Exclusão de Registro";
                        this.btnConfirmar.Text = "&Excluir";
                        this.btnConfirmar.Image = global::REFEstoqueDotNetV3.Properties.Resources.excluir;
                        break;
                    case TipoDMLForm.VIEW:
                        this.Text = "Visualização de Registro";
                        this.btnConfirmar.Text = "&OK";
                        this.btnConfirmar.Image = global::REFEstoqueDotNetV3.Properties.Resources.icon_includ;
                        break;
                }
            }
        }

        public bool isCommited
        {
            get { return _isCommited; }
            set { _isCommited = value; }
        }
        #endregion

        protected void setBtnConfirmarText(string txt)
        {
            this.btnConfirmar.Text = txt;
        }
    }
}
