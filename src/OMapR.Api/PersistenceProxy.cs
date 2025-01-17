using OMapR.Application;

namespace OMapR.Api;


public class PersistenceProxy : IPersistenceProxy
{
    private readonly ICore _core;

    
    public PersistenceProxy(ICore core)
    {
        _core = core;
    }


    public void ConnectToDb()
    {
        _core.ConnectToDb();
    }
}