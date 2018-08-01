using System;
using System.Collections.Generic;
using System.Data;
using Oracle.DataAccess.Client;
using REFEstoqueDotNetV3.model.GRL;
using REFEstoqueDotNetV3.model.EST;
using REFEstoqueDotNetV3.DAO.EST;

namespace REFEstoqueDotNetV3.DAO.GRL
{
    public static class ProdutoDAO
    {
        #region  Stored Procedures / Commands
        private const string ORDER_BY = " order by descr";
        private const string CMDSELECT = "Select * from GRL_PRODUTO ";
        private const string CMDSELECTBYID = "Select * from GRL_PRODUTO where ID_PRODUTO = :ID_PRODUTO ";
        private const string CMDSELECTBYCODBAR = "Select * from GRL_PRODUTO where COD_BARRAS = :COD_BARRAS ";
        private const string CMDINSERT = "INSERT INTO GRL_PRODUTO " +
                                         "     ( ID_PRODUTO, " +
                                         "       ID_GRUPO_PRODUTO, " +
                                         "       DESCR, " +
                                         "       UNIDADE, " +
                                         "       QTD_ESTOQUE_MIN, " +
                                         "       QTD_ESTOQUE_IDEAL, " +
                                         "       VLR_UNITARIO, " +
                                         "       VLR_UNITARIO_MEDIO, " +
                                         "       PCT_LUCRO, " +
                                         "       COD_BARRAS, " +
                                         "       OBS )  " +
                                         "     VALUES " +
                                         "     ( :ID_PRODUTO, " +
                                         "       :ID_GRUPO_PRODUTO, " +
                                         "       :DESCR, " +
                                         "       :UNIDADE, " +
                                         "       :QTD_ESTOQUE_MIN, " +
                                         "       :QTD_ESTOQUE_IDEAL, " +
                                         "       :VLR_UNITARIO, " +
                                         "       :VLR_UNITARIO_MEDIO, " +
                                         "       :PCT_LUCRO, " +
                                         "       :COD_BARRAS, " +
                                         "       :OBS ) returning ID_PRODUTO into :ID_PRODUTO_OUT ";
        private const string CMDUPDATE = "UPDATE GRL_PRODUTO " +
                                         "   SET ID_GRUPO_PRODUTO   = :ID_GRUPO_PRODUTO, " +
                                         "       DESCR              = :DESCR, " +
                                         "       UNIDADE            = :UNIDADE, " +
                                         "       QTD_ESTOQUE_MIN    = :QTD_ESTOQUE_MIN, " +
                                         "       QTD_ESTOQUE_IDEAL  = :QTD_ESTOQUE_IDEAL, " +
                                         "       VLR_UNITARIO       = :VLR_UNITARIO, " +
                                         "       VLR_UNITARIO_MEDIO = :VLR_UNITARIO_MEDIO, " +
                                         "       PCT_LUCRO          = :PCT_LUCRO, " +
                                         "       COD_BARRAS         = :COD_BARRAS, " +
                                         "       OBS                = :OBS " +
                                         "   WHERE ID_PRODUTO = :ID_PRODUTO ";
        private const string CMDDELETE = "delete from GRL_PRODUTO where ID_PRODUTO = :ID_PRODUTO ";
        #endregion

        #region public
        public static List<ProdutoBean> getRecords(ProdutoBean filter)
        {
            List<ProdutoBean> list = null;
            using (OracleConnection conn = new OracleConnection(REFOracleDatabase.CONN_STRING))
            {
                conn.Open();
                using (OracleTransaction trans = conn.BeginTransaction())
                {
                    OracleDataReader dr = LoadDataReader(filter, trans);
                    try
                    {
                        list = SetInstance(dr, trans);
                    }
                    catch (Exception ex)
                    {
                        throw (ex);
                    }
                }
            }

            return list;
        }
        
        public static ProdutoBean getRecord(int id)
        {
            ProdutoBean pro = null;
            using (OracleConnection conn = new OracleConnection(REFOracleDatabase.CONN_STRING))
            {
                conn.Open();
                using (OracleTransaction trans = conn.BeginTransaction())
                {
                    pro = getRecord(id, trans);
                }
            }
            return pro;
        }
        public static ProdutoBean getRecord(int id, OracleTransaction trans)
        {
            ProdutoBean pro = new ProdutoBean();

            OracleDataReader dr = LoadDataReader(id, trans);
            try
            {
                SetInstance(dr, pro, trans);
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return pro;
        }

        public static ProdutoBean getRecord(string codBarras)
        {
            ProdutoBean pro = null;
            using (OracleConnection conn = new OracleConnection(REFOracleDatabase.CONN_STRING))
            {
                conn.Open();
                using (OracleTransaction trans = conn.BeginTransaction())
                {
                    pro = getRecord(codBarras, trans);
                }
            }
            return pro;
        }
        public static ProdutoBean getRecord(string codBarras, OracleTransaction trans)
        {
            ProdutoBean pro = new ProdutoBean();

            OracleDataReader dr = LoadDataReader(codBarras, trans);
            try
            {
                SetInstance(dr, pro, trans);
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return pro;
        }

        public static int insert(ProdutoBean bean)
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
                        bean.idProduto = Convert.ToInt32(cmd.Parameters["ID_PRODUTO_OUT"].Value.ToString());
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
        public static int delete(int idProduto)
        {
            int qtdDelete = 0;

            using (OracleConnection conn = new OracleConnection(REFOracleDatabase.CONN_STRING))
            {
                OracleParameter[] parms = {/*00*/ new OracleParameter("ID_PRODUTO", OracleDbType.Int32, ParameterDirection.Input) };
                parms[0].Value = idProduto;

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
        public static int update(ProdutoBean bean)
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
                /*00*/ new OracleParameter("ID_PRODUTO", OracleDbType.Int32,ParameterDirection.Input),
                /*01*/ new OracleParameter("ID_GRUPO_PRODUTO", OracleDbType.Int32,ParameterDirection.Input),
                /*02*/ new OracleParameter("DESCR", OracleDbType.Varchar2,ParameterDirection.Input),
                /*03*/ new OracleParameter("UNIDADE", OracleDbType.Varchar2,ParameterDirection.Input),
                /*04*/ new OracleParameter("QTD_ESTOQUE_MIN", OracleDbType.Decimal,ParameterDirection.Input),
                /*05*/ new OracleParameter("QTD_ESTOQUE_IDEAL", OracleDbType.Decimal,ParameterDirection.Input),
                /*06*/ new OracleParameter("VLR_UNITARIO", OracleDbType.Decimal,ParameterDirection.Input),
                /*07*/ new OracleParameter("VLR_UNITARIO_MEDIO", OracleDbType.Decimal,ParameterDirection.Input),
                /*08*/ new OracleParameter("PCT_LUCRO", OracleDbType.Decimal,ParameterDirection.Input),
                /*09*/ new OracleParameter("COD_BARRAS", OracleDbType.Varchar2,ParameterDirection.Input),
                /*10*/ new OracleParameter("OBS", OracleDbType.Varchar2,ParameterDirection.Input),
                /*11*/ new OracleParameter("ID_PRODUTO_OUT", OracleDbType.Int32,ParameterDirection.ReturnValue)
            };
            }
            else
            {
                parms = new OracleParameter[]{
                /*00*/ new OracleParameter("ID_PRODUTO", OracleDbType.Int32,ParameterDirection.Input),
                /*01*/ new OracleParameter("ID_GRUPO_PRODUTO", OracleDbType.Int32,ParameterDirection.Input),
                /*02*/ new OracleParameter("DESCR", OracleDbType.Varchar2,ParameterDirection.Input),
                /*03*/ new OracleParameter("UNIDADE", OracleDbType.Varchar2,ParameterDirection.Input),
                /*04*/ new OracleParameter("QTD_ESTOQUE_MIN", OracleDbType.Decimal,ParameterDirection.Input),
                /*05*/ new OracleParameter("QTD_ESTOQUE_IDEAL", OracleDbType.Decimal,ParameterDirection.Input),
                /*06*/ new OracleParameter("VLR_UNITARIO", OracleDbType.Decimal,ParameterDirection.Input),
                /*07*/ new OracleParameter("VLR_UNITARIO_MEDIO", OracleDbType.Decimal,ParameterDirection.Input),
                /*08*/ new OracleParameter("PCT_LUCRO", OracleDbType.Decimal,ParameterDirection.Input),
                /*09*/ new OracleParameter("COD_BARRAS", OracleDbType.Varchar2,ParameterDirection.Input),
                /*10*/ new OracleParameter("OBS", OracleDbType.Varchar2,ParameterDirection.Input)
            };
            }
            return parms;
        }
        private static void SetParameters(OracleParameter[] parms, ProdutoBean bean)
        {
            parms[0].Value = bean.idProduto;
            parms[1].Value = bean.grupoProduto.idGrupoProduto;
            parms[2].Value = bean.descr;
            parms[3].Value = bean.unidade;
            parms[4].Value = bean.qtdEstoqueMin;
            parms[5].Value = bean.qtdEstoqueIdeal;
            parms[6].Value = bean.vlrUnitario;
            parms[7].Value = bean.vlrUnitarioMedio;
            parms[8].Value = bean.pctLucro;
            parms[9].Value = bean.codBarras;
            parms[10].Value = bean.obs;
        }
        private static OracleDataReader LoadDataReader(ProdutoBean filtro, OracleTransaction trans)
        {
            String where = null;

            //montar o comando 
            if (filtro.idProduto > 0)
            {
                where = REFOracleDatabase.addAndWhere(where, " id_produto = " + filtro.idProduto);
            }
            if (filtro.descr != null && filtro.descr.Trim() != "")
            {
                where = REFOracleDatabase.addAndWhere(where, " upper(descr) like '" + filtro.descr.Trim().ToUpper().Replace("'", "''") + "'");
            }
            if (filtro.codBarras != null && filtro.codBarras.Trim() != "")
            {
                where = REFOracleDatabase.addAndWhere(where, " upper(cod_barras) like '" + filtro.codBarras.Trim().ToUpper().Replace("'", "''") + "'");
            }
            if (filtro.grupoProduto != null && filtro.grupoProduto.descr != null && filtro.grupoProduto.descr.Trim() != "")
            {
                where = REFOracleDatabase.addAndWhere(where, " id_grupo_produto in (" +
                                                             " select id_grupo_produto from GRL_GRUPO_PRODUTO where upper(descr) like '" +
                                                              filtro.grupoProduto.descr.Trim().ToUpper().Replace("'", "''") + "')");
            }
            //
            return REFOracleDatabase.ExecuteReader(trans, CommandType.Text, CMDSELECT + where + ORDER_BY);
        }
        private static OracleDataReader LoadDataReader(int id, OracleTransaction trans)
        {
            OracleParameter[] parms = {/*00*/ new OracleParameter("ID_PRODUTO", OracleDbType.Int32, ParameterDirection.Input) };
            parms[0].Value = id;

            return REFOracleDatabase.ExecuteReader(trans, CommandType.Text, CMDSELECTBYID, parms);
        }
        private static OracleDataReader LoadDataReader(String codBarras, OracleTransaction trans)
        {
            OracleParameter[] parms = {/*00*/ new OracleParameter("COD_BARRAS", OracleDbType.Varchar2, ParameterDirection.Input) };
            parms[0].Value = codBarras;

            return REFOracleDatabase.ExecuteReader(trans, CommandType.Text, CMDSELECTBYCODBAR, parms);
        }
        private static List<ProdutoBean> SetInstance(OracleDataReader dr, OracleTransaction trans)
        {
            List<ProdutoBean> list = new List<ProdutoBean>();
            try
            {
                while (dr.Read())
                {
                    ProdutoBean obj = new ProdutoBean();
                    obj.idProduto = Convert.ToInt32(dr["id_produto"].ToString());
                    obj.descr = dr["descr"].ToString();
                    obj.unidade = dr["unidade"].ToString();
                    obj.qtdEstoqueMin = Convert.ToDouble(dr["qtd_estoque_min"].ToString());
                    obj.qtdEstoqueIdeal = Convert.ToDouble(dr["qtd_estoque_ideal"].ToString());
                    obj.vlrUnitario = Convert.ToDouble(dr["vlr_unitario"].ToString());
                    obj.vlrUnitarioMedio = Convert.ToDouble(dr["vlr_unitario_medio"].ToString());
                    obj.pctLucro = Convert.ToDouble(dr["pct_lucro"].ToString());
                    obj.codBarras = dr["cod_barras"].ToString();
                    obj.obs = dr["obs"].ToString();

                    obj.grupoProduto = GrupoProdutoDAO.getRecord(Convert.ToInt32(dr["id_grupo_produto"]),trans);

                    List<SaldoProdutoBean> saldoList = SaldoProdutoDAO.getRecordsByProduto(obj, trans);
                    obj.saldos = saldoList;

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
        private static bool SetInstance(OracleDataReader dr, ProdutoBean obj, OracleTransaction trans)
        {
            try
            {
                if (dr.Read())
                {
                    obj.idProduto = Convert.ToInt32(dr["id_produto"].ToString());
                    obj.descr = dr["descr"].ToString();
                    obj.unidade = dr["unidade"].ToString();
                    obj.qtdEstoqueMin = Convert.ToDouble(dr["qtd_estoque_min"].ToString());
                    obj.qtdEstoqueIdeal = Convert.ToDouble(dr["qtd_estoque_ideal"].ToString());
                    obj.vlrUnitario = Convert.ToDouble(dr["vlr_unitario"].ToString());
                    obj.vlrUnitarioMedio = Convert.ToDouble(dr["vlr_unitario_medio"].ToString());
                    obj.pctLucro = Convert.ToDouble(dr["pct_lucro"].ToString());
                    obj.codBarras = dr["cod_barras"].ToString();
                    obj.obs = dr["obs"].ToString();

                    obj.grupoProduto = GrupoProdutoDAO.getRecord(Convert.ToInt32(dr["id_grupo_produto"]),trans);

                    List<SaldoProdutoBean> saldoList = SaldoProdutoDAO.getRecordsByProduto(obj, trans);
                    obj.saldos = saldoList;

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
        
        #endregion
    }
}
