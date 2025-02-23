namespace OMapR.Application.Common.Exceptions;

public class InternalOMapRException(string message)
    : OMapRException($"Internal OMapR exception: {message}");