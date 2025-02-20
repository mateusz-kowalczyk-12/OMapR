using System.Linq.Expressions;
using System.Reflection;
using OMapR.Application.Common.Exceptions;

namespace OMapR.Application.MappingConfigs;


internal class PropertyConfig<TEntity>
{
    public required Expression<Func<TEntity, object>> PropertyNavigation { get; set; }
    public required string ColumnName { get; set; }

    public PropertyInfo GetPropertyInfo() => GetPropertyInfo(PropertyNavigation);
    
    public static PropertyInfo GetPropertyInfo(Expression<Func<TEntity, object>> propertyNavigation)
    {
        var body = propertyNavigation.Body;
        
        if (body is UnaryExpression unaryExpression)
            body = unaryExpression.Operand;

        if (body is MemberExpression { Member: PropertyInfo propertyInfo })
            return propertyInfo;

        throw new NotAPropertyException();
    }
}