using System;
using REFEstoqueDotNetV3.model.GRL;
using REFEstoqueDotNetV3.model.EST;

namespace REFEstoqueDotNetV3.model.EST
{
    public class SaldoProdutoBean : BaseModel
    {
        private int _idSaldoProduto;
        private double _saldo;
        private ProdutoBean _produto;
        private AlmoxarifadoBean _almoxarifado;

        public override string ToString()
        {
            return almoxarifado.descr + " - " + produto.descr + " (saldo:" + saldo + ")";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is SaldoProdutoBean))
            {
                return false;
            }
            else
            {
                SaldoProdutoBean other = (SaldoProdutoBean)obj;
                if (this.idSaldoProduto == other.idSaldoProduto)
                {
                    return true;
                }
                else
                    return false;
            }
        }
        
        public override int GetHashCode()
        {
            return idSaldoProduto.GetHashCode();
        }


        public int idSaldoProduto
        {
            get { return _idSaldoProduto; }
            set { _idSaldoProduto = value; }
        }

        public ProdutoBean produto
        {
            get { return _produto; }
            set { _produto = value; }
        }

        public AlmoxarifadoBean almoxarifado
        {
            get { return _almoxarifado; }
            set { _almoxarifado = value; }
        }

        public double saldo
        {
            get { return _saldo; }
            set { _saldo = value; }
        }

    }
}
