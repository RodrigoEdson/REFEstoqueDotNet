using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using REFEstoqueDotNetV3.system;
using REFEstoqueDotNetV3.model;

namespace REFEstoqueDotNetV3.REF.componentes
{
    public class REFPanelNavigator : Panel
    {
        private Button btnUltimo;
        private Button btnAnterior;
        private Button btnProximo;
        private Button btnPrimeiro;

        private TextBox txtRecordCout;

        private int _beanIndex = 0;

        public REFPanelNavigator()
        {
            this.txtRecordCout = new TextBox();
            this.btnUltimo = new Button();
            this.btnAnterior = new Button();
            this.btnProximo = new Button();
            this.btnPrimeiro = new Button();

            this.Controls.Add(this.txtRecordCout);
            this.Controls.Add(this.btnUltimo);
            this.Controls.Add(this.btnAnterior);
            this.Controls.Add(this.btnProximo);
            this.Controls.Add(this.btnPrimeiro);


        }


        private void prepararIndex()
        {
            if (beanDataSet != null && beanDataSet.Count > 0)
            {
                txtRecordCout.Text = beanIndex + " de " + beanDataSet.Count;
            }
            else
            {
                beanIndex = 0;
                txtRecordCout.Text = "-------";
            }
        }

        #region properties
        protected int beanIndex
        {
            set
            {
                if (value >= 0)
                {
                    _beanIndex = value;
                }
                else
                {
                    _beanIndex = 0;
                }
            }
            get { return _beanIndex; }
        }

        public ArrayList beanDataSet
        {
            set;
            get;
        }
        #endregion
    }
}
