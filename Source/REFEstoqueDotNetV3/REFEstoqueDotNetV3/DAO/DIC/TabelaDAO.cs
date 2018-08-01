using System;
using System.Collections.Generic;
using System.Data;
using Oracle.DataAccess.Client;

using REFEstoqueDotNetV3.model.DIC;

namespace REFEstoqueDotNetV3.DAO.DIC
{
    public class TabelaDAO
    {
        #region  Stored Procedures / Commands
        private const string CMDSELECT_BY_NOME = "select * from dic_tabela where nome_tabela = :nome_tabela ";
        #endregion

        #region Public
        public static TabelaBean getByNome(String nome)
        {
            OracleDataReader dr = LoadDataReader(nome);
            TabelaBean tab = new TabelaBean();

            try
            {
                SetInstance(dr, tab);
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return tab;
        }
        
        #endregion

        #region Private
        private static bool SetInstance(OracleDataReader dr, TabelaBean tab)
        {
            try
            {
                if (dr.Read())
                {
                    tab.idTabela = Convert.ToInt32(dr["ID_TABELA"].ToString());
                    tab.nomeTabela = dr["NOME_TABELA"].ToString();
                    tab.labelForm = dr["LABEL_FORM"].ToString();
                    tab.alturaForm = Convert.ToInt32(dr["ALTURA_FORM"].ToString());
                    tab.comprimentoForm = Convert.ToInt32(dr["COMPRIMENTO_FORM"].ToString());
                    //obter colunas da tabela
                    tab.colunas = ColunaDAO.LoadObjects(tab);
                    return true;
                }
                else
                {
                    return false;
                }
            }

            catch (Exception ex)
            {
                tab = new TabelaBean();
                throw (ex);
            }
            finally
            {
                if (!dr.IsClosed)
                    dr.Close();
            }
        }
        private static OracleDataReader LoadDataReader(String nome)
        {
            OracleParameter[] parms = new OracleParameter[] { 
                new OracleParameter("nome_tabela", OracleDbType.Varchar2, ParameterDirection.Input)
            };
            parms[0].Value = nome;

            return REFOracleDatabase.ExecuteReader(CommandType.Text, CMDSELECT_BY_NOME, parms);
        }
        #endregion
    }
}
