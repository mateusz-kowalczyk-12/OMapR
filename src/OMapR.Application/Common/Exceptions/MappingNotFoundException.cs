namespace OMapR.Application.Common.Exceptions;

public class MappingNotFoundException(string entityTypeName)
    : OMapRException($"Mapping for entity type {entityTypeName} does not exist.");