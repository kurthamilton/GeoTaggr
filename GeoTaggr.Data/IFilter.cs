namespace GeoTaggr.Data;

public interface IFilter<T>
{
    bool IsMatch(T entity);
}
