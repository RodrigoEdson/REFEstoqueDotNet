using System.Collections;
using System.Windows.Forms;
using System.Collections.Generic;
using REFEstoqueDotNetV3.DAO.GRL;
using REFEstoqueDotNetV3.model;
using REFEstoqueDotNetV3.model.GRL;
using REFEstoqueDotNetV3.system;
using REFEstoqueDotNetV3.REF.componentes;


namespace REFEstoqueDotNetV3.cadastros.GRL
{
    public partial class CadGrupoPessoa : BaseCadForm
    {
        public CadGrupoPessoa()
        {
            InitializeComponent();
            init(new GrupoPessoaBean(), this);
        }

        protected override void consultar()
        {
            GrupoPessoaBean filtro = new GrupoPessoaBean();
            filtro.idGrupoPessoa = getNumberFromText(txtIdGrupoPessoa);
            filtro.descr = txtDescr.Text;

            List<GrupoPessoaBean> list = GrupoPessoaDAO.getRecords(filtro);
            this.beanDataSet = new ArrayList(list);
            finalizarConsulta();
        }

        protected override void novo()
        {
            GrupoPessoaBean obj = new GrupoPessoaBean();

            this.incluirRegistro(obj);
        }

        protected override void setObgectValues(BaseModel beanObj)
        {
            GrupoPessoaBean bean = (GrupoPessoaBean)beanObj;
            txtIdGrupoPessoa.setText(bean.idGrupoPessoa.ToString());
            txtDescr.setText(bean.descr);
            //concluir com o processamento da super classe
            base.setObgectValues(bean);
        }

        protected override object getObgectValues(BaseModel beanObj)
        {
            GrupoPessoaBean bean = (GrupoPessoaBean)beanObj;

            if (txtDescr.isAltered)
            {
                bean.descr = txtDescr.Text.Trim();
            }

            return bean;
        }
    }
}

