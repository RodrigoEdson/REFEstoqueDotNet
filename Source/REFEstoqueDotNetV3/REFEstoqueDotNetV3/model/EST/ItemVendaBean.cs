using System;
using REFEstoqueDotNetV3.model.GRL;


namespace REFEstoqueDotNetV3.model.EST
{
    public class ItemVendaBean : BaseModel
    {
        private int _idItemVenda;
        private VendaBean _venda;
        private ProdutoBean _produto;
        private double _qtdProduto;
        //private double _vlrUnitario;

        public override string ToString()
        {
            return produto.ToString() + " - Venda:" + venda + " - Quantidade:" + qtdProduto + " - Valor:" + (qtdProduto * vlrItem);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is ItemVendaBean))
            {
                return false;
            }
            else
            {
                ItemVendaBean other = (ItemVendaBean)obj;
                if (this.venda.idVenda == other.venda.idVenda &&
                    this.produto.idProduto == other.produto.idProduto)
                {
                    return true;
                }
                else
                    return false;
            }
        }

        public override int GetHashCode()
        {
            return this.venda.GetHashCode() + this.produto.GetHashCode();
        }

        public int idItemVenda
        {
            get { return _idItemVenda; }
            set { _idItemVenda = value; }
        }
        public VendaBean venda
        {
            get { return _venda; }
            set { _venda = value; }
        }
        public ProdutoBean produto
        {
            get { return _produto; }
            set { _produto = value; }
        }
        public double qtdProduto
        {
            get { return _qtdProduto; }
            set { _qtdProduto = value; }
        }
        public double vlrItem
        {
            get
            {
                if (this.produto != null)
                    return qtdProduto * this.produto.vlrUnitario;
                else
                    return 0;
            }
            //set { _vlrUnitario = value; }
        }
    }
}
