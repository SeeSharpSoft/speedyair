using SpeedyAir.Model;

namespace SpeedyAir.Store;

public class FlightStore : BaseStore<Flight>
{
    private static FlightStore? _instance;
    
    public static FlightStore Instance
    {
        get { return _instance ??= new FlightStore(); }
    }

    private FlightStore() : base("flights.json")
    {
        // singleton
    }
}