using SpeedyAir.Model;

namespace SpeedyAir.Store;

public class CityStore : BaseStore<City>
{
    private static CityStore? _instance;
    
    public static CityStore Instance
    {
        get { return _instance ??= new CityStore(); }
    }
    
    private CityStore() : base("cities.json")
    {
        // singleton
    }
}