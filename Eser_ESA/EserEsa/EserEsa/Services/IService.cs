namespace EserEsa.Services
{
    public interface IService<T>
    {
        IEnumerable<T> PrendiliTutti();
    }
}
