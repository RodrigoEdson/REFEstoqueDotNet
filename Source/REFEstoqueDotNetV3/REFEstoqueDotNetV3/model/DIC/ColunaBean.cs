using System;
using System.Collections.Generic;
using REFEstoqueDotNetV3.exceptions;
using System.Text;

namespace REFEstoqueDotNetV3.model.DIC
{
    public class ColunaBean : BaseModel
    {
        private int _idColuna;
        private TabelaBean _tabela;
        private string _nomeColuna;
        private string _labelColuna;
        private string _indObrigatorio;
        private string _indVisivelGrid;
        private int _ordemExibicao;
        private int _tamanhoColunaGrid;
        private int _tamanhoItemForm;
        private string _tipoColuna;
        private string _valorDefault;
        private string _nomeColunaBean;
        private int _tamanhoColunaBD;
        private int _casasDecimais;


        public int idColuna
        {
            get { return _idColuna; }
            set { _idColuna = value; }
        }

        public TabelaBean tabela
        {
            get { return _tabela; }
            set { _tabela = value; }
        }

        public string nomeColuna
        {
            get { return _nomeColuna; }
            set { _nomeColuna = value; }
        }

        public string labelColuna
        {
            get { return _labelColuna; }
            set { _labelColuna = value; }
        }

        public string indObrigatorio
        {
            get { return _indObrigatorio; }
            set
            {
                String valor = value.ToUpper();
                if (valor != "S" && valor != "N")
                    throw new InvalidPropertyValueException("Valor inválido para a propriedade indObrigatorio! Informe 'S' ou 'N'.");
                else
                    _indObrigatorio = valor;
            }
        }

        public string indVisivelGrid
        {
            get { return _indVisivelGrid; }
            set
            {
                String valor = value.ToUpper();
                if (valor != "S" && valor != "N")
                    throw new InvalidPropertyValueException("Valor inválido para a propriedade indVisivelGrid! Informe 'S' ou 'N'.");
                else
                    _indVisivelGrid = valor;
            }
        }

        public int ordemExibicao
        {
            get { return _ordemExibicao; }
            set { _ordemExibicao = value; }
        }

        public int tamanhoColunaGrid
        {
            get { return _tamanhoColunaGrid; }
            set { _tamanhoColunaGrid = value; }
        }

        public int tamanhoItemForm
        {
            get { return _tamanhoItemForm; }
            set { _tamanhoItemForm = value; }
        }

        public string tipoColuna
        {
            get { return _tipoColuna; }
            set { _tipoColuna = value; }
        }

        public string valorDefault
        {
            get { return _valorDefault; }
            set { _valorDefault = value; }
        }

        public string nomeColunaBean
        {
            get { return _nomeColunaBean; }
            set { _nomeColunaBean = value; }
        }

        public int tamanhoColunaBD
        {
            get { return _tamanhoColunaBD; }
            set { _tamanhoColunaBD = value; }
        }

        public int casasDecimais
        {
            get { return _casasDecimais; }
            set { _casasDecimais = value; }
        }
    }
}
