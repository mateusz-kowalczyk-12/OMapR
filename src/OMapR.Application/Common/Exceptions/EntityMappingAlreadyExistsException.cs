namespace OMapR.Application.Common.Exceptions;

public class EntityMappingAlreadyExistsException(string entityTypeName)
    : OMapRException($"Mapping for entity type {entityTypeName} already exists.");