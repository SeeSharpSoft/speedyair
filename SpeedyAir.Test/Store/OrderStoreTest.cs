using Snapper.Nunit;
using SpeedyAir.Model;

namespace SpeedyAir.Store;

public class OrderStoreTest
{
    [SetUp]
    public void Setup()
    {

    }

    [Test]
    public async Task Orders_File_Should_Be_Parsed_Correctly()
    {
        IList<Order> orders = await OrderStore.Instance.GetElements();
        Assert.That(orders, Matches.Snapshot());
    }
}