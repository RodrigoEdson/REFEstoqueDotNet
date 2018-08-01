using System;
using System.Collections.Generic;
using System.Data;
using Oracle.DataAccess.Client;
using REFEstoqueDotNetV3.model.GRL;

namespace REFEstoqueDotNetV3.DAO.GRL
{
    public static class GrupoPessoaDAO
    {

        #region  Stored Procedures / Commands
        private const string ORDER_BY = " order by descr";
        private const string CMDSELECT = "Select * from GRL_GRUPO_PESSOA ";
        private const string CMDSELECTBYID = "Select * from GRL_GRUPO_PESSOA where id_grupo_pessoa =:id_grupo_pessoa ";
        private const string CMDINSERT = "insert into GRL_GRUPO_PESSOA (id_grupo_pessoa, descr) " +
                                         "values (:id_grupo_pessoa_in, :descr) returning id_grupo_pessoa into :id_grupo_pessoa_out ";
        private const string CMDUPDATE = "update GRL_GRUPO_PESSOA  " +
                                         "set descr = :descr " +
                                         "where id_grupo_pessoa =:id_grupo_pessoa_in ";
        private const string CMDDELETE = "delete from  GRL_GRUPO_PESSOA  " +
                                         "where id_grupo_pessoa =:id_grupo_pessoa ";
        #endregion

        #region public

        public static int insert(GrupoPessoaBean bean)
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
                        bean.idGrupoPessoa = Convert.ToInt32(cmd.Parameters["id_grupo_pessoa_out"].Value.ToString());
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

        public static int update(GrupoPessoaBean bean)
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

        public static int delete(int idGrupoPessoa)
        {
            int qtdDelete = 0;

            using (OracleConnection conn = new OracleConnection(REFOracleDatabase.CONN_STRING))
            {
                OracleParameter[] parms = {/*00*/ new OracleParameter("id_grupo_pessoa", OracleDbType.Int32, ParameterDirection.Input) };
                parms[0].Value = idGrupoPessoa;

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

        public static List<GrupoPessoaBean> getRecords(GrupoPessoaBean filter)
        {
            OracleDataReader dr = LoadDataReader(filter);
            List<GrupoPessoaBean> list = null;
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

        public static GrupoPessoaBean getRecord(int id)
        {
            GrupoPessoaBean bean = new GrupoPessoaBean();
            OracleDataReader dr = LoadDataReader(id);
            try
            {
                 SetInstance(dr,bean);
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return bean;
        }
        #endregion

        #region private
        private static OracleParameter[] GetParameters(bool isReturnValue)
        {
            OracleParameter[] parms;
            if (isReturnValue)
            {
                parms = new OracleParameter[]{
                /*00*/ new OracleParameter("descr", OracleDbType.Varchar2,ParameterDirection.Input),
                /*01*/ new OracleParameter("id_grupo_pessoa_in", OracleDbType.Int32,ParameterDirection.Input),
                /*02*/ new OracleParameter("id_grupo_pessoa_out", OracleDbType.Int32,ParameterDirection.ReturnValue)
            };
            }
            else
            {
                parms = new OracleParameter[]{
                /*00*/ new OracleParameter("descr", OracleDbType.Varchar2,ParameterDirection.Input),
                /*01*/ new OracleParameter("id_grupo_pessoa_in", OracleDbType.Int32,ParameterDirection.Input)
            };
            }
            return parms;
        }
        private static void SetParameters(OracleParameter[] parms, GrupoPessoaBean bean)
        {
            parms[0].Value = bean.descr;
            parms[1].Value = bean.idGrupoPessoa;
        }
        private static List<GrupoPessoaBean> SetInstance(OracleDataReader dr)
        {
            List<GrupoPessoaBean> list = new List<GrupoPessoaBean>();
            try
            {
                while (dr.Read())
                {
                    GrupoPessoaBean obj = new GrupoPessoaBean();
                    obj.idGrupoPessoa = Convert.ToInt32(dr["id_grupo_pessoa"].ToString());
                    obj.descr = dr["descr"].ToString();
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
        private static bool SetInstance(OracleDataReader dr, GrupoPessoaBean bean)
        {
            try
            {
                if (dr.Read())
                {
                    bean.idGrupoPessoa = Convert.ToInt32(dr["id_grupo_pessoa"].ToString());
                    bean.descr = dr["descr"].ToString();
                    return true;
                }
                else
                {
                    return false;
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
        private static OracleDataReader LoadDataReader(GrupoPessoaBean filtro)
        {
            String where = null;

            //montar o comando 
            if (filtro.idGrupoPessoa > 0)
            {
                where = REFOracleDatabase.addAndWhere(where, " id_grupo_pessoa = " + filtro.idGrupoPessoa);
            }
            if (filtro.descr != null && filtro.descr.Trim() != "")
            {
                where = REFOracleDatabase.addAndWhere(where, " upper(descr) like '" + filtro.descr.Trim().ToUpper().Replace("'", "''") + "'");
            }
            //
            return REFOracleDatabase.ExecuteReader(CommandType.Text, CMDSELECT + where + ORDER_BY);
        }
        private static OracleDataReader LoadDataReader(int id)
        {
            OracleParameter[] parms = {/*00*/ new OracleParameter("id_grupo_pessoa", OracleDbType.Int32, ParameterDirection.Input) };
            parms[0].Value = id;

            return REFOracleDatabase.ExecuteReader(CommandType.Text, CMDSELECTBYID, parms);
        }
        #endregion
    }
}
