using System;
using System.Collections.Generic;
using System.Data;
using Oracle.DataAccess.Client;
using REFEstoqueDotNetV3.model.EST;
using REFEstoqueDotNetV3.model.GRL;
using REFEstoqueDotNetV3.DAO.GRL;

namespace REFEstoqueDotNetV3.DAO.EST
{
    public class SaldoProdutoDAO
    {
        #region  Stored Procedures / Commands
        private const string CMDSELECTBYIDPRO = "Select * from est_saldo_produto where ID_PRODUTO =:ID_PRODUTO ";
        #endregion

        #region public
        public static List<SaldoProdutoBean> getRecordsByProduto(ProdutoBean produto, OracleTransaction trans)
        {
            List<SaldoProdutoBean> list = null;
            OracleDataReader dr = LoadDataReader(produto.idProduto, trans);

            try
            {
                list = SetInstance(dr, produto, trans);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return list;
        }
        #endregion

        #region private
        private static List<SaldoProdutoBean> SetInstance(OracleDataReader dr, ProdutoBean produto, OracleTransaction trans)
        {
            List<SaldoProdutoBean> list = new List<SaldoProdutoBean>();
            try
            {
                while (dr.Read())
                {
                    SaldoProdutoBean obj = new SaldoProdutoBean();
                    obj.idSaldoProduto = Convert.ToInt32(dr["id_saldo_produto"].ToString());
                    obj.saldo = Convert.ToDouble(dr["saldo"].ToString());

                    obj.produto = produto;

                    obj.almoxarifado = AlmoxarifadoDAO.getRecord(Convert.ToInt32(dr["id_almoxarifado"]), trans);

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
        private static OracleDataReader LoadDataReader(int id, OracleTransaction trans)
        {
            OracleParameter[] parms = {/*00*/ new OracleParameter("id_produto", OracleDbType.Int32, ParameterDirection.Input) };
            parms[0].Value = id;

            return REFOracleDatabase.ExecuteReader(trans, CommandType.Text, CMDSELECTBYIDPRO, parms);
        }
        #endregion
    }
}
