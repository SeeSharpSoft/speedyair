namespace SpeedyAir.Store;

public interface IStore<T>
{
    public Task<IList<T>> getElements();
}