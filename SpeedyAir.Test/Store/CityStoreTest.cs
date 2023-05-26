using Snapper.Nunit;
using SpeedyAir.Model;

namespace SpeedyAir.Store;

public class CityStoreTest
{
    [SetUp]
    public void Setup()
    {

    }

    [Test]
    public async Task City_File_Should_Be_Parsed_Correctly()
    {
        IList<City> cities = await CityStore.Instance.GetElements();
        Assert.That(cities, Matches.Snapshot());
    }
}