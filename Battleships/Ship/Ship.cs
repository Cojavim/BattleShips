using System.Security.Cryptography.X509Certificates;
using Battleships.Enums;
using Battleships.Validators;

namespace Battleships.Ship;


public class Ship
{
    private int MaxLength = 4;
    private int MinLength = 2;
    public Dictionary<string, ShipSegment> Segments = new Dictionary<string, ShipSegment>();

    // "3:2,3:5"
    public Ship(string shipDefinition)
    {
       // validate ship definition
       // get start and end coordinates
       // fill missing pieces
       // create ship

       var coordinates = shipDefinition.Split(',');
       var start = new Coordinate(coordinates[0]);
       var end = new Coordinate(coordinates[1]);

       ShipValidator.Validate(start, end, MaxLength, MinLength);

       if (start.row == end.row)
       {
           CreateHorizontal(start, end);
           return;
       }

       if (start.column == end.column)
       {
           CreateVertical(start, end);
           return;
       }

       throw new Exception($"Ship {shipDefinition} Type Not Supported, check ship definition requirements");
    }
    
    private void CreateHorizontal(Coordinate start, Coordinate end)
    {
        var row = start.row;
        var count = end.column - start.column + 1; 
        var columns = Enumerable.Range(start.column, count);

        foreach (var column in columns)
        {
            Segments.Add($"{row}:{column}", new ShipSegment());
        }
    }

    private void CreateVertical(Coordinate start, Coordinate end)
    {
        var column = start.column;
        var count = end.row - start.row + 1;
        var rows = Enumerable.Range(start.row, count);

        foreach (var row in rows)
        {
            Segments.Add($"{row}:{column}", new ShipSegment());
        }
    }

    public bool IsHit(string fireCoordinate)
    {
        if (!Segments.TryGetValue(fireCoordinate, out var segment))
            return false;

        segment.Heath = SegmentHealthEnum.Hit;
        return true;
    }

    public bool IsSunk()
    {
        if (Segments.Values.Any(a => a.Heath == SegmentHealthEnum.Healthy))
        {
            return false;
        }

        return true;
    }
}