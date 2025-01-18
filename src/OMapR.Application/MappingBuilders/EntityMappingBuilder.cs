using System.Linq.Expressions;

namespace OMapR.Application.MappingBuilders;


public class EntityMappingBuilder<TEntity>
{
    private readonly ICore _core;

    public EntityMappingBuilder(ICore core)
    {
        _core = core;
        _core.AddEntityConfig<TEntity>();
    }
    
    public EntityMappingBuilder<TEntity> SetTableName(string tableName)
    {
        _core.SetEntityTableName<TEntity>(tableName);
        return this;
    }

    public EntityMappingBuilder<TEntity> SetPrimaryKey(Expression<Func<TEntity, object>> propertyNavigation)
    {
        _core.SetEntityPrimaryKeyProperty(propertyNavigation);
        return this;
    }
}