namespace EserMarioKart.Repos
{
    public interface IRepo<T>
    {
        IEnumerable<T> GetAll();
        T? GetByCodice(string codice);
        bool Create(T entity);
        bool Update(T entity);
        bool DeleteByCodice(string codice);

    }
}
