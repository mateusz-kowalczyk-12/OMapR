using System.Linq.Expressions;
using System.Reflection;
using OMapR.Application.Common.Exceptions;

namespace OMapR.Application.MappingConfigs;


internal class EntityConfig<TEntity> : IEntityConfig<TEntity>
{
    public string? TableName { get; set; }
    public Expression<Func<TEntity, object>>? PrimaryKeyNavigation { get; set; }
    public IList<PropertyConfig<TEntity>> PropertyConfigs { get; } = new List<PropertyConfig<TEntity>>();


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

    public IEntityConfig<TEntity> MapProperty(
        Expression<Func<TEntity, object?>> propertyNavigation, string columnName)
    {
        var newPropertyConfig = CreatePropertyConfig(propertyNavigation, columnName);
        PropertyConfigs.Add(newPropertyConfig);
        
        return this;
    }


    private PropertyConfig<TEntity> CreatePropertyConfig(
        Expression<Func<TEntity, object?>> propertyNavigation, string columnName)
    {
        var newPropertyInfo = FindPropertyInfoOrDefault(propertyNavigation);
        if (newPropertyInfo is not null)
            throw new PropertyAlreadyMappedException(newPropertyInfo.Name);
        
        var newPropertyConfig = new PropertyConfig<TEntity>
        {
            PropertyNavigation = propertyNavigation,
            ColumnName = columnName
        };
        return newPropertyConfig;
    }

    private PropertyInfo? FindPropertyInfoOrDefault(Expression<Func<TEntity, object?>> propertyNavigation)
    {
        var searchedPropertyInfo = PropertyConfig<TEntity>.GetPropertyInfo(propertyNavigation); 
        
        return PropertyConfigs
            .Select(propertyConfig => propertyConfig.GetPropertyInfo())
            .FirstOrDefault(propertyInfo => propertyInfo == searchedPropertyInfo);
    }
}