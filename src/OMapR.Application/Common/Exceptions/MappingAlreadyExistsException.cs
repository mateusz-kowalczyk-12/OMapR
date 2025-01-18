namespace OMapR.Application.Common.Exceptions;

public class MappingAlreadyExistsException(string entityTypeName)
    : Exception($"Mapping for entity type {entityTypeName} already exists.");