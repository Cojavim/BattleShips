namespace Battleships;

public class Coordinate
{
    public int row { get; }
    public int column { get; }

    public Coordinate(string coordinate)
    {
        // validate Coordinate
        row = (int)Char.GetNumericValue(coordinate[0]);
        column = (int)Char.GetNumericValue(coordinate[2]);
    }
}