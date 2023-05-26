namespace SpeedyAir.Model;

public class City
{
    public String Code { get; set; }
    public String Name { get; set; }

    public override string ToString()
    {
        return Code;
    }
    
    public override int GetHashCode()
    {
        return HashCode.Combine(Code.GetHashCode(), Name.GetHashCode());
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as City);
    }

    bool Equals(City? other)
    {
        return other != null && Code == other.Code && Name == other.Name;
    }
}