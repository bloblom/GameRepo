# Remise en forme C#/dotNET

## Game Repository
### Simple backend to store basic informations about various videogames

## Starting SQL Server
### SQL Server is used within a docker container to store application data

#### To start the DB in docker
##### the container is set to self-destruct after shutdown using *--rm*
```powershell
$db_password = "[DB_password]"
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=$db_password" -p 1433:1433 -d --rm --name SQL_Server mcr.microsoft.com/mssql/server:2022-latest
```

#### To set the DB connection string in the secret manager
##### $db_password should be the same as the previous one
```powershell
$db_password = "[DB_password]"
dotnet user-secrets set "ConnectionStrings:GameRepoContext" "Server=localhost; Database=GameRepo; User Id=sa; Password=$db_password; TrustServerCertificate=True"
```
##### secrets can be found at any time using the *dotnet user-secrets list* command

#### Database initialization is automatized on startup but can be done manually using
```powershell
dotnet ef database update
```