using System.Windows.Forms;
using REFEstoqueDotNetV3.REF.forms;

namespace REFEstoqueDotNetV3.cadastros
{
    public partial class BaseFilterForm : BaseForm
    {
        public BaseFilterForm()
        {
            InitializeComponent();
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
                case Keys.F9:
                    if (btnAlterar.Enabled)
                        this.alterar();
                    break;
                case Keys.F8:
                    filtrar();
                    break;
                case Keys.F7:
                    focarFiltro();
                    break;
                case Keys.F6:
                    if (btnNovo.Enabled)
                        this.novo();
                    break;
                case Keys.F3:
                    if (btnExcluir.Enabled)
                        this.excluir();
                    break;
            }
        }

        protected virtual void focarFiltro()
        {
            MessageBox.Show("focarFiltro");
        }
        protected virtual void filtrar()
        {
            MessageBox.Show("filtrar");
        }

        #endregion

        #region Botoes
        private void btnExcluir_Click(object sender, System.EventArgs e)
        {
            this.excluir();
        }
        private void btnNovo_Click(object sender, System.EventArgs e)
        {
            this.novo();
        }
        private void btnFechar_Click(object sender, System.EventArgs e)
        {
            this.fechar();
        }
        private void btnAlterar_Click(object sender, System.EventArgs e)
        {
            this.alterar();
        }

        protected virtual void novo()
        {
            MessageBox.Show("novo");
        }

        protected virtual void excluir()
        {
            MessageBox.Show("excluir");
        }

        protected virtual void fechar()
        {
            base.keyDownForm(this, new KeyEventArgs(Keys.Escape));
        }

        protected virtual void alterar()
        {
            MessageBox.Show("alterar");
        }
        #endregion

        protected void addBotaoPainel(Button botao)
        {
            this.pnlInferior.Controls.Add(botao);

            botao.Size = new System.Drawing.Size(75, 45);
            botao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        }
    }
}
