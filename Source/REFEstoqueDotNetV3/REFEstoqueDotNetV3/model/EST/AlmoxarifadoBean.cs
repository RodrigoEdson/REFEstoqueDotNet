using System;

namespace REFEstoqueDotNetV3.model.EST
{
    public class AlmoxarifadoBean : BaseModel
    {
        private int _idAlmoxarifado;
        private String _descr;

        public int idAlmoxarifado
        {
            get { return _idAlmoxarifado; }
            set { _idAlmoxarifado = value; }
        }

        public String descr
        {
            get { return _descr; }
            set { _descr = value; }
        }
        public override string ToString()
        {
            return descr + " (ID:" + idAlmoxarifado + ")";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is AlmoxarifadoBean))
            {
                return false;
            }
            else
            {
                AlmoxarifadoBean other = (AlmoxarifadoBean)obj;
                if (this.idAlmoxarifado == other.idAlmoxarifado)
                {
                    return true;
                }
                else
                    return false;
            }
        }

        public override int GetHashCode()
        {
            return idAlmoxarifado.GetHashCode();
        }
        
    }
}
