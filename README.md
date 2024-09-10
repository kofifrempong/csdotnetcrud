Create, Read, Update, and Delete App using Asp.net, C#, and .NET Core 8 with MySQL.

Requires 

Visual Studio Code

MySQL

MySql.Data 

######

To install MySql.Data 

dotnet add package MySql.Data --version <version number here>

#####

Enter your SQL servername, database, username and password in the appsettings.json "defaultconnection" field, it appears as:

"ConnectionStrings": {
    "DefaultConnection": "Server=yourserver;Database=yourdb;Uid=youruid;Pwd=yourpwd;SSL Mode=None"
  },

######

Needed SQL Tables are in the database folder