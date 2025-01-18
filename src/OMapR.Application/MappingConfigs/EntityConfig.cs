using System.Linq.Expressions;

namespace OMapR.Application.MappingConfigs;


internal class EntityConfig<TEntity> : IEntityConfig
{
    internal string? TableName { get; set; }
    internal Expression<Func<TEntity, object>>? PrimaryKeyNavigation { get; set; }
    internal IList<PropertyConfig<TEntity>> PropertyConfigs { get; set; } = new List<PropertyConfig<TEntity>>();


    public bool IsForType(Type type)
    {
        return GetType().IsGenericType &&
               GetType().GetGenericArguments()[0] == type;
    }
}