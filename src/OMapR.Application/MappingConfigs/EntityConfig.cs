using System.Linq.Expressions;

namespace OMapR.Application.MappingConfigs;


internal class EntityConfig<TEntity> : IEntityConfig<TEntity>
{
    public string? TableName { get; set; }
    public Expression<Func<TEntity, object>>? PrimaryKeyNavigation { get; set; }
    public IList<PropertyConfig<TEntity>> PropertyConfigs { get; set; } = new List<PropertyConfig<TEntity>>();


    public bool IsForType(Type type)
    {
        return GetType().IsGenericType &&
               GetType().GetGenericArguments()[0] == type;
    }

    public IEntityConfig<TEntity> SetTableName(string tableName)
    {
        TableName = tableName;
        return this;
    }

    public IEntityConfig<TEntity> SetPrimaryKey(Expression<Func<TEntity, object>> primaryKeyNavigation)
    {
        PrimaryKeyNavigation = primaryKeyNavigation;
        return this;
    }
}