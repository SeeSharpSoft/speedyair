using SpeedyAir.Model;
using SpeedyAir.Store;

namespace SpeedyAir;

public class SpeedyAir
{
    public async Task ListFlights()
    {
        IList<Flight> flights = await FlightStore.Instance.getElements();
        foreach (Flight flight in flights)
        {
            Console.WriteLine(
                $"Flight: {flight.Number}, departure: {flight.From.Code}, arrival: {flight.To.Code}, day: {flight.Day}");
        }
    }
    
    public async Task ScheduleFlights()
    {
        IList<Flight> flights = await FlightStore.Instance.getElements();
        IList<Order> orders = await OrderStore.Instance.getElements();
        IList<FlightPlan> scheduledFlights =
            flights.Select(flight => new FlightPlan() { Flight = flight, Capacity = flight.Capacity })
                .OrderBy(flightPlan => flightPlan.Flight.Day)
                .ToList();
        foreach (Order order in orders)
        {
            Flight? targetFlight = UseFlight(scheduledFlights, order);
            if (targetFlight == null)
            {
                Console.WriteLine(
                    $"order: {order.Number}, flightNumber: not scheduled");
            } else
            {
                Console.WriteLine($"order: {order.Number}, flightNumber: {targetFlight.Number}, departure: {targetFlight.From}, arrival: {targetFlight.To}, day: {targetFlight.Day}");
            }
        }
    }

    private Flight? UseFlight(IEnumerable<FlightPlan> availableFlights, Order order)
    {
        FlightPlan targetFlightPlan = availableFlights
            .Where(sFlight => sFlight.Flight!.To.Equals(order.Destination) && sFlight.Capacity >= order.Amount)
            .FirstOrDefault(UNSCHEDULED);

        if (targetFlightPlan != UNSCHEDULED)
        {
            targetFlightPlan.Capacity -= order.Amount;
        }

        return targetFlightPlan.Flight;
    }

    private class FlightPlan
    {
        public override string ToString()
        {
            return Flight == null ? "not scheduled" : Flight.Number.ToString();
        }
        
        public Flight? Flight { get; set; }
        public int Capacity { get; set; }
    }

    private static FlightPlan UNSCHEDULED = new();
}