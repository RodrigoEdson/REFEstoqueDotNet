using System;
using System.Collections.Generic;
using System.Data;
using Oracle.DataAccess.Client;
using REFEstoqueDotNetV3.model.DIC;

namespace REFEstoqueDotNetV3.DAO.DIC
{
    public class ColunaDAO
    {
        #region  Stored Procedures / Commands
        private const string CMDSELECT_BY_ID_DIC_TABELA = "select * from dic_coluna where id_tabela = :id_tabela " +
                                                          "order by ordem_exibicao";
        #endregion

        #region Public
        public static List<ColunaBean> LoadObjects(TabelaBean tabela)
        {
            OracleDataReader dr = LoadDataReader(tabela);
            List<ColunaBean> list = new List<ColunaBean>();
            try
            {
                list = SetInstance(dr, tabela);
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return list;
        }
        #endregion

        #region Private
        private static OracleDataReader LoadDataReader(TabelaBean tabela)
        {
            OracleParameter[] parms = new OracleParameter[] { 
                new OracleParameter("id_tabela", OracleDbType.Varchar2, ParameterDirection.Input) 
            };
            parms[0].Value = tabela.idTabela;

            return REFOracleDatabase.ExecuteReader(CommandType.Text, CMDSELECT_BY_ID_DIC_TABELA, parms);
        }
        private static List<ColunaBean> SetInstance(OracleDataReader dr, TabelaBean tabela)
        {
            List<ColunaBean> list = new List<ColunaBean>();
            try
            {
                while (dr.Read())
                {
                    ColunaBean obj = new ColunaBean();
                    obj.idColuna = Convert.ToInt32(dr["id_coluna"]);
                    //obj.tabela = new Tabela();
                    //obj.tabela.idTabela = Convert.ToInt32(dr["id_tabela"]);
                    obj.tabela = tabela;
                    obj.nomeColuna = Convert.ToString(dr["nome_coluna"]);
                    obj.labelColuna = Convert.ToString(dr["label_coluna"]);
                    obj.indObrigatorio = Convert.ToString(dr["ind_obrigatorio"]);
                    obj.indVisivelGrid = Convert.ToString(dr["ind_visivel_grid"]);
                    obj.ordemExibicao = Convert.ToInt32(dr["ordem_exibicao"]);
                    obj.tamanhoColunaGrid = Convert.ToInt32(dr["tamanho_coluna_grid"]);
                    obj.tamanhoItemForm = Convert.ToInt32(dr["tamanho_item_form"]);
                    obj.tipoColuna = Convert.ToString(dr["tipo_coluna"]);
                    if (dr["valor_default"] != DBNull.Value)
                        obj.valorDefault = Convert.ToString(dr["valor_default"]);
                    else
                        obj.valorDefault = null;
                    obj.nomeColunaBean = Convert.ToString(dr["nome_coluna_bean"]);
                    obj.tamanhoColunaBD = Convert.ToInt32(dr["tamanho_coluna_bd"]);
                    if (dr["casas_decimais"] != DBNull.Value)
                        obj.casasDecimais = Convert.ToInt32(dr["casas_decimais"]);
                    else
                        obj.casasDecimais = 0;
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
        #endregion
    }
}
