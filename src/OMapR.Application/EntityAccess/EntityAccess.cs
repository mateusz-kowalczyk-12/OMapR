using System.Reflection;
using Microsoft.Data.SqlClient;
using OMapR.Application.Common.Exceptions;
using OMapR.Application.MappingConfigs;
using OMapR.Application.Options;
using OMapR.Application.Queries;
using OMapR.Application.Queries.Builders;

namespace OMapR.Application.EntityAccess;

internal class EntityAccess<TEntity> : IEntityAccess<TEntity>
    where TEntity : new()
{
    private readonly EntityConfig<TEntity> _entityConfig;
    private readonly OMapROptions _options;
    private readonly NullabilityInfoContext _nullabilityInfoContext;

    
    public EntityAccess(EntityConfig<TEntity> entityConfig, OMapROptions options)
    {
        _entityConfig = entityConfig;
        _options = options;
        _nullabilityInfoContext = new NullabilityInfoContext();
    }

    public List<TEntity> ToList()
    {
        var query = GetAllBuilder<TEntity>.Build(_entityConfig, _options.DbProvider);
        using var connection = new SqlConnection(_options.ConnectionString);
        
        connection.Open();
        var entities = ReadTableRows(query, connection);
        connection.Close();
        
        return entities;
    }


    private List<TEntity> ReadTableRows(GetQuery query, SqlConnection connection)
    {
        var entities = new List<TEntity>();
        using var command = new SqlCommand(query.Text, connection);
        using var reader = command.ExecuteReader();
        
        while (reader.Read())
        {
            MapTableRowToEntity(reader, entities);
        }

        return entities;
    }
    
    private void MapTableRowToEntity(SqlDataReader reader, List<TEntity> entities)
    {
        var entity = new TEntity();

        for (var i = 0; i < _entityConfig.PropertyConfigs.Count; i++)
        {
            var propertyConfig = _entityConfig.PropertyConfigs[i];
            var propertyInfo = propertyConfig.GetPropertyInfo();
                
            var value = reader.GetValue(i);
            ThrowIfNullNotPermitted(value, propertyInfo);
                
            propertyInfo.SetValue(entity, value == DBNull.Value ? null : value);
        }
            
        entities.Add(entity);
    }

    private void ThrowIfNullNotPermitted(object value, PropertyInfo propertyInfo)
    {
        if (value != DBNull.Value)
            return;
        
        var nullabilityInfo = _nullabilityInfoContext.Create(propertyInfo);
        
        if (nullabilityInfo.WriteState != NullabilityState.Nullable)
            throw new NullNotPermittedException(propertyInfo);
    }
}