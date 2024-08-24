Create, Read, Update, and Delete App using Asp.net, C#, and .NET Core 6 with MySQL.

Requires 

Visual Studio Code

MySQL

MySql.Data 

######

Install MySql.Data 

dotnet add package MySql.Data --version <version number here>

#####

Enter your SQL servername, database, username and password in appsettings.json defaultconnection field:

"ConnectionStrings": {
    "DefaultConnection": "Server=yourserver;Database=yourdb;Uid=youruid;Pwd=yourpwd;SSL Mode=None"
  },
