version: '3.4'
services:
  mssql:
    container_name: mssql-db
    hostname: mssql-db
    image: mcr.microsoft.com/mssql/server:2022-latest
    environment:
      ACCEPT_EULA: 'Y'
      MSSQL_SA_PASSWORD: 'p@ssWord1'
      MSSQL_DATA_DIR: /var/opt/mssql/data
      MSSQL_PID: 'Developer' 
      MSSQL_TCP_PORT: 1433 
    ports: 
      - "14330:1433"
    volumes:
      - ./data:/var/opt/mssql/data
      - ./log:/var/opt/mssql/log
      - ./secrets:/var/opt/mssql/secrets  