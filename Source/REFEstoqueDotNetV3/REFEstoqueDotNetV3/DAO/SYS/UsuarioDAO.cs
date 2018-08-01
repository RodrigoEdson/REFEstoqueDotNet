using System;
using System.Collections.Generic;
using System.Data;
using Oracle.DataAccess.Client;
using REFEstoqueDotNetV3.model.SYS;
using REFEstoqueDotNetV3.DAO.GRL;

namespace REFEstoqueDotNetV3.DAO.SYS
{
    public class UsuarioDAO
    {

        #region  Stored Procedures / Commands
        private const string ORDER_BY = " order by login";
        private const string CMDSELECT = "Select * from sys_usuario ";
        private const string CMDSELECT_BY_LOGIN = "Select * from sys_usuario where login = :login and senha = :senha";
        private const string CMDINSERT = "insert into sys_usuario( id_usuario, id_pessoa, login, senha)" +
                                        " values(:id_usuario, :id_pessoa, :login, :senha) " +
                                        " returning id_usuario into :id_usuario_out ";
        private const string CMDUPDATE = " update sys_usuario " +
                                         " set id_pessoa = :id_pessoa, " +
                                         " login = :login, " +
                                         " senha = :senha " +
                                         " where id_usuario = :id_usuario ";
        private const string CMDDELETE = " delete from sys_usuario where id_usuario = :id_usuario ";
        #endregion

        #region public
        public static List<UsuarioBean> getRecords(UsuarioBean filter)
        {
            OracleDataReader dr = LoadDataReader(filter);
            List<UsuarioBean> list = null;
            try
            {
                list = SetInstance(dr);
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return list;
        }
        public static UsuarioBean getByLogin(String login, String senha)
        {
            UsuarioBean bean = new UsuarioBean();
            OracleDataReader dr = LoadDataReader(login, senha);
            try
            {
                SetInstance(dr, bean);
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return bean;
        }
        public static int insert(UsuarioBean bean)
        {
            int qtdInsert = 0;

            using (OracleConnection conn = new OracleConnection(REFOracleDatabase.CONN_STRING))
            {
                OracleParameter[] parms = GetParameters(true);
                SetParameters(parms, bean);

                conn.Open();
                using (OracleTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        OracleCommand cmd = REFOracleDatabase.ExecuteNonQueryCmd(trans, CommandType.Text, CMDINSERT, out qtdInsert, parms);
                        bean.idUsuario = Convert.ToInt32(cmd.Parameters["id_usuario_out"].Value.ToString());
                        cmd.Parameters.Clear();
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        throw (ex);
                    }
                }
            }

            return qtdInsert;
        }
        public static int delete(int idUsr)
        {
            if (idUsr == 1)
            {
                throw new Exception("Não é possível excluir o usuário ADMIN.");
            }
            int qtdDelete = 0;

            using (OracleConnection conn = new OracleConnection(REFOracleDatabase.CONN_STRING))
            {
                OracleParameter[] parms = {/*00*/ new OracleParameter("id_usuario", OracleDbType.Int32, ParameterDirection.Input) };
                parms[0].Value = idUsr;

                conn.Open();
                using (OracleTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        OracleCommand cmd = REFOracleDatabase.ExecuteNonQueryCmd(trans, CommandType.Text, CMDDELETE, out qtdDelete, parms);
                        cmd.Parameters.Clear();
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        throw (ex);
                    }
                }
            }

            return qtdDelete;
        }
        public static int update(UsuarioBean bean)
        {
            int qtdUpdate = 0;

            using (OracleConnection conn = new OracleConnection(REFOracleDatabase.CONN_STRING))
            {
                OracleParameter[] parms = GetParameters(false);
                SetParameters(parms, bean);

                conn.Open();
                using (OracleTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        OracleCommand cmd = REFOracleDatabase.ExecuteNonQueryCmd(trans, CommandType.Text, CMDUPDATE, out qtdUpdate, parms);
                        cmd.Parameters.Clear();
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        throw (ex);
                    }
                }
            }

            return qtdUpdate;
        }
        #endregion

        #region private
        private static OracleParameter[] GetParameters(bool isReturnValue)
        {
            OracleParameter[] parms;
            if (isReturnValue)
            {
                parms = new OracleParameter[]{
                /*00*/ new OracleParameter("id_usuario", OracleDbType.Int32,ParameterDirection.Input),
                /*01*/ new OracleParameter("id_pessoa", OracleDbType.Int32,ParameterDirection.Input),
                /*02*/ new OracleParameter("login", OracleDbType.Varchar2,ParameterDirection.Input),
                /*03*/ new OracleParameter("senha", OracleDbType.Varchar2,ParameterDirection.Input),
                /*04*/ new OracleParameter("id_usuario_out", OracleDbType.Int32,ParameterDirection.ReturnValue)
            };
            }
            else
            {
                parms = new OracleParameter[]{
                /*00*/ new OracleParameter("id_usuario", OracleDbType.Int32,ParameterDirection.Input),
                /*01*/ new OracleParameter("id_pessoa", OracleDbType.Int32,ParameterDirection.Input),
                /*02*/ new OracleParameter("login", OracleDbType.Varchar2,ParameterDirection.Input),
                /*03*/ new OracleParameter("senha", OracleDbType.Varchar2,ParameterDirection.Input)
            };
            }
            return parms;
        }
        private static void SetParameters(OracleParameter[] parms, UsuarioBean bean)
        {
            parms[0].Value = bean.idUsuario;
            parms[1].Value = bean.pessoa.idPessoa;
            parms[2].Value = bean.login;
            parms[3].Value = bean.senha;
        }
        private static List<UsuarioBean> SetInstance(OracleDataReader dr)
        {
            List<UsuarioBean> list = new List<UsuarioBean>();
            try
            {
                while (dr.Read())
                {
                    UsuarioBean obj = new UsuarioBean();
                    obj.idUsuario = Convert.ToInt32(dr["id_usuario"].ToString());
                    obj.login = dr["login"].ToString();
                    obj.senha = dr["senha"].ToString();

                    obj.pessoa = PessoaDAO.getRecord(Convert.ToInt32(dr["id_pessoa"].ToString()));

                    list.Add(obj);
                }
            }

            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (!dr.IsClosed)
                    dr.Close();
            }
            return list;
        }
        private static void SetInstance(OracleDataReader dr, UsuarioBean bean)
        {
            try
            {
                if (dr.Read())
                {
                    UsuarioBean obj = new UsuarioBean();
                    bean.idUsuario = Convert.ToInt32(dr["id_usuario"].ToString());
                    bean.login = dr["login"].ToString();
                    bean.senha = dr["senha"].ToString();

                    bean.pessoa = PessoaDAO.getRecord(Convert.ToInt32(dr["id_pessoa"].ToString()));
                }
            }

            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (!dr.IsClosed)
                    dr.Close();
            }
        }
        private static OracleDataReader LoadDataReader(UsuarioBean filtro)
        {
            String where = null;

            //montar o comando 
            if (filtro.idUsuario > 0)
            {
                where = REFOracleDatabase.addAndWhere(where, " id_usuario = " + filtro.idUsuario);
            }
            if (filtro.pessoa != null && filtro.pessoa.nome != null && filtro.pessoa.nome.Trim() != "")
            {
                where = REFOracleDatabase.addAndWhere(where, " id_pessoa in (" +
                                                             " select id_pessoa from GRL_PESSOA where upper(nome) like '" +
                                                              filtro.pessoa.nome.Trim().ToUpper().Replace("'", "''") + "')");
            }
            if (filtro.login != null && filtro.login.Trim() != "")
            {
                where = REFOracleDatabase.addAndWhere(where, " upper(login) like '" + filtro.login.Trim().ToUpper().Replace("'", "''") + "'");
            }
            //
            return REFOracleDatabase.ExecuteReader(CommandType.Text, CMDSELECT + where + ORDER_BY);
        }
        private static OracleDataReader LoadDataReader(String login, String senha)
        {
            OracleParameter[] parms = new OracleParameter[] { 
                new OracleParameter("login", OracleDbType.Varchar2, ParameterDirection.Input) ,
                new OracleParameter("senha", OracleDbType.Varchar2, ParameterDirection.Input)
            };
            parms[0].Value = login;
            parms[1].Value = senha;
            //
            return REFOracleDatabase.ExecuteReader(CommandType.Text, CMDSELECT_BY_LOGIN, parms);
        }
        #endregion
    }
}
