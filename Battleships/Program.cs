namespace Battleships;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        var ships = new[] { "3:2,3:5", "3:7,5:7" };
        var guesses = new[] { "7:0", "3:3", "3:7", "4:7", "5:7" };
        Game.Play(ships, guesses);
    }
}