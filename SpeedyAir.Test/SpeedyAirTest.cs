using Snapper.Nunit;

namespace SpeedyAir;

public class SpeedyAirTest
{
    private SpeedyAir main;
    private StringWriter consoleOut;
    
    [SetUp]
    public void Setup()
    {
        main = new SpeedyAir();
        
        consoleOut = new StringWriter();
        Console.SetOut(consoleOut);
    }

    [Test]
    public async Task List_Flights_Snapshot()
    {
        await main.ListFlights();
        Assert.That(consoleOut.ToString(), Matches.Snapshot());
    }
    
    [Test]
    public async Task Schedule_Flights_Snapshot()
    {
        await main.ScheduleFlights();
        Assert.That(consoleOut.ToString(), Matches.Snapshot());
    }
}