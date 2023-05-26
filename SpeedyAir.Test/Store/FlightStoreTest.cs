using Snapper.Nunit;
using SpeedyAir.Model;

namespace SpeedyAir.Store;

public class FlightStoreTest
{
    [SetUp]
    public void Setup()
    {

    }

    [Test]
    public async Task Flights_File_Should_Be_Parsed_Correctly()
    {
        IList<Flight> flights = await FlightStore.Instance.GetElements();
        Assert.That(flights, Matches.Snapshot());
    }
}