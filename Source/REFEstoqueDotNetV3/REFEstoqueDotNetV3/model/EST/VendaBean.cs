using System;
using System.Collections.Generic;
using REFEstoqueDotNetV3.model.GRL;
using REFEstoqueDotNetV3.exceptions;

namespace REFEstoqueDotNetV3.model.EST
{
    public class VendaBean : BaseModel
    {
        private int _idVenda;
        private PessoaBean _cliente;
        private List<ItemVendaBean> _itens;
        private DateTime _dtVenda;
        private DateTime _dtUltAlteracao;
        private DateTime _dtEmissao;
        private DateTime? _dtVencParcela1;
        private string _notaVenda;
        private double _vlrDesconto;
        //private double _vlrProdutos;
        private string _tipoVenda;
        private string _status;
        private int _qtdParcelas;
        private string _obs;

        public VendaBean()
        {
            this.dtVenda = DateTime.Today;
            this.dtEmissao = DateTime.Today;
            this.dtUltAlteracao = DateTime.Now;
            this.dtVencParcela1 = DateTime.Today;
            this.tipoVenda = "A VISTA";
            this.status = "NORMAL";
            this.qtdParcelas = 0;
            itens = new List<ItemVendaBean>();
        }

        public override string ToString()
        {
            return idVenda.ToString();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is VendaBean))
            {
                return false;
            }
            else
            {
                VendaBean other = (VendaBean)obj;
                if (this.idVenda == other.idVenda)
                {
                    return true;
                }
                else
                    return false;
            }
        }

        public override int GetHashCode()
        {
            return idVenda.GetHashCode();
        }

        public int idVenda
        {
            get { return _idVenda; }
            set { _idVenda = value; }
        }
        public PessoaBean cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }
        public List<ItemVendaBean> itens
        {
            get { return _itens; }
            set { _itens = value; }
        }
        public DateTime dtVenda
        {
            get { return _dtVenda; }
            set { _dtVenda = value; }
        }
        public DateTime dtUltAlteracao
        {
            get { return _dtUltAlteracao; }
            set { _dtUltAlteracao = value; }
        }
        public DateTime dtEmissao
        {
            get { return _dtEmissao; }
            set { _dtEmissao = value; }
        }
        public DateTime? dtVencParcela1
        {
            get { return _dtVencParcela1; }
            set { _dtVencParcela1 = value; }
        }
        public string notaVenda
        {
            get { return _notaVenda; }
            set { _notaVenda = value; }
        }
        public double vlrDesconto
        {
            get { return _vlrDesconto; }
            set { _vlrDesconto = value; }
        }
        public double vlrProdutos
        {
            get
            {
                double vlr = 0;
                if (itens != null)
                    foreach (ItemVendaBean item in itens)
                    {
                        vlr += item.vlrItem;
                    }
                return vlr; ;
            }
        }
        public double vlrTotal
        {
            get { return vlrProdutos - vlrDesconto; }
        }
        public string tipoVenda
        {
            get { return _tipoVenda; }
            set { _tipoVenda = value; }
        }
        public string status
        {
            get { return _status; }
            set { _status = value; }
        }

        public int qtdParcelas
        {
            get { return _qtdParcelas; }
            set
            {
                int valor  = value;
                if ((this.tipoVenda == "A VISTA") && (valor != 0))
                {
                    throw new InvalidPropertyValueException("Para venda 'A VISTA' o valor da parcela deve ser zero.");
                }
                else if ((this.tipoVenda == "PARCELADA") && (valor <= 0))
                {
                    throw new InvalidPropertyValueException("Para venda 'PARCELADA' o valor da parcela deve maior que zero.");
                }
                _qtdParcelas = valor;
            }
        }
        public string obs
        {
            get { return _obs; }
            set { _obs = value; }
        }
    }
}
