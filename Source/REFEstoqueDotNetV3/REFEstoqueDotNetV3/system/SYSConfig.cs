using System;
using REFEstoqueDotNetV3.model.SYS;
using System.Windows.Forms;

namespace REFEstoqueDotNetV3.system
{
    public static class SYSConfig
    {
        private static UsuarioBean _usrLogado = null;
        private static ToolStripLabel _messageStripLabel;


        public static UsuarioBean usrLogado
        {
            get { return _usrLogado; }
        }

        public static void initSys(UsuarioBean usr, ToolStripLabel messageStripLabel)
        {
            _usrLogado = usr;
            _messageStripLabel = messageStripLabel;
        }

        public static void message(String texto)
        {
            _messageStripLabel.Text = texto;
        }

        public static void cloearMessage()
        {
            _messageStripLabel.Text = "";
        }
    }
}
