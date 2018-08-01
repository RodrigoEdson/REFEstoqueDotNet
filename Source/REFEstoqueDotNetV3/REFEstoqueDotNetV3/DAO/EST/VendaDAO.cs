using System;
using System.Collections.Generic;
using System.Data;
using Oracle.DataAccess.Client;
using REFEstoqueDotNetV3.model.EST;
using REFEstoqueDotNetV3.model.GRL;
using REFEstoqueDotNetV3.DAO.GRL;

namespace REFEstoqueDotNetV3.DAO.EST
{
    public class VendaDAO
    {
        #region  Stored Procedures / Commands
        private const string CMDSELECTBYIDCLI = "Select ID_VENDA ," +
                                                        " ID_CLIENTE ," +
                                                        " DT_VENDA ," +
                                                        " DT_ULT_ALTERACAO ," +
                                                        " DT_EMISSAO ," +
                                                        " NOTA_VENDA ," +
                                                        " VLR_DESCONTO ," +
                                                        " VLR_PRODUTOS ," +
                                                        " VLR_TOTAL ," +
                                                        " TIPO_VENDA ," +
                                                        " QTD_PARCELAS ," +
                                                        " OBS, "+
                                                        "STATUS, "+
                                                        "DT_VENC_PARCELA1  from EST_VENDA where ID_CLIENTE =:ID_CLIENTE ";
        private const string CMDINSERT = "insert into EST_VENDA (ID_VENDA ,ID_CLIENTE,DT_VENDA ,DT_ULT_ALTERACAO , DT_EMISSAO , NOTA_VENDA , VLR_DESCONTO , VLR_PRODUTOS , VLR_TOTAL , TIPO_VENDA , QTD_PARCELAS , OBS, STATUS, DT_VENC_PARCELA1) " +
                                         "values (:ID_VENDA_IN,:ID_CLIENTE,:DT_VENDA ,:DT_ULT_ALTERACAO , :DT_EMISSAO , :NOTA_VENDA , :VLR_DESCONTO , :VLR_PRODUTOS , :VLR_TOTAL , :TIPO_VENDA , :QTD_PARCELAS , :OBS, :STATUS, :DT_VENC_PARCELA1) returning id_venda into :ID_VENDA_OUT ";
        #endregion

        #region public
        public static List<VendaBean> getRecordsByCliente(PessoaBean cliente)
        {
            List<VendaBean> list = null;
            using (OracleConnection conn = new OracleConnection(REFOracleDatabase.CONN_STRING))
            {
                conn.Open();
                using (OracleTransaction trans = conn.BeginTransaction())
                {
                    list = getRecordsByCliente(cliente, trans);
                }
            }

            return list;
        }
        public static List<VendaBean> getRecordsByCliente(PessoaBean cliente, OracleTransaction trans)
        {
            List<VendaBean> list = null;
            OracleDataReader dr = LoadDataReader(cliente.idPessoa, trans);

            try
            {
                list = SetInstance(dr, cliente, trans);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return list;
        }

        public static int insert(VendaBean bean)
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
                        //inseir a venda
                        OracleCommand cmd = REFOracleDatabase.ExecuteNonQueryCmd(trans, CommandType.Text, CMDINSERT, out qtdInsert, parms);
                        bean.idVenda = Convert.ToInt32(cmd.Parameters["id_venda_out"].Value.ToString());
                        //inserir os itens
                        foreach (ItemVendaBean item in bean.itens)
                        {
                            if (item.qtdProduto > 0)
                                ItemVendaDAO.insert(item, trans);
                        }

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
        #endregion

        #region private
        private static void SetParameters(OracleParameter[] parms, VendaBean bean)
        {
            parms[0].Value = bean.idVenda;
            parms[1].Value = bean.cliente.idPessoa;
            parms[2].Value = bean.dtVenda;
            parms[3].Value = bean.dtUltAlteracao;
            parms[4].Value = bean.dtEmissao;
            parms[5].Value = bean.notaVenda;
            parms[6].Value = bean.vlrDesconto;
            parms[7].Value = bean.vlrProdutos;
            parms[8].Value = bean.vlrTotal;
            parms[9].Value = bean.qtdParcelas;
            parms[10].Value = bean.tipoVenda;
            parms[11].Value = bean.obs;
            parms[12].Value = bean.status;
            parms[13].Value = bean.dtVencParcela1;
        }
        private static OracleParameter[] GetParameters(bool isReturnValue)
        {
            OracleParameter[] parms;
            if (isReturnValue)
            {
                parms = new OracleParameter[]{
                /*00*/ new OracleParameter("ID_VENDA_IN", OracleDbType.Int32,ParameterDirection.Input),
                /*01*/ new OracleParameter("ID_CLIENTE", OracleDbType.Int32,ParameterDirection.Input),
                /*02*/ new OracleParameter("DT_VENDA", OracleDbType.Date,ParameterDirection.Input),
                /*03*/ new OracleParameter("DT_ULT_ALTERACAO", OracleDbType.Date,ParameterDirection.Input),
                /*04*/ new OracleParameter("DT_EMISSAO", OracleDbType.Date,ParameterDirection.Input),
                /*05*/ new OracleParameter("NOTA_VENDA", OracleDbType.Varchar2,ParameterDirection.Input),
                /*06*/ new OracleParameter("VLR_DESCONTO", OracleDbType.Decimal,ParameterDirection.Input),
                /*07*/ new OracleParameter("VLR_PRODUTOS", OracleDbType.Decimal,ParameterDirection.Input),
                /*08*/ new OracleParameter("VLR_TOTAL", OracleDbType.Decimal,ParameterDirection.Input),
                /*09*/ new OracleParameter("QTD_PARCELAS", OracleDbType.Int32,ParameterDirection.Input),
                /*10*/ new OracleParameter("TIPO_VENDA", OracleDbType.Varchar2,ParameterDirection.Input),
                /*11*/ new OracleParameter("OBS", OracleDbType.Varchar2,ParameterDirection.Input),
                /*12*/ new OracleParameter("STATUS", OracleDbType.Varchar2,ParameterDirection.Input),
                /*13*/ new OracleParameter("DT_VENC_PARCELA1", OracleDbType.Date,ParameterDirection.Input),
                /*14*/ new OracleParameter("ID_VENDA_OUT", OracleDbType.Int32,ParameterDirection.ReturnValue)
            };
            }
            else
            {
                parms = new OracleParameter[]{
                /*00*/ new OracleParameter("ID_VENDA_IN", OracleDbType.Int32,ParameterDirection.Input),
                /*01*/ new OracleParameter("ID_CLIENTE", OracleDbType.Int32,ParameterDirection.Input),
                /*02*/ new OracleParameter("DT_VENDA", OracleDbType.Date,ParameterDirection.Input),
                /*03*/ new OracleParameter("DT_ULT_ALTERACAO", OracleDbType.Date,ParameterDirection.Input),
                /*04*/ new OracleParameter("DT_EMISSAO", OracleDbType.Date,ParameterDirection.Input),
                /*05*/ new OracleParameter("NOTA_VENDA", OracleDbType.Varchar2,ParameterDirection.Input),
                /*06*/ new OracleParameter("VLR_DESCONTO", OracleDbType.Decimal,ParameterDirection.Input),
                /*07*/ new OracleParameter("VLR_PRODUTOS", OracleDbType.Decimal,ParameterDirection.Input),
                /*08*/ new OracleParameter("VLR_TOTAL", OracleDbType.Decimal,ParameterDirection.Input),
                /*09*/ new OracleParameter("QTD_PARCELAS", OracleDbType.Int32,ParameterDirection.Input),
                /*10*/ new OracleParameter("TIPO_VENDA", OracleDbType.Varchar2,ParameterDirection.Input),
                /*11*/ new OracleParameter("OBS", OracleDbType.Varchar2,ParameterDirection.Input),
                /*12*/ new OracleParameter("STATUS", OracleDbType.Varchar2,ParameterDirection.Input),
                /*13*/ new OracleParameter("DT_VENC_PARCELA1", OracleDbType.Date,ParameterDirection.Input)
            };
            }
            return parms;
        }

        private static List<VendaBean> SetInstance(OracleDataReader dr, PessoaBean cliente, OracleTransaction trans)
        {
            List<VendaBean> list = new List<VendaBean>();
            try
            {
                while (dr.Read())
                {
                    VendaBean obj = new VendaBean();

                    obj.idVenda = Convert.ToInt32(dr["id_venda"].ToString());
                    obj.dtVenda = dr.GetDateTime(2);
                    obj.dtUltAlteracao = dr.GetDateTime(3);
                    obj.dtEmissao = dr.GetDateTime(4);
                    obj.notaVenda = dr["NOTA_VENDA"].ToString();
                    obj.vlrDesconto = Convert.ToDouble(dr["VLR_DESCONTO"].ToString());
                    obj.tipoVenda = dr["TIPO_VENDA"].ToString();
                    obj.qtdParcelas = Convert.ToInt32(dr["QTD_PARCELAS"].ToString());
                    obj.obs = dr["OBS"].ToString();
                    obj.status = dr["STATUS"].ToString();
                    if (dr[13] != DBNull.Value)
                        obj.dtVencParcela1 = dr.GetDateTime(13);
                    else
                        obj.dtVencParcela1 = null;
                    obj.cliente = cliente;
                    obj.itens = ItemVendaDAO.getRecordsByIdVenda(obj, trans);



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
            OracleParameter[] parms = {/*00*/ new OracleParameter("ID_CLIENTE", OracleDbType.Int32, ParameterDirection.Input) };
            parms[0].Value = id;

            return REFOracleDatabase.ExecuteReader(trans, CommandType.Text, CMDSELECTBYIDCLI, parms);
        }
        #endregion
    }
}
