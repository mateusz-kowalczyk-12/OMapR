using System.Linq.Expressions;

namespace OMapR.Application.MappingConfigs;


public interface IEntityConfig
{
    bool IsForType(Type type);
}


public interface IEntityConfig<TEntity> : IEntityConfig
{
    IEntityConfig<TEntity> SetTableName(string tableName);

    IEntityConfig<TEntity> SetPrimaryKey(Expression<Func<TEntity, object>> primaryKeyNavigation);
}