select 'create or replace '||chr(10)||
' TRIGGER '||user||'.TRG_'||tab.table_name||chr(10)||
' BEFORE INSERT OR UPDATE ON  '||user||'.'||tab.table_name||chr(10)||
' FOR EACH ROW  '||chr(10)||
' BEGIN '||chr(10)||
'   if inserting then '||chr(10)||
'     IF :new.'||conscol.column_name ||' IS NULL or :new.'||conscol.column_name||' <=0 THEN '||chr(10)||
'       select '||seq.sequence_name||'.nextval '||chr(10)||
'       into :new.'||conscol.column_name||chr(10)||
'        from dual; '||chr(10)||
'     END IF; '||chr(10)||
'   elsif updating('''||conscol.column_name ||''') then '||chr(10)||
'     raise_application_error(-20000,''Alteracao de ID nao permitida''); ' ||chr(10)||
'   end if; '||chr(10)||
' END; '||chr(10)||
' /'
FROM user_tables tab,
  user_sequences seq,
  user_constraints cons,
  user_cons_columns conscol
WHERE cons.table_name    = tab.table_name
AND cons.constraint_type = 'P'
AND seq.sequence_name    = 'SEQ_'
  ||cons.constraint_name
and conscol.constraint_name = cons.constraint_name
and conscol.position = 1
and conscol.column_name like 'ID_%'
and not exists (select 1 from user_triggers
where trigger_name = 'TRG_'||tab.table_name)