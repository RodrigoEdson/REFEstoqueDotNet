using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace REFEstoqueDotNetV3.model.DIC
{
    public class TabelaBean : BaseModel
    {
        private int _idTabela;
        private string _nomeTabela;
        private string _labelForm;
        private int _alturaForm;
        private int _comprimentoForm;
        private List<ColunaBean> _colunas;

        public int idTabela
        {
            get { return _idTabela; }
            set { _idTabela = value; }
        }

        public string nomeTabela
        {
            get { return _nomeTabela; }
            set { _nomeTabela = value; }
        }

        public string labelForm
        {
            get { return _labelForm; }
            set { _labelForm = value; }
        }

        public int alturaForm
        {
            get { return _alturaForm; }
            set { _alturaForm = value; }
        }
        public int comprimentoForm
        {
            get { return _comprimentoForm; }
            set { _comprimentoForm = value; }
        }

        public List<ColunaBean> colunas
        {
            get { return _colunas; }
            set { _colunas = value; }
        }
    }
}
