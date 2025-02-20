namespace OMapR.Application.Common.Exceptions;

public class PropertyAlreadyMappedException(string propertyName)
    : OMapRException($"Mapping for property {propertyName} already exists.");