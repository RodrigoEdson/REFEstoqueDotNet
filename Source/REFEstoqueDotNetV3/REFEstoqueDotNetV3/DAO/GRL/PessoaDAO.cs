using System;
using System.Collections.Generic;
using System.Data;
using Oracle.DataAccess.Client;
using REFEstoqueDotNetV3.model.GRL;


namespace REFEstoqueDotNetV3.DAO.GRL
{
    public static class PessoaDAO
    {
        #region  Stored Procedures / Commands
        private const string ORDER_BY = " order by nome ";
        private const string CMDSELECT = "Select * from GRL_PESSOA ";
        private const string CMDSELECTBYID = "Select * from GRL_PESSOA where id_pessoa = :id_pessoa";
        private const string CMDINSERT = "INSERT INTO GRL_PESSOA " +
                                         "     ( ID_PESSOA, " +
                                         "       ID_GRUPO_PESSOA, " +
                                         "       NOME, " +
                                         "       APELIDO, " +
                                         "       NUM_DOC, " +
                                         "       TIPO_DOC, " +
                                         "       TEL1, " +
                                         "       TEL2, " +
                                         "       TEL3, " +
                                         "       LOGRADOURO, " +
                                         "       NUMERO, " +
                                         "       COMPLEMENTO, " +
                                         "       BAIRRO, " +
                                         "       CEP, " +
                                         "       PONTO_REF, " +
                                         "       OBS " +
                                         "     )  " +
                                         "     VALUES " +
                                         "     ( :ID_PESSOA, " +
                                         "       :ID_GRUPO_PESSOA, " +
                                         "       :NOME, " +
                                         "       :APELIDO, " +
                                         "       :NUM_DOC, " +
                                         "       :TIPO_DOC, " +
                                         "       :TEL1, " +
                                         "       :TEL2, " +
                                         "       :TEL3, " +
                                         "       :LOGRADOURO, " +
                                         "       :NUMERO, " +
                                         "       :COMPLEMENTO, " +
                                         "       :BAIRRO, " +
                                         "       :CEP, " +
                                         "       :PONTO_REF, " +
                                         "       :OBS ) returning ID_PESSOA into :ID_PESSOA_OUT ";
        private const string CMDUPDATE = "UPDATE grl_pessoa " +
                                         "   SET ID_GRUPO_PESSOA = :ID_GRUPO_PESSOA, " +
                                         "       NOME              = :NOME, " +
                                         "       APELIDO           = :APELIDO, " +
                                         "       NUM_DOC           = :NUM_DOC, " +
                                         "       TIPO_DOC          = :TIPO_DOC, " +
                                         "       TEL1              = :TEL1, " +
                                         "       TEL2              = :TEL2, " +
                                         "       TEL3              = :TEL3, " +
                                         "       LOGRADOURO        = :LOGRADOURO, " +
                                         "       NUMERO            = :NUMERO, " +
                                         "       COMPLEMENTO       = :COMPLEMENTO, " +
                                         "       BAIRRO            = :BAIRRO, " +
                                         "       CEP               = :CEP, " +
                                         "       PONTO_REF         = :PONTO_REF, " +
                                         "       OBS               = :OBS " +
                                         "   WHERE ID_PESSOA     = :ID_PESSOA ";
        private const string CMDDELETE = "delete from GRL_PESSOA where ID_PESSOA = :ID_PESSOA ";
        #endregion

        #region public
        public static List<PessoaBean> getRecords(PessoaBean filter)
        {
            OracleDataReader dr = LoadDataReader(filter);
            List<PessoaBean> list = null;
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
        public static PessoaBean getRecord(int id)
        {
            PessoaBean bean = new PessoaBean();
            OracleDataReader dr = LoadDataReader(id);
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

        public static int insert(PessoaBean bean)
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
                        bean.idPessoa = Convert.ToInt32(cmd.Parameters["ID_PESSOA_OUT"].Value.ToString());
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
        public static int delete(int idPessoa)
        {
            int qtdDelete = 0;

            using (OracleConnection conn = new OracleConnection(REFOracleDatabase.CONN_STRING))
            {
                OracleParameter[] parms = {/*00*/ new OracleParameter("id_pessoa", OracleDbType.Int32, ParameterDirection.Input) };
                parms[0].Value = idPessoa;

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
        public static int update(PessoaBean bean)
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

        #region Private
        private static OracleParameter[] GetParameters(bool isReturnValue)
        {
            OracleParameter[] parms;
            if (isReturnValue)
            {
                parms = new OracleParameter[]{
                /*00*/ new OracleParameter("ID_PESSOA", OracleDbType.Int32,ParameterDirection.Input),
                /*01*/ new OracleParameter("ID_GRUPO_PESSOA", OracleDbType.Int32,ParameterDirection.Input),
                /*02*/ new OracleParameter("NOME", OracleDbType.Varchar2,ParameterDirection.Input),
                /*03*/ new OracleParameter("APELIDO", OracleDbType.Varchar2,ParameterDirection.Input),
                /*04*/ new OracleParameter("NUM_DOC", OracleDbType.Varchar2,ParameterDirection.Input),
                /*05*/ new OracleParameter("TIPO_DOC", OracleDbType.Varchar2,ParameterDirection.Input),
                /*06*/ new OracleParameter("TEL1", OracleDbType.Varchar2,ParameterDirection.Input),
                /*07*/ new OracleParameter("TEL2", OracleDbType.Varchar2,ParameterDirection.Input),
                /*08*/ new OracleParameter("TEL3", OracleDbType.Varchar2,ParameterDirection.Input),
                /*09*/ new OracleParameter("LOGRADOURO", OracleDbType.Varchar2,ParameterDirection.Input),
                /*10*/ new OracleParameter("NUMERO", OracleDbType.Varchar2,ParameterDirection.Input),
                /*11*/ new OracleParameter("COMPLEMENTO", OracleDbType.Varchar2,ParameterDirection.Input),
                /*12*/ new OracleParameter("BAIRRO", OracleDbType.Varchar2,ParameterDirection.Input),
                /*13*/ new OracleParameter("CEP", OracleDbType.Varchar2,ParameterDirection.Input),
                /*14*/ new OracleParameter("PONTO_REF", OracleDbType.Varchar2,ParameterDirection.Input),
                /*15*/ new OracleParameter("OBS", OracleDbType.Varchar2,ParameterDirection.Input),
                /*16*/ new OracleParameter("ID_PESSOA_OUT", OracleDbType.Int32,ParameterDirection.ReturnValue)
            };
            }
            else
            {
                parms = new OracleParameter[]{
                /*00*/ new OracleParameter("ID_PESSOA", OracleDbType.Int32,ParameterDirection.Input),
                /*01*/ new OracleParameter("ID_GRUPO_PESSOA", OracleDbType.Int32,ParameterDirection.Input),
                /*02*/ new OracleParameter("NOME", OracleDbType.Varchar2,ParameterDirection.Input),
                /*03*/ new OracleParameter("APELIDO", OracleDbType.Varchar2,ParameterDirection.Input),
                /*04*/ new OracleParameter("NUM_DOC", OracleDbType.Varchar2,ParameterDirection.Input),
                /*05*/ new OracleParameter("TIPO_DOC", OracleDbType.Varchar2,ParameterDirection.Input),
                /*06*/ new OracleParameter("TEL1", OracleDbType.Varchar2,ParameterDirection.Input),
                /*07*/ new OracleParameter("TEL2", OracleDbType.Varchar2,ParameterDirection.Input),
                /*08*/ new OracleParameter("TEL3", OracleDbType.Varchar2,ParameterDirection.Input),
                /*09*/ new OracleParameter("LOGRADOURO", OracleDbType.Varchar2,ParameterDirection.Input),
                /*10*/ new OracleParameter("NUMERO", OracleDbType.Varchar2,ParameterDirection.Input),
                /*11*/ new OracleParameter("COMPLEMENTO", OracleDbType.Varchar2,ParameterDirection.Input),
                /*12*/ new OracleParameter("BAIRRO", OracleDbType.Varchar2,ParameterDirection.Input),
                /*13*/ new OracleParameter("CEP", OracleDbType.Varchar2,ParameterDirection.Input),
                /*14*/ new OracleParameter("PONTO_REF", OracleDbType.Varchar2,ParameterDirection.Input),
                /*15*/ new OracleParameter("OBS", OracleDbType.Varchar2,ParameterDirection.Input),
            };
            }
            return parms;
        }
        private static void SetParameters(OracleParameter[] parms, PessoaBean bean)
        {
            parms[0].Value = bean.idPessoa;
            parms[1].Value = bean.grupoPessoa.idGrupoPessoa;
            parms[2].Value = bean.nome;
            parms[3].Value = bean.apelido;
            parms[4].Value = bean.numDoc;
            parms[5].Value = bean.tipoDoc;
            parms[6].Value = bean.tel1;
            parms[7].Value = bean.tel2;
            parms[8].Value = bean.tel3;
            parms[9].Value = bean.logradouro;
            parms[10].Value = bean.numero;
            parms[11].Value = bean.complemento;
            parms[12].Value = bean.bairro;
            parms[13].Value = bean.cep;
            parms[14].Value = bean.pontoRef;
            parms[15].Value = bean.obs;
        }
        private static List<PessoaBean> SetInstance(OracleDataReader dr)
        {
            List<PessoaBean> list = new List<PessoaBean>();
            try
            {
                while (dr.Read())
                {
                    PessoaBean obj = new PessoaBean();
                    obj.idPessoa = Convert.ToInt32(dr["id_pessoa"].ToString());
                    obj.nome = dr["nome"].ToString();
                    obj.apelido = dr["apelido"].ToString();
                    obj.numDoc = dr["num_Doc"].ToString();
                    obj.tipoDoc = dr["tipo_Doc"].ToString();
                    obj.tel1 = dr["tel1"].ToString();
                    obj.tel2 = dr["tel2"].ToString();
                    obj.tel3 = dr["tel3"].ToString();
                    obj.logradouro = dr["logradouro"].ToString();
                    obj.numero = dr["numero"].ToString();
                    obj.complemento = dr["complemento"].ToString();
                    obj.bairro = dr["bairro"].ToString();
                    obj.cep = dr["cep"].ToString();
                    obj.pontoRef = dr["ponto_ref"].ToString();
                    obj.obs = dr["obs"].ToString();

                    obj.grupoPessoa = GrupoPessoaDAO.getRecord(Convert.ToInt32(dr["id_grupo_pessoa"]));

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
        private static bool SetInstance(OracleDataReader dr, PessoaBean bean)
        {
            try
            {
                if (dr.Read())
                {
                    bean.idPessoa = Convert.ToInt32(dr["id_pessoa"].ToString());
                    bean.nome = dr["nome"].ToString();
                    bean.apelido = dr["apelido"].ToString();
                    bean.numDoc = dr["num_Doc"].ToString();
                    bean.tipoDoc = dr["tipo_Doc"].ToString();
                    bean.tel1 = dr["tel1"].ToString();
                    bean.tel2 = dr["tel2"].ToString();
                    bean.tel3 = dr["tel3"].ToString();
                    bean.logradouro = dr["logradouro"].ToString();
                    bean.numero = dr["numero"].ToString();
                    bean.complemento = dr["complemento"].ToString();
                    bean.bairro = dr["bairro"].ToString();
                    bean.cep = dr["cep"].ToString();
                    bean.pontoRef = dr["ponto_ref"].ToString();
                    bean.obs = dr["obs"].ToString();

                    bean.grupoPessoa = GrupoPessoaDAO.getRecord(Convert.ToInt32(dr["id_grupo_pessoa"]));
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
        private static OracleDataReader LoadDataReader(PessoaBean filtro)
        {
            String where = null;

            //montar o comando 
            if (filtro.idPessoa > 0)
            {
                where = REFOracleDatabase.addAndWhere(where, " id_pessoa = " + filtro.idPessoa);
            }
            if (filtro.nome != null && filtro.nome.Trim() != "")
            {
                where = REFOracleDatabase.addAndWhere(where, " upper(nome) like '" + filtro.nome.Trim().ToUpper().Replace("'", "''") + "'");
            }
            if (filtro.apelido != null && filtro.apelido.Trim() != "")
            {
                where = REFOracleDatabase.addAndWhere(where, " upper(apelido) like '" + filtro.apelido.Trim().ToUpper().Replace("'", "''") + "'");
            }
            if (filtro.logradouro != null && filtro.logradouro.Trim() != "")
            {
                where = REFOracleDatabase.addAndWhere(where, " upper(logradouro) like '" + filtro.logradouro.Trim().ToUpper().Replace("'", "''") + "'");
            }
            if (filtro.numDoc != null && filtro.numDoc.Trim() != "")
            {
                where = REFOracleDatabase.addAndWhere(where, " upper(num_Doc) like '" + filtro.numDoc.Trim().ToUpper().Replace("'", "''") + "'");
            }
            if (filtro.grupoPessoa != null && filtro.grupoPessoa.descr != null && filtro.grupoPessoa.descr.Trim() != "")
            {
                where = REFOracleDatabase.addAndWhere(where, " id_grupo_pessoa in (" +
                                                             " select id_grupo_pessoa from GRL_GRUPO_PESSOA where upper(descr) like '" +
                                                              filtro.grupoPessoa.descr.Trim().ToUpper().Replace("'", "''") + "')");
            }
            //
            return REFOracleDatabase.ExecuteReader(CommandType.Text, CMDSELECT + where + ORDER_BY);
        }
        private static OracleDataReader LoadDataReader(int id)
        {
            OracleParameter[] parms = {/*00*/ new OracleParameter("id_pessoa", OracleDbType.Int32, ParameterDirection.Input) };
            parms[0].Value = id;

            return REFOracleDatabase.ExecuteReader(CommandType.Text, CMDSELECTBYID, parms);
        }
        #endregion
    }
}
