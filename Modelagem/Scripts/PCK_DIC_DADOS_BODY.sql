create or replace
PACKAGE BODY PCK_DIC_DADOS AS 
  --**************************************************************************************
  function fnc_getFiltroLabel (pIdDicTabela dic_tabela.id_tabela%type) return varchar2 is
    vLabelFiltro dic_tabela_filtro.nome_filtro%type;
    vTamanhoColuna number;
  begin
     
    select nvl(col.data_precision,col.data_length)
    into vTamanhoColuna
    from user_tab_columns col
    where column_name = 'NOME_FILTRO'
    and table_name = 'DIC_TABELA_FILTRO';
    
  
    for cLabelColuna in (
        SELECT decode(label_coluna,'SEM VALOR',nome_coluna,label_coluna)label_coluna
        FROM user_constraints cons,
          user_cons_columns col_cons,
          dic_tabela tab,
          dic_coluna col
        WHERE tab.id_tabela      = pIdDicTabela
        AND col.id_tabela        = tab.id_tabela
        AND cons.table_name          = tab.nome_tabela
        AND cons.constraint_type     = 'P'
        AND col_cons.constraint_name = cons.constraint_name
        AND col.nome_coluna          = col_cons.column_name
        order by ORDEM_EXIBICAO) 
    loop
      if (length(vLabelFiltro||', '||cLabelColuna.label_coluna) <= vTamanhoColuna) then
        if vLabelFiltro is null then
          vLabelFiltro := cLabelColuna.label_coluna;
        else
          vLabelFiltro := vLabelFiltro||', '||cLabelColuna.label_coluna;
        end if;
      else
        return vLabelFiltro;
      end if;
    end loop;
    return vLabelFiltro;
  end;
  
  --**************************************************************************************
  function fnc_getFiltro (pIdDicTabela dic_tabela.id_tabela%type) return varchar2 is
    vFiltro dic_tabela_filtro.nome_filtro%type;
    vTamanhoColuna number;
  begin
    
    select nvl(col.data_precision,col.data_length)
    into vTamanhoColuna
    from user_tab_columns col
    where column_name = 'FILTRO'
    and table_name = 'DIC_TABELA_FILTRO';
    
  
    for cLabelColuna in (
        SELECT nome_coluna || ' = :' || nome_coluna filtro
        FROM user_constraints cons,
          user_cons_columns col_cons,
          dic_tabela tab,
          dic_coluna col
        WHERE tab.id_tabela          = pIdDicTabela
        AND col.id_tabela            = tab.id_tabela
        AND cons.table_name          = tab.nome_tabela
        AND cons.constraint_type     = 'P'
        AND col_cons.constraint_name = cons.constraint_name
        AND col.nome_coluna          = col_cons.column_name
        order by ORDEM_EXIBICAO) 
    loop
      if (length(vFiltro||' and '||cLabelColuna.filtro) <= vTamanhoColuna) then
        if vFiltro is null then
          vFiltro := cLabelColuna.filtro;
        else
          vFiltro := vFiltro||' and '||cLabelColuna.filtro;
        end if;
      else
        raise_application_error (-20000, 'Erro ao montra o filtro da tabela ID ='||pIdDicTabela||'. Valor muito grande.');
      end if;
    end loop;
    return vFiltro;
  end;
--**************************************************************************************
  procedure prc_atualizar_filtros (pIdDicTabela dic_tabela.id_tabela%type) is
    vDicTabFiltro dic_tabela_filtro%rowtype;
  begin
    --obter dados do filtro por ID
    SELECT tab.id_tabela ,
      fnc_getFiltroLabel(tab.id_tabela) nome_filtro,
      fnc_getFiltro(tab.id_tabela) filtro,
      0 ordem_prioridade
    into vDicTabFiltro.id_tabela,
         vDicTabFiltro.nome_filtro,
         vDicTabFiltro.filtro,
         vDicTabFiltro.ordem_prioridade
    FROM user_constraints cons,
      dic_tabela tab
    WHERE tab.id_tabela      = pIdDicTabela
    AND cons.table_name          = tab.nome_tabela
    AND cons.constraint_type     = 'P';
    
    --inserir ou atualizar o filtro
    begin
      insert into dic_tabela_filtro(ID_TABELA,NOME_FILTRO,FILTRO,ORDEM_PRIORIDADE)
      values (vDicTabFiltro.ID_TABELA,vDicTabFiltro.NOME_FILTRO,vDicTabFiltro.FILTRO,vDicTabFiltro.ORDEM_PRIORIDADE);
    exception
      when dup_val_on_index then
        update dic_tabela_filtro
        set filtro = vDicTabFiltro.FILTRO
        where ID_TABELA = vDicTabFiltro.ID_TABELA
        and NOME_FILTRO = vDicTabFiltro.NOME_FILTRO;
    end;
        
  exception
    when no_data_found then
      raise_application_error (-20000, 'Nao encontrado chave primaria para a tabela ID='||pIdDicTabela||'.');
  end;
--**************************************************************************************
  function fnc_getNomeColunaBean(pNomeColuna in varchar2) return dic_coluna.nome_coluna_bean%type as
    vStartPosition number(5) := 1;
    vNextPosition number(5);
    vNomeBean dic_coluna.nome_coluna_bean%type;
  begin
    --primeira posicao do _
    vNextPosition := instr(pNomeColuna,'_');
    --se nao existe _ o valor do bean e igual ao da coluna
    if vNextPosition = 0 then
      return lower(pNomeColuna);
    end if;
    --retirar _ e atualizar 1 letra para maiuscula
    while (vStartPosition < length(pNomeColuna)) loop
       
      --concatenar texto
      if vNomeBean is null then
        vNomeBean := lower(substr(pNomeColuna,vStartPosition,vNextPosition-1));
      else 
        vNomeBean := vNomeBean||
                     --primeira Maiuscula
                     replace(upper(substr(pNomeColuna,vStartPosition,1)),'_','')||
                     --outras Minusculas
                     replace(lower(substr(pNomeColuna,vStartPosition+1,(vNextPosition-vStartPosition))),'_','')
                    ;
      end if;

      --setar vStartPosition para a proxima interacao do loop
      vStartPosition := vNextPosition + 1;

      --Obter proximo '_'
      vNextPosition := instr(pNomeColuna,'_',vStartPosition);

      --tratar ultimo '_'
      if vNextPosition = 0 then
        vNextPosition := length(pNomeColuna);
      end if;
      
    end loop;   
    return vNomeBean;
  exception
  when no_data_found then
    return null;
  end;
--**************************************************************************************
  procedure prc_atualizar_coluna(pNomeTabela in varchar2,
                                 pIdDIcTabela dic_tabela.id_tabela%type)as
    vDicTabela dic_tabela%rowtype;
  begin
    for cColunas in (SELECT com.column_name nome_coluna,
                      --assumir nome completo como o valor do comentario até o primeiro ->
                      NVL(trim(SUBSTR(com.comments,
                                      1,
                                      DECODE(instr(com.comments,'->'), 
                                             0,
                                             LENGTH(com.comments), 
                                             instr(com.comments,'->')-1)
                                      )
                               ),
                          CONST_TXT_SEM_VALOR) label_coluna,
                      Decode(nvl(col.nullable,'S'),'S','N','S') obrigatorio,
                      greatest((nvl(col.data_precision,col.data_length) * 2),100) tamanho_coluna_tela,
                      lower(substr(com.column_name,1,1))||substr(replace(initcap(com.column_name),'_'),2)nome_coluna_bean,
                      decode(col.data_type,'VARCHAR2','STRING',col.data_type)tipo_coluna, 
                      col.data_default valor_default,
                      col.column_id,
                      dic_col.id_tabela,
                      dic_col.id_coluna,
                      dic_col.label_coluna label_coluna_atual,
                      nvl(col.data_precision,col.data_length) tamanho_coluna_bd,
                      col.data_scale casas_decimais
                    FROM user_tab_columns col,
                      user_col_comments com,
                      dic_coluna dic_col
                    WHERE col.table_name         = pNomeTabela
                    AND com.table_name           = col.table_name
                    AND com.column_name          = col.column_name
                    AND dic_col.id_tabela(+) = pIdDIcTabela
                    AND dic_col.nome_coluna(+)   = col.column_name)
                      loop
      if cColunas.id_coluna is null then
        insert into dic_coluna(
              id_tabela,
              nome_coluna,
              nome_coluna_bean,
              label_coluna,
              ind_obrigatorio, 
              ordem_exibicao,
              ind_visivel_grid,
              tamanho_coluna_grid,
              tamanho_item_form,
              tipo_coluna,
              valor_default,
              tamanho_coluna_bd,
              casas_decimais)
        values (pIdDIcTabela, 
                cColunas.nome_coluna , 
                cColunas.nome_coluna_bean,
                cColunas.label_coluna,
                cColunas.obrigatorio, 
                cColunas.column_id,
                'S',
                cColunas.tamanho_coluna_tela,
                cColunas.tamanho_coluna_tela,
                cColunas.tipo_coluna,
                cColunas.valor_default,
                cColunas.tamanho_coluna_bd,
                cColunas.casas_decimais);
      else --if cColunas.label_coluna_atual = CONST_TXT_SEM_VALOR then
        update dic_coluna
        set label_coluna = decode(label_coluna,CONST_TXT_SEM_VALOR,cColunas.label_coluna,label_coluna),
            tamanho_coluna_bd = cColunas.tamanho_coluna_bd,
            casas_decimais = cColunas.casas_decimais
        where id_coluna = cColunas.id_coluna ;
      end if;
    end loop;
    
  exception
    when no_data_found then
      raise_application_error(-20000,'Erro ao atualizar as colunas da tabela '||pNomeTabela||'!');
  end;

--**************************************************************************************
function fnc_getIdDicTabela(pNomeTabela in varchar2) return dic_tabela.id_tabela%type as
    vIdTabela dic_tabela.id_tabela%type;
  begin
    select id_tabela
    into vIdTabela
    from dic_tabela
    where nome_tabela = pNomeTabela;
    --
    return vIdTabela;
  exception
  when no_data_found then
    return null;
  end;

--**************************************************************************************
  function prc_atualizar_tabela(pNomeTabela in varchar2) return dic_tabela.id_tabela%type as
    vDicTabela dic_tabela%rowtype;
  begin
    vDicTabela.id_tabela := fnc_getIdDicTabela(pNomeTabela);
    
    if vDicTabela.id_tabela is null then 
      select table_name nome_tabela ,table_name tabel_form, 500 altura_form, 700 comprimento_form
      into vDicTabela.nome_tabela, vDicTabela.label_form, vDicTabela.altura_form, vDicTabela.comprimento_form
      from user_tables or_tab 
      where or_tab.table_name =pNomeTabela;
      --
      insert into dic_tabela(nome_tabela,label_form,altura_form,comprimento_form)
      values (vDicTabela.nome_tabela, vDicTabela.label_form,vDicTabela.altura_form, vDicTabela.comprimento_form)
      returning id_tabela into vDicTabela.id_tabela;
    end if;
    
    return vDicTabela.id_tabela;
  exception
    when no_data_found then
      raise_application_error(-20000,'Tabela '||pNomeTabela||' não encontrada!');
    when others then
      raise_application_error(-20000,'Erro ao processar tabela '||pNomeTabela||'. Erro: '||sqlerrm);
  end;
  
  --**************************************************************************************
  procedure prc_atualizar_dados as
  begin
    for cTabs in 
      (select table_name from user_tables) 
    loop
      prc_atualizar_dados(cTabs.table_name);
    end loop;
  end;
  
--**************************************************************************************  
  procedure prc_atualizar_dados(pNomeTabela in varchar2)as
    
    vIdDicTabela dic_tabela.id_tabela%type;
  begin
    --processar tabela
    vIdDicTabela := prc_atualizar_tabela(pNomeTabela);
    commit;
    --processar colunas
    prc_atualizar_coluna(pNomeTabela,vIdDicTabela);
    commit;
    --processar filtros
    prc_atualizar_filtros(vIdDicTabela);
    commit;
  end;
  
END PCK_DIC_DADOS;