using OMapR.Application.MappingConfigs;

namespace OMapR.Application;

public interface ICore
{
    IEntityConfig<TEntity> AddEntityConfig<TEntity>(); 
    
    void ConnectToDb();
}