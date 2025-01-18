namespace OMapR.Application.Common.Exceptions;

public class MappingNotFoundException(string entityTypeName)
    : Exception($"Mapping for entity type {entityTypeName} does not exist.");