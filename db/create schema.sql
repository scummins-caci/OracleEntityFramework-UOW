CREATE USER EF_TEST IDENTIFIED BY Password123456;
GRANT CONNECT TO EF_TEST;
GRANT ALL PRIVILEGES TO EF_TEST;
CREATE SYNONYM EF_TEST.DBMS_LOB FOR SYS.DBMS_LOB;
GRANT ALL ON SYS.DBMS_LOB TO EF_TEST;