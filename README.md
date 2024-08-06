# order-system-for-elshorouk-academy

Invoice system access with a user-friendly app. 

## Installation

### Clone the Repository:

```bash
# Clone repo
$ git clone https://gitlab.com/mohmedeprahem/algoriza-internship-42.git
```
## Init database
you have to execute this file ShaTaskScript.sql in Ms Sql Server management
and name your database ShaTask.

### Update App Settings:
Open the appsettings.json file and update the configuration settings:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "YourDatabaseConnectionString"
  },
  "Jwt": {
    "Key": "YourJwtSecretKey",
    "Issuer": "YourJwtIssuer",
    "Audience": "YourJwtAudience"
  },
}
```

## Restore Dependencies

```bash
$ dotnet restore
```
## Apply Migrations
Execute the following command to apply migrations and update the database:

```bash
$ dotnet ef database update
```
