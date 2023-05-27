using SpeedyAir.Model;
using SpeedyAir.Store;

namespace SpeedyAir;

public class SpeedyAir
{
    public async Task ListFlights()
    {
        IList<Flight> flights = await FlightStore.Instance.GetElements();
        foreach (Flight flight in flights)
        {
            Console.WriteLine(
                $"Flight: {flight.Number}, departure: {flight.From.Code}, arrival: {flight.To.Code}, day: {flight.Day}");
        }
    }

    public async Task ScheduleFlights()
    {
        IList<Flight> flights = await FlightStore.Instance.GetElements();
        IList<Order> orders = await OrderStore.Instance.GetElements();
        Dictionary<City, List<FlightPlan>> scheduledFlights = flights
            .Select(flight => new FlightPlan() { Flight = flight, Capacity = flight.Capacity })
            .OrderBy(flightPlan => flightPlan.Flight!.Day)
            .GroupBy(flightPlan => flightPlan.Flight!.To)
            .ToDictionary(group => group.Key, group => group.ToList());
        foreach (Order order in orders.OrderBy(order => order.Priority))
        {
            Flight? targetFlight = UseFlight(scheduledFlights, order);
            Console.WriteLine(targetFlight == null
                ? $"order: {order.Number}, flightNumber: not scheduled"
                : $"order: {order.Number}, flightNumber: {targetFlight.Number}, departure: {targetFlight.From}, arrival: {targetFlight.To}, day: {targetFlight.Day}");
        }
    }

    private Flight? UseFlight(Dictionary<City, List<FlightPlan>> scheduledFlights, Order order)
    {
        if (scheduledFlights.TryGetValue(order.Destination, out List<FlightPlan>? availableFlightsToDestination))
        {
            FlightPlan targetFlightPlan = availableFlightsToDestination
                .FirstOrDefault(sFlight => sFlight.Capacity >= order.Amount, UNSCHEDULED_FLIGHTPLAN);

            if (targetFlightPlan != UNSCHEDULED_FLIGHTPLAN)
            {
                targetFlightPlan.Capacity -= order.Amount;
                if (targetFlightPlan.Capacity == 0)
                {
                    availableFlightsToDestination.Remove(targetFlightPlan);
                }

                return targetFlightPlan.Flight;
            }
        }

        return null;
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

    private static readonly FlightPlan UNSCHEDULED_FLIGHTPLAN = new();
}