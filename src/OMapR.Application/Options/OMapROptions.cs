using OMapR.Application.Common.Enums;

namespace OMapR.Application.Options;


public record OMapROptions
{
    internal string ConnectionString { get; private set; } = string.Empty;
    internal DbProvider DbProvider { get; private set; }
    
    public void UseSqlServer(string connectionString)
    {
        ConnectionString = connectionString;
        DbProvider = DbProvider.SqlServer;
    }
}