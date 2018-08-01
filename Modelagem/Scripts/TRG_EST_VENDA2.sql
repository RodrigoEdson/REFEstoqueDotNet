create or replace
TRIGGER REF_ESTOQUE_V3.TRG_EST_VENDA
 BEFORE INSERT OR UPDATE ON  REF_ESTOQUE_V3.EST_VENDA
 FOR EACH ROW   
BEGIN 
   :new.dt_ult_alteracao := sysdate;
   if inserting then 
     -- se a data vier nula, setar o sysdate
     if :new.dt_venda  is null then
       :new.dt_venda := sysdate;
     end if;
     -- se a data vier nula, setar o sysdate
     if :new.dt_emissao  is null then
       :new.dt_emissao := sysdate;
     end if;
     --tratar o ID
     IF :new.ID_VENDA IS NULL or :new.ID_VENDA <=0 THEN  
       select SEQ_EST_VENDA_PK.nextval 
       into :new.ID_VENDA
        from dual; 
     END IF; 
     --nao permitir atualização de ID
   elsif updating('ID_VENDA') then 
     raise_application_error(-20000,'Alteracao de ID nao permitida'); 
   end if; 
 END;