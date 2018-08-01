create or replace
PACKAGE PCK_DIC_DADOS AS 
  
  CONST_TXT_SEM_VALOR Constant varchar2(10) :='SEM VALOR';

  procedure prc_atualizar_dados;
  
  procedure prc_atualizar_dados(pNomeTabela in varchar2);
  
  function fnc_getFiltroLabel (pIdDicTabela dic_tabela.id_tabela%type) return varchar2;
  
  function fnc_getFiltro (pIdDicTabela dic_tabela.id_tabela%type) return varchar2;
END PCK_DIC_DADOS;