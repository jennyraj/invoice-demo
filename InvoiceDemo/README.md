version: '3.4'
services:
  mssql:
    container_name: mssql-db
    hostname: mssql-db
    image: mcr.microsoft.com/mssql/server:2022-latest
    environment:
      ACCEPT_EULA: 'Y'
      MSSQL_SA_PASSWORD: 'Admin@123'
      MSSQL_DATA_DIR: /var/opt/mssql/data
      MSSQL_PID: 'Developer' 
      MSSQL_TCP_PORT: 1433 
    ports: 
      - "14330:1433"
    volumes:
      - ./data:/var/opt/mssql/data
      - ./log:/var/opt/mssql/log
      - ./secrets:/var/opt/mssql/secrets  

//rabbitMQ
docker run --hostname=localhost --env=PATH=/opt/rabbitmq/sbin:/opt/erlang/bin:/opt/openssl/bin:/usr/local/sbin:/usr/local/bin:/usr/sbin:/usr/bin:/sbin:/bin --env=ERLANG_INSTALL_PATH_PREFIX=/opt/erlang --env=OPENSSL_INSTALL_PATH_PREFIX=/opt/openssl --env=RABBITMQ_DATA_DIR=/var/lib/rabbitmq --env=RABBITMQ_VERSION=4.0.2 --env=RABBITMQ_PGP_KEY_ID=0x0A9AF2115F4687BD29803A206B73A36E6026DFCA --env=RABBITMQ_HOME=/opt/rabbitmq --env=HOME=/var/lib/rabbitmq --env=LANG=C.UTF-8 --env=LANGUAGE=C.UTF-8 --env=LC_ALL=C.UTF-8 --volume=/var/lib/rabbitmq --network=bridge -p 15672:15672 -p 5672:5672 --restart=no --label='org.opencontainers.image.ref.name=ubuntu' --label='org.opencontainers.image.version=24.04' --runtime=runc -d rabbitmq:4-management

dotnet ef migrations add xxx --project InvoiceApi
dotnet ef database update --project InvoiceApi