using System.Reflection;

namespace OMapR.Application.Common.Exceptions;

public class NullNotPermittedException(PropertyInfo propertyInfo)
    : OMapRException($"Tried to assign null to a non-nullable property: {propertyInfo.Name}");