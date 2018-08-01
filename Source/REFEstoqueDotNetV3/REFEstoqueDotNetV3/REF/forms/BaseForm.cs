
using System;
using System.Windows.Forms;

namespace REFEstoqueDotNetV3.REF.forms
{
    public class BaseForm : System.Windows.Forms.Form
    {
        private bool _isEscClose = true;

        public BaseForm()
        {
            this.KeyPreview = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDownForm);
        }

        public bool isEscClose
        {
            get { return _isEscClose; }
            set { _isEscClose = value; }
        }

        protected virtual void keyDownForm(object sender, KeyEventArgs e)
        {
            //mudar de campo com enter
            if (e.KeyCode == Keys.Enter)
            {
                if (!((sender as Form).ActiveControl is TextBox)||
                    ((sender as Form).ActiveControl as TextBox).Multiline == false)
                this.selectNextControl();
            }
            //fechar com esc
            else if (e.KeyCode == Keys.Escape && isEscClose)
            {
                closeForm();
            }
        }

        //metodos 
        protected virtual void closeForm()
        {
            if (!this.IsMdiContainer)
            {
                this.Close();
            }
        }

        protected void showForm(Form frm, Boolean isDialog)
        {
            frm.StartPosition = FormStartPosition.CenterScreen;
            if (isDialog)
                frm.ShowDialog(this);
            else
                frm.Show(this);
        }

        private void selectNextControl()
        {
            if (!(this.ActiveControl is DataGridView))
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, false);
            }
        }

    }
}
