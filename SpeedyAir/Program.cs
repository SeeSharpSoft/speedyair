namespace SpeedyAir;
class Program
{
    private const string ListFlights = "list";
    private const string ScheduleFlights = "schedule";
    
    static async Task<int> Main(string[] args)
    {
        if (args.Length == 0) ShowArguments();
        else
        {
            SpeedyAir main = new SpeedyAir();
            switch (args[0])
            {
                case ListFlights:
                    await main.ListFlights();
                    break;
                case ScheduleFlights:
                    await main.ScheduleFlights();
                    break;
                default:
                    ShowArguments();
                    break;
            }
        }

        return 0;
    }

    private static void ShowArguments()
    {
        Console.WriteLine("Available arguments:");
        Console.WriteLine($"{ListFlights} - show available flights");
        Console.WriteLine($"{ScheduleFlights} - schedule orders based on available flights");
    }
}

