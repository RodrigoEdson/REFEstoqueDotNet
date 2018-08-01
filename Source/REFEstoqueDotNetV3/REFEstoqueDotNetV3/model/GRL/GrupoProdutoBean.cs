using System;

namespace REFEstoqueDotNetV3.model.GRL
{
    public class GrupoProdutoBean : BaseModel
    {
        private int _idGrupoProduto;
        private String _descr;

        public override string ToString()
        {
            return descr + " (ID:" + idGrupoProduto + ")";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is GrupoProdutoBean))
            {
                return false;
            }
            else
            {
                GrupoProdutoBean other = (GrupoProdutoBean)obj;
                if (this.idGrupoProduto == other.idGrupoProduto)
                {
                    return true;
                }
                else
                    return false;
            }
        }

        public int idGrupoProduto
        {
            get { return _idGrupoProduto; }
            set { _idGrupoProduto = value; }
        }

        public String descr
        {
            get { return _descr; }
            set { _descr = value; }
        }

        public override int GetHashCode()
        {
            return idGrupoProduto.GetHashCode();
        }
    }
}
