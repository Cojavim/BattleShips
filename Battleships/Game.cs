using System.Net;
using Battleships.Ship;
namespace Battleships;

// Imagine a game of battleships.
//   The player has to guess the location of the opponent's 'ships' on a 10x10 grid
//   Ships are one unit wide and 2-4 units long, they may be placed vertically or horizontally
//   The player asks if a given co-ordinate is a hit or a miss
//   Once all cells representing a ship are hit - that ship is sunk.
public class Game
{
    // ships: each string represents a ship in the form first co-ordinate, last co-ordinate
    //   e.g. "3:2,3:5" is a 4 cell ship horizontally across the 4th row from the 3rd to the 6th column
    // guesses: each string represents the co-ordinate of a guess
    //   e.g. "7:0" - misses the ship above, "3:3" hits it.
    // returns: the number of ships sunk by the set of guesses
    public static int Play(string[] ships, string[] guesses)
    {
        var shipList = CreateShips(ships);
        
        Fire(shipList, guesses);

        return ShipsSunk(shipList);
    }

    private static IEnumerable<Ship.Ship> CreateShips(string[] shipDefinitions)
    {
        var shipList = new List<Ship.Ship>();
        foreach (var shipDefinition in shipDefinitions)
        {
            var newShip = new Ship.Ship(shipDefinition);
#warning shipOverlapCheck
            shipList.Add(newShip);
        }

        return shipList;
    }

    private static void Fire(IEnumerable<Ship.Ship> ships, string[] guesses)
    {
        foreach (var guess in guesses)
        {
            foreach (var ship in ships)
            {
                ship.IsHit(guess);
            }
        }
    }

    private static int ShipsSunk(IEnumerable<Ship.Ship> ships)
    {
        int sunkCount = 0;
        foreach (var ship in ships)
        {
            if (ship.IsSunk())
                sunkCount++;
        }

        return sunkCount;
    }
}