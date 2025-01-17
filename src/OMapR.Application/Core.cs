using Microsoft.Data.SqlClient;
using OMapR.Application.Options;

namespace OMapR.Application;


public class Core : ICore
{
    private readonly OMapROptions _options;
    
    
    public Core(OMapROptions options)
    {
        _options = options;
    }


    public void ConnectToDb()
    {
        using var connection = new SqlConnection(_options.ConnectionString);
        connection.Open();
        connection.Close();
    }
}