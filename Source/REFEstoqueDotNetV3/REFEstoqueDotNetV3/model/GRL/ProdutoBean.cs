using System;
using System.Collections.Generic;
using REFEstoqueDotNetV3.model.EST;

namespace REFEstoqueDotNetV3.model.GRL
{
    public class ProdutoBean : BaseModel
    {

        private int _idProduto;
        private GrupoProdutoBean _grupoProduto;
        private String _descr;
        private String _unidade;
        private double _qtdEstoqueMin;
        private double _qtdEstoqueIdeal;
        private double _vlrUnitario;
        private double _vlrUnitarioMedio;
        private double _pctLucro;
        private String _codBarras;
        private String _obs;
        private List<SaldoProdutoBean> _saldos = null;

        public int idProduto
        {
            get { return _idProduto; }
            set { _idProduto = value; }
        }

        public GrupoProdutoBean grupoProduto
        {
            get { return _grupoProduto; }
            set { _grupoProduto = value; }
        }

        public String descr
        {
            get { return _descr; }
            set { _descr = value; }
        }

        public String unidade
        {
            get { return _unidade; }
            set { _unidade = value; }
        }

        public double qtdEstoqueMin
        {
            get { return _qtdEstoqueMin; }
            set { _qtdEstoqueMin = value; }
        }

        public double qtdEstoqueIdeal
        {
            get { return _qtdEstoqueIdeal; }
            set { _qtdEstoqueIdeal = value; }
        }

        public double vlrUnitario
        {
            get { return _vlrUnitario; }
            set { _vlrUnitario = value; }
        }

        public double vlrUnitarioMedio
        {
            get { return _vlrUnitarioMedio; }
            set { _vlrUnitarioMedio = value; }
        }


        public double pctLucro
        {
            get { return _pctLucro; }
            set { _pctLucro = value; }
        }

        public string codBarras
        {
            get { return _codBarras; }
            set { _codBarras = value; }
        }

        public string obs
        {
            get { return _obs; }
            set { _obs = value; }
        }

        public List<SaldoProdutoBean> saldos
        {
            get { return _saldos; }
            set { _saldos = value; }
        }

        public double saldoTotal
        {
            get
            {
                double vlr = 0;
                if (saldos != null)
                    foreach (SaldoProdutoBean saldo in saldos)
                    {
                        vlr += saldo.saldo;
                    }
                return vlr;
            }
        }

        public override string ToString()
        {
            return descr + " (ID:" + idProduto + ")";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is ProdutoBean))
            {
                return false;
            }
            else
            {
                ProdutoBean other = (ProdutoBean)obj;
                if (this.idProduto == other.idProduto)
                {
                    return true;
                }
                else
                    return false;
            }
        }

        public override int GetHashCode()
        {
            return idProduto.GetHashCode();
        }
    }
}
