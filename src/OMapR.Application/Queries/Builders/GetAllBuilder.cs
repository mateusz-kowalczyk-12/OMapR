using System.Text;
using OMapR.Application.Common.Enums;
using OMapR.Application.Common.Exceptions;
using OMapR.Application.MappingConfigs;

namespace OMapR.Application.Queries.Builders;

internal static class GetAllBuilder<TEntity>
{
    public static GetQuery Build(EntityConfig<TEntity> entityConfig, DbProvider dbProvider)
    {
        return dbProvider switch
        {
            DbProvider.SqlServer => BuildForSqlServer(entityConfig, dbProvider),
            _ => throw new BadDbProviderException(dbProvider)
        };
    }


    private static GetQuery BuildForSqlServer(EntityConfig<TEntity> entityConfig, DbProvider dbProvider)
    {
        var queryTextBuilder = new StringBuilder("SELECT ");
        var columnNames = entityConfig.PropertyConfigs
            .Select(propertyConfig => $"[{propertyConfig.ColumnName}]")
            .ToList();
        queryTextBuilder.Append(string.Join(", ", columnNames));
        queryTextBuilder.Append($" FROM [{entityConfig.TableName}]");
        
        return new GetQuery(queryTextBuilder.ToString());
    }
}