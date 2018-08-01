using System;
using System.Collections.Generic;
using System.Data;
using Oracle.DataAccess.Client;
using REFEstoqueDotNetV3.model.EST;
using REFEstoqueDotNetV3.model.GRL;
using REFEstoqueDotNetV3.DAO.GRL;

namespace REFEstoqueDotNetV3.DAO.EST
{
    public class ItemVendaDAO
    {
        #region  Stored Procedures / Commands
        private const string CMDSELECTBYIDCLI = "Select * from EST_ITEM_VENDA where ID_VENDA =:ID_VENDA";
        private const string CMDINSERT = "insert into est_item_venda (id_item_venda, id_venda, id_produto, qtd_produto, vlr_item) " +
                                         "values (:id_item_venda, :id_venda, :id_produto, :qtd_produto, :vlr_item) " +
                                         "returning id_item_venda into :id_item_venda_out ";
        #endregion

        #region public
        public static List<ItemVendaBean> getRecordsByIdVenda(VendaBean venda)
        {
            List<ItemVendaBean> list = null;
            using (OracleConnection conn = new OracleConnection(REFOracleDatabase.CONN_STRING))
            {
                conn.Open();
                using (OracleTransaction trans = conn.BeginTransaction())
                {
                    list = getRecordsByIdVenda(venda, trans);
                }
            }

            return list;
        }
        public static List<ItemVendaBean> getRecordsByIdVenda(VendaBean venda, OracleTransaction trans)
        {
            List<ItemVendaBean> list = null;
            OracleDataReader dr = LoadDataReader(venda, trans);

            try
            {
                list = SetInstance(dr, venda, trans);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return list;
        }

        public static int insert(ItemVendaBean bean)
        {
            int qtdInsert = 0;
            using (OracleConnection conn = new OracleConnection(REFOracleDatabase.CONN_STRING))
            {
                conn.Open();
                using (OracleTransaction trans = conn.BeginTransaction())
                {
                    qtdInsert = insert(bean, trans);
                    trans.Commit();
                }

            }
            return qtdInsert;
        }
        public static int insert(ItemVendaBean bean, OracleTransaction trans)
        {
            OracleParameter[] parms = getParameters(true);
            SetParameters(parms, bean);

            int qtdInsert = 0;
            try
            {
                OracleCommand cmd = REFOracleDatabase.ExecuteNonQueryCmd(trans, CommandType.Text, CMDINSERT, out qtdInsert, parms);
                bean.idItemVenda = Convert.ToInt32(cmd.Parameters["id_item_venda_out"].Value.ToString());
                cmd.Parameters.Clear();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw (ex);
            }
            return qtdInsert;
        }
        #endregion

        #region private
        private static List<ItemVendaBean> SetInstance(OracleDataReader dr, VendaBean venda, OracleTransaction trans)
        {
            List<ItemVendaBean> list = new List<ItemVendaBean>();
            try
            {
                while (dr.Read())
                {
                    ItemVendaBean obj = new ItemVendaBean();

                    obj.idItemVenda = Convert.ToInt32(dr["id_item_venda"].ToString());
                    obj.qtdProduto = Convert.ToDouble(dr["qtd_produto"].ToString());
                    //obj.vlrUnitario = Convert.ToDouble(dr["vlr_unitario"].ToString());

                    obj.venda = venda;
                    obj.produto = ProdutoDAO.getRecord(Convert.ToInt32(dr["id_produto"].ToString()), trans);

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
        private static OracleDataReader LoadDataReader(VendaBean venda, OracleTransaction trans)
        {
            OracleParameter[] parms = {/*00*/ new OracleParameter("ID_VENDA", OracleDbType.Int32, ParameterDirection.Input) };
            parms[0].Value = venda.idVenda;

            return REFOracleDatabase.ExecuteReader(trans, CommandType.Text, CMDSELECTBYIDCLI, parms);
        }
        private static OracleParameter[] getParameters(bool isReturnValue)
        {
            OracleParameter[] parms;
            if (isReturnValue)
            {
                parms = new OracleParameter[]{
                /*00*/ new OracleParameter("ID_ITEM_VENDA", OracleDbType.Int32,ParameterDirection.Input),
                /*01*/ new OracleParameter("ID_VENDA", OracleDbType.Int32,ParameterDirection.Input),
                /*02*/ new OracleParameter("ID_PRODUTO", OracleDbType.Int32,ParameterDirection.Input),
                /*03*/ new OracleParameter("QTD_PRODUTO", OracleDbType.Decimal,ParameterDirection.Input),
                /*04*/ new OracleParameter("VLR_ITEM", OracleDbType.Decimal,ParameterDirection.Input),
                /*11*/ new OracleParameter("ID_ITEM_VENDA_OUT", OracleDbType.Int32,ParameterDirection.ReturnValue)
            };
            }
            else
            {
                parms = new OracleParameter[]{
                /*00*/ new OracleParameter("ID_ITEM_VENDA", OracleDbType.Int32,ParameterDirection.Input),
                /*01*/ new OracleParameter("ID_VENDA", OracleDbType.Int32,ParameterDirection.Input),
                /*02*/ new OracleParameter("ID_PRODUTO", OracleDbType.Int32,ParameterDirection.Input),
                /*03*/ new OracleParameter("QTD_PRODUTO", OracleDbType.Decimal,ParameterDirection.Input),
                /*04*/ new OracleParameter("VLR_ITEM", OracleDbType.Decimal,ParameterDirection.Input)
            };
            }
            return parms;
        }
        private static void SetParameters(OracleParameter[] parms, ItemVendaBean bean)
        {
            parms[0].Value = bean.idItemVenda;
            parms[1].Value = bean.venda.idVenda;
            parms[2].Value = bean.produto.idProduto;
            parms[3].Value = bean.qtdProduto;
            parms[4].Value = bean.vlrItem;
        }
        #endregion
    }
}
