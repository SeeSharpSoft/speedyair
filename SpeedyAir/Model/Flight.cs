namespace SpeedyAir.Model;

public class Flight
{
    public Flight()
    {
        Capacity = 20;
    }
    
    public int Number { get; set; }
    public City From { get; set;  }
    public City To { get; set; }
    public int Day { get; set; }
    public int Capacity { get; set; }
    
    public override string ToString()
    {
        return $"Flight: {Number}, departure: {From}, arrival: {To}, day: {Day}";
    }
}