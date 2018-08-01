using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace REFEstoqueDotNetV3.model.GRL
{
    public class PessoaBean
    {
        private int _idPessoa;
        private GrupoPessoaBean _grupoPessoa;
        private string _nome;
        private string _apelido;
        private string _numDoc;
        private string _tipoDoc;
        private string _tel1;
        private string _tel2;
        private string _tel3;
        private string _logradouro;
        private string _numero;
        private string _complemento;
        private string _bairro;
        private string _cep;
        private string _pontoRef;
        private string _obs;

        public PessoaBean()
        {
            grupoPessoa = new GrupoPessoaBean();
        }

        public override string ToString()
        {
            return nome + " (Apelido: " + apelido + ",ID:" + idPessoa + ")";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is PessoaBean))
            {
                return false;
            }
            else
            {
                PessoaBean other = (PessoaBean)obj;
                if (this.idPessoa == other.idPessoa)
                {
                    return true;
                }
                else
                    return false;
            }
        }

        public override int GetHashCode()
        {
            return idPessoa.GetHashCode();
        }

        public int idPessoa
        {
            get { return _idPessoa; }
            set { _idPessoa = value; }
        }

        public GrupoPessoaBean grupoPessoa
        {
            get { return _grupoPessoa; }
            set { _grupoPessoa = value; }
        }

        public string nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public string apelido
        {
            get { return _apelido; }
            set { _apelido = value; }
        }

        public string numDoc
        {
            get { return _numDoc; }
            set { _numDoc = value; }
        }

        public string tipoDoc
        {
            get { return _tipoDoc; }
            set { _tipoDoc = value; }
        }

        public string tel1
        {
            get { return _tel1; }
            set { _tel1 = value; }
        }

        public string tel2
        {
            get { return _tel2; }
            set { _tel2 = value; }
        }

        public string tel3
        {
            get { return _tel3; }
            set { _tel3 = value; }
        }

        public string logradouro
        {
            get { return _logradouro; }
            set { _logradouro = value; }
        }

        public string numero
        {
            get { return _numero; }
            set { _numero = value; }
        }

        public string complemento
        {
            get { return _complemento; }
            set { _complemento = value; }
        }

        public string bairro
        {
            get { return _bairro; }
            set { _bairro = value; }
        }

        public string cep
        {
            get { return _cep; }
            set { _cep = value; }
        }

        public string pontoRef
        {
            get { return _pontoRef; }
            set { _pontoRef = value; }
        }

        public string obs
        {
            get { return _obs; }
            set { _obs = value; }
        }
    }
}
