using System;
using System.Collections.Generic;
using System.Data;
using Oracle.DataAccess.Client;
using REFEstoqueDotNetV3.model.EST;

namespace REFEstoqueDotNetV3.DAO.EST
{
    public class AlmoxarifadoDAO
    {
        #region  Stored Procedures / Commands
        private const string ORDER_BY = " order by descr";
        private const string CMDSELECT = "Select * from EST_ALMOXARIFADO ";
        private const string CMDSELECTBYID = "Select * from EST_ALMOXARIFADO where id_almoxarifado =:id_almoxarifado ";
        private const string CMDINSERT = "insert into EST_ALMOXARIFADO (id_almoxarifado, descr) " +
                                         "values (:id_almoxarifado_in, :descr) returning id_almoxarifado into :id_almoxarifado_out ";
        private const string CMDUPDATE = "update EST_ALMOXARIFADO  " +
                                         "set descr = :descr " +
                                         "where id_almoxarifado =:id_almoxarifado_in ";
        private const string CMDDELETE = "delete from  EST_ALMOXARIFADO  " +
                                         "where id_almoxarifado =:id_almoxarifado ";
        #endregion

        #region public

        public static List<AlmoxarifadoBean> getRecords(AlmoxarifadoBean filter)
        {
            OracleDataReader dr = LoadDataReader(filter);
            List<AlmoxarifadoBean> list = null;
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

        public static AlmoxarifadoBean getRecord(int id, OracleTransaction trans)
        {
            AlmoxarifadoBean bean = new AlmoxarifadoBean();
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

        public static int insert(AlmoxarifadoBean bean)
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
                        bean.idAlmoxarifado = Convert.ToInt32(cmd.Parameters["id_almoxarifado_out"].Value.ToString());
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

        public static int update(AlmoxarifadoBean bean)
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

        public static int delete(int id)
        {
            int qtdDelete = 0;

            using (OracleConnection conn = new OracleConnection(REFOracleDatabase.CONN_STRING))
            {
                OracleParameter[] parms = {/*00*/ new OracleParameter("id_almoxarifado", OracleDbType.Int32, ParameterDirection.Input) };
                parms[0].Value = id;

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
        private static void SetParameters(OracleParameter[] parms, AlmoxarifadoBean bean)
        {
            parms[0].Value = bean.descr;
            parms[1].Value = bean.idAlmoxarifado;
        }
        private static OracleParameter[] GetParameters(bool isReturnValue)
        {
            OracleParameter[] parms;
            if (isReturnValue)
            {
                parms = new OracleParameter[]{
                /*00*/ new OracleParameter("descr", OracleDbType.Varchar2,ParameterDirection.Input),
                /*01*/ new OracleParameter("id_almoxarifado_in", OracleDbType.Int32,ParameterDirection.Input),
                /*02*/ new OracleParameter("id_almoxarifado_out", OracleDbType.Int32,ParameterDirection.ReturnValue)
            };
            }
            else
            {
                parms = new OracleParameter[]{
                /*00*/ new OracleParameter("descr", OracleDbType.Varchar2,ParameterDirection.Input),
                /*01*/ new OracleParameter("id_almoxarifado_in", OracleDbType.Int32,ParameterDirection.Input)
            };
            }
            return parms;
        }
        private static List<AlmoxarifadoBean> SetInstance(OracleDataReader dr)
        {
            List<AlmoxarifadoBean> list = new List<AlmoxarifadoBean>();
            try
            {
                while (dr.Read())
                {
                    AlmoxarifadoBean obj = new AlmoxarifadoBean();
                    obj.idAlmoxarifado = Convert.ToInt32(dr["id_almoxarifado"].ToString());
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
        private static bool SetInstance(OracleDataReader dr, AlmoxarifadoBean obj)
        {
            try
            {
                if (dr.Read())
                {
                    obj.idAlmoxarifado = Convert.ToInt32(dr["id_almoxarifado"].ToString());
                    obj.descr = dr["descr"].ToString();
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
        private static OracleDataReader LoadDataReader(AlmoxarifadoBean filtro)
        {
            String where = null;

            //montar o comando 
            if (filtro.idAlmoxarifado > 0)
            {
                where = REFOracleDatabase.addAndWhere(where, " id_almoxarifado = " + filtro.idAlmoxarifado);
            }
            if (filtro.descr != null && filtro.descr.Trim() != "")
            {
                where = REFOracleDatabase.addAndWhere(where, " upper(descr) like '" + filtro.descr.Trim().ToUpper().Replace("'", "''") + "'");
            }
            //
            return REFOracleDatabase.ExecuteReader(CommandType.Text, CMDSELECT + where + ORDER_BY);
        }
        private static OracleDataReader LoadDataReader(int id, OracleTransaction trans)
        {
            OracleParameter[] parms = {/*00*/ new OracleParameter("id_almoxarifado", OracleDbType.Int32, ParameterDirection.Input) };
            parms[0].Value = id;

            return REFOracleDatabase.ExecuteReader(trans,CommandType.Text, CMDSELECTBYID, parms);
        }
        #endregion

    }
}
