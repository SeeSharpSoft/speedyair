using System.Text.Json;
using SpeedyAir.Model;

namespace SpeedyAir.Store;

public class OrderStore : BaseStore<Order>
{
    private static OrderStore? _instance;
    
    public static OrderStore Instance
    {
        get { return _instance ??= new OrderStore(); }
    }

    private OrderStore() : base("orders.json")
    {
        // singleton
    }
    
    protected override async Task<IList<Order>> LoadElements()
    {
        FileStream stream = File.OpenRead(FileName);
        IList<City> cities = await CityStore.Instance.GetElements();
        Dictionary<String, Dictionary<string, string>> dict = await JsonSerializer.DeserializeAsync<Dictionary<String, Dictionary<string, string>>>(stream) ?? new Dictionary<String, Dictionary<string, string>>();
        return dict.Select(entry => new Order()
            {
                Amount = 1,
                Destination = cities.FirstOrDefault(city => city.Code == entry.Value.Values.First(), new City() { Code = entry.Value.Values.First() }),
                Priority = Int32.Parse(entry.Key.Substring(6)),
                Number = entry.Key
            })
            .ToList();
    }
}