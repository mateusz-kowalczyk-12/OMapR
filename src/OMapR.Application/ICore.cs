using System.Linq.Expressions;

namespace OMapR.Application;

public interface ICore
{
    void AddEntityConfig<TEntity>();
    
    void SetEntityTableName<TEntity>(string tableName);

    void SetEntityPrimaryKeyProperty<TEntity>(Expression<Func<TEntity, object>> primaryKeyNavigation);
    
    void ConnectToDb();
}