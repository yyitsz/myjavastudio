create or replace directory data_dir as '/background/dump/dest/';
/

CREATE TABLE alert_log
 (
 text_line varchar2(255)
 )
 ORGANIZATION EXTERNAL
 (
 TYPE ORACLE_LOADER
 DEFAULT DIRECTORY data_dir
 ACCESS PARAMETERS
 (
 records delimited by newline
 fields
 REJECT ROWS WITH ALL NULL FIELDS
 )
 LOCATION
 (
 'alert_xe.log'
 )
 )
 REJECT LIMIT unlimited
 /