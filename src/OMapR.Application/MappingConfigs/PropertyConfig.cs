using System.Linq.Expressions;

namespace OMapR.Application.MappingConfigs;


internal class PropertyConfig<TEntity>
{
    internal required Expression<Func<TEntity, object>> PropertyNavigation { get; set; }
    internal required string ColumnName { get; set; }
}