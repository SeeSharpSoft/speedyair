using System.Diagnostics;
using System.Text.Json;

namespace SpeedyAir.Store;

public abstract class BaseStore<T> : IStore<T>
{
    private IList<T>? _elementsList;

    protected String FileName { get; } 
    
    protected BaseStore(string fileName)
    {
        FileName = fileName;
    }

    protected virtual async Task<IList<T>> LoadElements()
    {
        FileStream stream = File.OpenRead(FileName);
        return await JsonSerializer.DeserializeAsync<IList<T>>(stream) ?? new List<T>();
    }
    
    public async Task<IList<T>> GetElements()
    {
        if (_elementsList == null)
        {
            _elementsList = await LoadElements();
        }

        Debug.Assert(_elementsList != null, nameof(_elementsList) + " != null");
        return _elementsList.ToList();
    }
}