using OMapR.Application.Common.Enums;

namespace OMapR.Application.Common.Exceptions;

public class BadDbProviderException(DbProvider dbProvider)
    : OMapRException($"Bad DbProvider: {dbProvider.ToString()}");