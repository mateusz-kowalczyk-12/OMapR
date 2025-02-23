namespace OMapR.Application.EntityAccess;

public interface IEntityAccess<TEntity>
{
    List<TEntity> ToList();
}