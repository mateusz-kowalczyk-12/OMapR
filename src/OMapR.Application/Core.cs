using System.Linq.Expressions;
using Microsoft.Data.SqlClient;
using OMapR.Application.Common.Exceptions;
using OMapR.Application.MappingConfigs;
using OMapR.Application.Options;

namespace OMapR.Application;


public class Core : ICore
{
    private readonly OMapROptions _options;
    private readonly List<IEntityConfig> _entityConfigs;
    
    public Core(OMapROptions options)
    {
        _options = options;
        _entityConfigs = [];
    }

    public void AddEntityConfig<TEntity>()
    {
        if (_entityConfigs.Any(config => config.IsForType(typeof(TEntity))))
            throw new MappingAlreadyExistsException(nameof(TEntity));

        var newEntityConfig = new EntityConfig<TEntity>();
        _entityConfigs.Add(newEntityConfig);
    }

    public void SetEntityTableName<TEntity>(string tableName)
    {
        var entityConfig = GetEntityConfigForType<TEntity>();
        entityConfig.TableName = tableName;
    }

    public void SetEntityPrimaryKeyProperty<TEntity>(Expression<Func<TEntity, object>> primaryKeyNavigation)
    {
        var entityConfig = GetEntityConfigForType<TEntity>();
        entityConfig.PrimaryKeyNavigation = primaryKeyNavigation;
    }
    
    public void ConnectToDb()
    {
        using var connection = new SqlConnection(_options.ConnectionString);
        connection.Open();
        connection.Close();
    }


    private EntityConfig<TEntity> GetEntityConfigForType<TEntity>()
    {
        var entityConfig = _entityConfigs.SingleOrDefault(config => config.IsForType(typeof(TEntity)));
        
        if (entityConfig is null)
            throw new MappingNotFoundException(nameof(TEntity));
        
        if (entityConfig is not EntityConfig<TEntity> entityConfigForType)
            throw new ApplicationException("Internal OMapR exception: entityConfig's entity type inconsistency");
        
        return entityConfigForType;
    }
}