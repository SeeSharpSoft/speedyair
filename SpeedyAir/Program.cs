namespace SpeedyAir;
class Program
{
    private const string LIST_FLIGHTS = "list";
    private const string SCHEDULE_FLIGHTS = "schedule";
    
    static async Task<int> Main(string[] args)
    {
        if (args.Length == 0) ShowArguments();
        else
        {
            SpeedyAir main = new SpeedyAir();
            switch (args[0])
            {
                case LIST_FLIGHTS:
                    await main.ListFlights();
                    break;
                case SCHEDULE_FLIGHTS:
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
        Console.WriteLine("'list': show available flights");
        Console.WriteLine("'schedule': schedule orders based on available flights");
    }
}

