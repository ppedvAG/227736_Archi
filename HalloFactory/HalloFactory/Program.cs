using System.Data.Common;

Console.WriteLine("Hello Factory!");

string conString = "Server=(localdb)\\mssqllocaldb;Database=Northwnd;Trusted_Connection=true";

//DbProviderFactory factory = Microsoft.Data.SqlClient.SqlClientFactory.Instance;
DbProviderFactory factory = MySql.Data.MySqlClient.MySqlClientFactory.Instance;

DbConnection con = factory.CreateConnection();
con.ConnectionString = conString;
con.Open();

con.CreateCommand();

//DbCommand dbCommand = factory.CreateCommand();
//dbCommand.Connection = con;

DbCommand dbCommand = con.CreateCommand();
dbCommand.CommandText = "SELECT * FROM Employees";

var reader = dbCommand.ExecuteReader();

while (reader.Read())
{
    Console.WriteLine($"{reader.GetString(reader.GetOrdinal("FirstName"))}");
}

