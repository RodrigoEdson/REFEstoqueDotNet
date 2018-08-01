using System;

namespace REFEstoqueDotNetV3.model.GRL
{
    public class GrupoPessoaBean : BaseModel
    {
        private int _idGrupoPessoa;
        private String _descr;

        public override string ToString()
        {
            return descr +" (ID:"+idGrupoPessoa+")";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is GrupoPessoaBean))
            {
                return false;
            }
            else
            {
                GrupoPessoaBean other = (GrupoPessoaBean)obj;
                if (this.idGrupoPessoa == other.idGrupoPessoa)
                {
                    return true;
                }
                else
                    return false;
            }
        }

        public override int GetHashCode()
        {
            return idGrupoPessoa.GetHashCode();
        }

        public int idGrupoPessoa
        {
            get { return _idGrupoPessoa; }
            set { _idGrupoPessoa = value; }
        }

        public String descr
        {
            get { return _descr; }
            set { _descr = value; }
        }
    }
}
