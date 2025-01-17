using OMapR.Application.Common.Enums;

namespace OMapR.Application.Options;


public class OMapROptions
{
    internal string ConnectionString { get; set; } = string.Empty;
    internal DbProvider DbProvider { get; set; }

    public void UseSqlServer(string connectionString)
    {
        ConnectionString = connectionString;
        DbProvider = DbProvider.SqlServer;
    }
}