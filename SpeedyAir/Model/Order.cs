namespace SpeedyAir.Model;

public class Order
{
    public int Priority { get; init; }
    public String Number { get; init; }
    public City Destination { get; init; }
    public int Amount { get; init; }
    
    public override string ToString()
    {
        return $"{Number}: {Amount} packages to {Destination} with priority {Priority}";
    }
}