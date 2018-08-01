using System;
using System.Collections.Generic;
using System.Data;
using Oracle.DataAccess.Client;
using REFEstoqueDotNetV3.model.GRL;

namespace REFEstoqueDotNetV3.DAO.GRL
{
    public static class GrupoProdutoDAO
    {
        #region  Stored Procedures / Commands
        private const string ORDER_BY = " order by descr";
        private const string CMDSELECT = "Select * from GRL_GRUPO_PRODUTO ";
        private const string CMDSELECTBYID = "Select * from GRL_GRUPO_PRODUTO where id_grupo_produto =:id_grupo_produto ";
        private const string CMDINSERT = "insert into GRL_GRUPO_PRODUTO (id_grupo_produto, descr) " +
                                         "values (:id_grupo_produto, :descr) " +
                                         " returning id_grupo_produto into :id_grupo_produto_out ";
        private const string CMDUPDATE = "update GRL_GRUPO_PRODUTO  " +
                                         "set descr = :descr " +
                                         "where id_grupo_produto =:id_grupo_produto ";
        private const string CMDDELETE = "delete from  GRL_GRUPO_PRODUTO  " +
                                         "where id_grupo_produto =:id_grupo_produto ";
        #endregion

        #region public
        public static List<GrupoProdutoBean> getRecords(GrupoProdutoBean filter)
        {
            OracleDataReader dr = LoadDataReader(filter);
            List<GrupoProdutoBean> list = null;
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

        public static GrupoProdutoBean getRecord(int id)
        {
            GrupoProdutoBean bean = new GrupoProdutoBean();
            using (OracleConnection conn = new OracleConnection(REFOracleDatabase.CONN_STRING))
            {
                conn.Open();
                using (OracleTransaction trans = conn.BeginTransaction())
                {
                    bean = getRecord(id, trans);
                }
            }

            return bean;
        }

        public static GrupoProdutoBean getRecord(int id, OracleTransaction trans)
        {
            GrupoProdutoBean bean = new GrupoProdutoBean();
            OracleDataReader dr = LoadDataReader(id, trans);
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

        public static int insert(GrupoProdutoBean bean)
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
                        bean.idGrupoProduto = Convert.ToInt32(cmd.Parameters["id_grupo_produto_out"].Value.ToString());
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

        public static int update(GrupoProdutoBean bean)
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

        public static int delete(int idGrupoProduto)
        {
            int qtdDelete = 0;

            using (OracleConnection conn = new OracleConnection(REFOracleDatabase.CONN_STRING))
            {
                OracleParameter[] parms = {/*00*/ new OracleParameter("id_grupo_produto", OracleDbType.Int32, ParameterDirection.Input) };
                parms[0].Value = idGrupoProduto;

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
        #endregion

        #region private
        private static void SetParameters(OracleParameter[] parms, GrupoProdutoBean bean)
        {
            parms[0].Value = bean.descr;
            parms[1].Value = bean.idGrupoProduto;
        }
        private static OracleParameter[] GetParameters(bool isReturnValue)
        {
            OracleParameter[] parms;
            if (isReturnValue)
            {
                parms = new OracleParameter[]{
                /*00*/ new OracleParameter("descr", OracleDbType.Varchar2,ParameterDirection.Input),
                /*01*/ new OracleParameter("id_grupo_produto", OracleDbType.Int32,ParameterDirection.Input),
                /*02*/ new OracleParameter("id_grupo_produto_out", OracleDbType.Int32,ParameterDirection.ReturnValue)
            };
            }
            else
            {
                parms = new OracleParameter[]{
                /*00*/ new OracleParameter("descr", OracleDbType.Varchar2,ParameterDirection.Input),
                /*01*/ new OracleParameter("id_grupo_produto", OracleDbType.Int32,ParameterDirection.Input)
            };
            }
            return parms;
        }
        private static OracleDataReader LoadDataReader(GrupoProdutoBean filtro)
        {
            String where = null;

            //montar o comando 
            if (filtro.idGrupoProduto > 0)
            {
                where = REFOracleDatabase.addAndWhere(where, " id_grupo_produto = " + filtro.idGrupoProduto);
            }
            if (filtro.descr != null && filtro.descr.Trim() != "")
            {
                where = REFOracleDatabase.addAndWhere(where, " upper(descr) like '" + filtro.descr.Trim().ToUpper().Replace("'", "''") + "'");
            }
            //
            return REFOracleDatabase.ExecuteReader(CommandType.Text, CMDSELECT + where + ORDER_BY);
        }
        private static List<GrupoProdutoBean> SetInstance(OracleDataReader dr)
        {
            List<GrupoProdutoBean> list = new List<GrupoProdutoBean>();
            try
            {
                while (dr.Read())
                {
                    GrupoProdutoBean obj = new GrupoProdutoBean();
                    obj.idGrupoProduto = Convert.ToInt32(dr["id_grupo_produto"].ToString());
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
        private static bool SetInstance(OracleDataReader dr, GrupoProdutoBean bean)
        {
            try
            {
                if (dr.Read())
                {
                    bean.idGrupoProduto = Convert.ToInt32(dr["id_grupo_produto"].ToString());
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
        private static OracleDataReader LoadDataReader(int id, OracleTransaction trans)
        {
            OracleParameter[] parms = {/*00*/ new OracleParameter("id_grupo_produto", OracleDbType.Int32, ParameterDirection.Input) };
            parms[0].Value = id;

            return REFOracleDatabase.ExecuteReader(trans, CommandType.Text, CMDSELECTBYID, parms);
        }
        #endregion
    }
}
