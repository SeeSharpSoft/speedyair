namespace SpeedyAir.Model;

public class Order
{
    public int Priority { get; set; }
    public String Number { get; set; }
    public City Destination { get; set; }
    public int Amount { get; set; }
    
    public override string ToString()
    {
        return $"{Number}: {Amount} packages to {Destination} with priority {Priority}";
    }
}