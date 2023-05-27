namespace SpeedyAir.Model;

public class Flight
{
    public Flight()
    {
        Capacity = 20;
    }
    
    public int Number { get; init; }
    public City From { get; init;  }
    public City To { get; init; }
    public int Day { get; init; }
    public int Capacity { get; init; }
    
    public override string ToString()
    {
        return $"Flight: {Number}, departure: {From}, arrival: {To}, day: {Day}";
    }
}