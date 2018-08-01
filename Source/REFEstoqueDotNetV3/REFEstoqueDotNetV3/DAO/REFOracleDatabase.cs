using System;
using System.Data;
using Oracle.DataAccess.Client;


namespace REFEstoqueDotNetV3.DAO
{
    public abstract class REFOracleDatabase
    {
        #region ConnectionString

        public static readonly string CONN_STRING = Properties.Settings.Default.OracleConnectionString;

        #endregion

        #region ExecuteReader
        public static OracleDataReader ExecuteReader(CommandType cmdType, string cmdText, params OracleParameter[] cmdParms)
        {
            OracleDataReader dr = null;
            OracleConnection conn = new OracleConnection(CONN_STRING);
            try
            {
                OracleCommand cmd = new OracleCommand();
                PrepareParameters(cmdParms);
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                conn.Close();
                conn.Dispose();
                throw (ex);

            }
            return dr;
        }
        public static OracleDataReader ExecuteReader(OracleTransaction trans, CommandType cmdType, string cmdText, params OracleParameter[] cmdParms)
        {
            OracleDataReader dr = null;
            try
            {
                OracleCommand cmd = new OracleCommand();
                PrepareParameters(cmdParms);
                PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, cmdParms);
                dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return dr;
        }
        #endregion

        #region ExecuteNonQueryCmd
        public static OracleCommand ExecuteNonQueryCmd(CommandType cmdType, string cmdText, out int qtd , params OracleParameter[] cmdParms)
        {
            OracleCommand cmd = new OracleCommand();
            using (OracleConnection conn = new OracleConnection(CONN_STRING))
            {
                try
                {
                    PrepareParameters(cmdParms);
                    PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                    qtd = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    conn.Close();
                    conn.Dispose();
                    throw (ex);
                }
            }
            return cmd;
        }
        public static OracleCommand ExecuteNonQueryCmd(OracleTransaction trans, CommandType cmdType, string cmdText, out int qtd , params OracleParameter[] cmdParms)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.BindByName = true;
            PrepareParameters(cmdParms);
            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, cmdParms);
            qtd = cmd.ExecuteNonQuery();
            return cmd;
        }
        #endregion

        #region PrepareCommand
        private static void PrepareCommand(OracleCommand cmd, OracleConnection conn, OracleTransaction trans, CommandType cmdType, string cmdText, OracleParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            if (trans != null)
                cmd.Transaction = trans;

            cmd.CommandType = cmdType;

            if (cmdParms != null)
            {
                foreach (OracleParameter parm in cmdParms)
                {
                    if (cmd.Parameters.Contains(parm))
                        cmd.Parameters[parm.ParameterName] = parm;
                    else
                        cmd.Parameters.Add(parm);
                }
            }
        }
        #endregion

        #region PrepareParameters
        private static void PrepareParameters(OracleParameter[] cmdParms)
        {
            if (cmdParms != null)
            {
                foreach (OracleParameter parm in cmdParms)
                {
                    if ((parm.DbType.Equals(DbType.AnsiString) || parm.DbType.Equals(DbType.AnsiStringFixedLength)) && parm.Value != DBNull.Value)
                    {
                        parm.Value = RemoveQuote(parm.Value.ToString());
                        if (parm.Value.ToString() == String.Empty)
                            parm.Value = DBNull.Value;
                    }
                }
            }
        }
        #endregion

        #region Uteis
        private static string RemoveQuote(string text)
        {
            text = text.Replace("'", String.Empty);
            text = text.Replace("\"", String.Empty);
            text = text.Replace("´", String.Empty);
            return text;
        }

        public static string addAndWhere(string where, string comando)
        {
            string whereALterado = null;

            if (where == null)
            {
                whereALterado = " where " + comando;
            }
            else
            {
                whereALterado = where + " and " + comando;
            }

            return whereALterado;
        }
        #endregion
    }
}
