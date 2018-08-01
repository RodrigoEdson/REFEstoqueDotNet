using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using REFEstoqueDotNetV3.REF.forms;

namespace REFEstoqueDotNetV3.cadastros
{
    public partial class BaseFindForm : BaseForm
    {
        private bool _isSelected = false;

        public BaseFindForm()
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
                case Keys.F8:
                    filtrar();
                    break;
                case Keys.F7:
                    focarFiltro();
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
            _isSelected = true;
            base.closeForm();
        }

        protected override void closeForm()
        {
            _isSelected = false;
            base.closeForm();
        }
        #endregion

        public bool isSelected
        {
            get { return _isSelected; }
            set { _isSelected = value; }
        }
    }
}
