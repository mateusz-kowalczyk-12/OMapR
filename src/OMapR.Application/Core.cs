using OMapR.Application.Common.Exceptions;
using OMapR.Application.EntityAccess;
using OMapR.Application.MappingConfigs;
using OMapR.Application.Options;

namespace OMapR.Application;


public class Core
{
    private readonly OMapROptions _options;
    private readonly MappingConfig _mappingConfig;
    
    public Core(OMapROptions options, MappingConfig mappingConfig)
    {
        _options = options;
        _mappingConfig = mappingConfig;
    }

    public IEntityConfig<TEntity> AddEntityConfig<TEntity>()
        where TEntity : new()
    {
        var newEntityConfig = CreateEntityConfigForType<TEntity>();
        _mappingConfig.EntityConfigs.Add(newEntityConfig);

        return newEntityConfig;
    }

    public IEntityAccess<TEntity> GetEntityAccess<TEntity>()
        where TEntity : new()
    {
        var entityConfig = GetEntityConfigForType<TEntity>();
        var entityAccess = new EntityAccess<TEntity>(entityConfig, _options);
        return entityAccess;
    }
    

    private EntityConfig<TEntity> CreateEntityConfigForType<TEntity>()
    {
        if (_mappingConfig.EntityConfigs.Any(config => config.IsForType(typeof(TEntity))))
            throw new EntityMappingAlreadyExistsException(nameof(TEntity));

        return new EntityConfig<TEntity>();
    }
    
    private EntityConfig<TEntity> GetEntityConfigForType<TEntity>()
    {
        var entityConfig = _mappingConfig.EntityConfigs
            .SingleOrDefault(config => config.IsForType(typeof(TEntity)));
        
        if (entityConfig is null)
            throw new MappingNotFoundException(typeof(TEntity).Name);
        
        if (entityConfig is not EntityConfig<TEntity> entityConfigForType)
            throw new InternalOMapRException("EntityConfig's entity type inconsistency.");
        
        return entityConfigForType;
    }
}