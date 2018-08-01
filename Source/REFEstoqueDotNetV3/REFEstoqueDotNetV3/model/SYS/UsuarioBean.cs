using System;
using REFEstoqueDotNetV3.model.GRL;

namespace REFEstoqueDotNetV3.model.SYS
{
    public class UsuarioBean : BaseModel
    {
        private int _idUsuario;
        private PessoaBean _pessoa;
        private String _login;
        private String _senha;

        public UsuarioBean()
        {
            pessoa = new PessoaBean();
        }

        public override string ToString()
        {
            return login + " (ID:" + idUsuario + ")";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is UsuarioBean))
            {
                return false;
            }
            else
            {
                UsuarioBean other = (UsuarioBean)obj;
                if (this.idUsuario == other.idUsuario)
                {
                    return true;
                }
                else
                    return false;
            }
        }

        public override int GetHashCode()
        {
            return idUsuario.GetHashCode();
        }

        public int idUsuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
        }
        public PessoaBean pessoa
        {
            get { return _pessoa; }
            set { _pessoa = value; }
        }
        public String login
        {
            get { return _login; }
            set { _login = value; }
        }
        public String senha
        {
            get { return _senha; }
            set { _senha = value; }
        }
    }
}
