namespace Battleships.Validators;

public static class ShipValidator
{
    public static bool Validate(Coordinate start, Coordinate end, int MaxLength, int MinLenght)
    {
        MaximumLenghtCheck(start, end, MinLenght);
        return true;
    }

    private static bool MinimumLenghtCheck(Coordinate start, Coordinate end, int minLenght)
    {
        // Not like this needs to be for specific ship orientation
        if (end.row - start.row < minLenght - 1)
        {
            throw new Exception($"Ship does not meet length requirements");
        }
       
        if (end.column - start.column < minLenght - 1)
        {
            throw new Exception($"Ship does not meet length requirements");
        }

        return true;
    }
    
    private static bool MaximumLenghtCheck(Coordinate start, Coordinate end, int maxLength)
    {
        if (end.row - start.row >= maxLength)
        {
            throw new Exception($"Ship does not meet length requirements");
        }
       
        if (end.column - start.column >= maxLength)
        {
            throw new Exception($"Ship does not meet length requirements");
        }
        
        return true;
    }
}