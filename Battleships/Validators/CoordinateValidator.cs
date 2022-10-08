using System.Text.RegularExpressions;

namespace Battleships.Validators;

public class CoordinateValidator
{
    public bool Validate(string coordinate)
    {
        var regex = @"/^\d+(,\d+)*$/";
        var match = Regex.Match(coordinate, regex, RegexOptions.IgnoreCase);

        if (!match.Success)
        {
            return false;
        }

        return true;
    }
}