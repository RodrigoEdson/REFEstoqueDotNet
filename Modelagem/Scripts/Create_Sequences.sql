SELECT ' CREATE SEQUENCE SEQ_'
  ||cons.constraint_name
  ||' INCREMENT BY 1 START WITH 1;'
FROM user_tables tab,
  user_constraints cons
WHERE cons.table_name    = tab.table_name
AND cons.constraint_type = 'P'
AND NOT EXISTS
  (SELECT 1
  FROM user_sequences
  WHERE sequence_name = 'SEQ_'
    ||cons.constraint_name
  ) 