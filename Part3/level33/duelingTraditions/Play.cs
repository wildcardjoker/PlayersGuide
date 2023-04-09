// duelingTraditions

namespace duelingTraditions;

internal static partial class DuelingTraditions
{
    private static bool AtEntrance()         => _currentLocation == _entranceLocation;
    private static bool AtFountainLocation() => _currentLocation == _fountainLocation;

    private static bool CanMove(Direction direction) => (direction    == Direction.North && _currentLocation.Row    != Min)
                                                        || (direction == Direction.South && _currentLocation.Row    != _max)
                                                        || (direction == Direction.West  && _currentLocation.Column != Min)
                                                        || (direction == Direction.East  && _currentLocation.Column != _max);

    private static string? EnableFountain()
    {
        if (!AtFountainLocation())
        {
            return "You cannot touch the fountain. Your command has no effect.";
        }

        // Activate the Fountain
        _fountainIsActive = true;
        WaterText.SetItem(FountainActive);
        return string.Empty;
    }

    private static string Move(Direction direction)
    {
        // Is this a valid move?
        if (!CanMove(direction))
        {
            return "A wall blocks your path. You cannot move in that direction.";
        }

        // Update the current location based on the desired direction.
        _currentLocation = direction switch
        {
            Direction.North   => _currentLocation with {Row = _currentLocation.Row       - 1},
            Direction.South   => _currentLocation with {Row = _currentLocation.Row       + 1},
            Direction.East    => _currentLocation with {Column = _currentLocation.Column + 1},
            Direction.West    => _currentLocation with {Column = _currentLocation.Column - 1},
            Direction.Unknown => throw new ArgumentOutOfRangeException(nameof(direction), direction, null),
            _                 => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };

        // If this location contains a maelstrom, move the player and maelstrom
        if (PlayerEncounteredMaelstrom())
        {
            TriggerMaelstromBattle();
        }

        return string.Empty;
    }

    private static bool NearSpecialLocation(ICollection<Point> specialLocations)
    {
        // Modified from https://www.royvanrijn.com/blog/2019/01/longest-path/
        // TODO: Incorporate into a Function library - this is a really useful method!
        // Create a 3x3 grid
        // 0 1 2
        // 3 4 5
        // 6 7 8
        for (var direction = 0; direction < 9; direction++)
        {
            if (direction == 4)
            {
                continue; // Skip 4, this is the middle (our location).
            }

            // Using mod 3 will convert the row/column values to between 0-2
            // 0 1 2     -1 0 1
            // 0 1 2  => -1 0 1
            // 0 1 2     -1 0 1

            // Subtracting 1 will set the range to -1 - 1
            // 0 0 0     -1 -1 -1
            // 1 1 1  =>  0  0  0
            // 2 2 2      1  1  1

            // With 0 marking the middle, we can use these values to determine the neighbouring values
            var nRow = _currentLocation.Row    + (direction / 3 - 1);
            var nCol = _currentLocation.Column + (direction % 3 - 1);

            // Check the bounds:
            if (nRow >= 0 && nRow < (int) _worldSize && nCol >= 0 && nCol < (int) _worldSize)
            {
                var neighbour = new Point(nRow, nCol);
                if (!specialLocations.Contains(neighbour))
                {
                    continue;
                }

                // We found a pit - no need to iterate through the remaining neighbours
                return true;
            }
        }

        return false;
    }

    private static void ParseCommand()
    {
        DescriptiveText.SetItem(string.Empty);
        Prompt?.Display(false);
        var input = Command.GetInput();
        var result = input?.ToLower() switch
        {
            "move north"      => Move(Direction.North),
            "move south"      => Move(Direction.South),
            "move east"       => Move(Direction.East),
            "move west"       => Move(Direction.West),
            "shoot north"     => Shoot(Direction.North),
            "shoot south"     => Shoot(Direction.South),
            "shoot east"      => Shoot(Direction.East),
            "shoot west"      => Shoot(Direction.West),
            "enable fountain" => EnableFountain(),
            "help"            => DisplayHelp(),
            _                 => "invalid command"
        };

        if (string.IsNullOrWhiteSpace(result))
        {
            return;
        }

        // There was a problem processing the command - display an error message.
        Error?.SetItem(result);
        Error?.Display();
    }

    private static bool PLayerEncounteredAmarok()    => _amarokLocations.Contains(_currentLocation);
    private static bool PlayerEncounteredMaelstrom() => _maelstromLocations.Contains(_currentLocation);
    private static bool PlayerIsInPit()              => _pitLocations.Contains(_currentLocation);

    private static string Shoot(Direction direction)
    {
        if (_numberOfArrows == 0)
        {
            Error.SetItem("You don't have any more arrows.");
            Error.Display();
            return string.Empty;
        }

        var targetLocation = direction switch
        {
            Direction.North   => _currentLocation with {Row = Math.Clamp(_currentLocation.Row       - 1, 0, _max)},
            Direction.South   => _currentLocation with {Row = Math.Clamp(_currentLocation.Row       + 1, 0, _max)},
            Direction.East    => _currentLocation with {Column = Math.Clamp(_currentLocation.Column + 1, 0, _max)},
            Direction.West    => _currentLocation with {Column = Math.Clamp(_currentLocation.Column - 1, 0, _max)},
            Direction.Unknown => throw new ArgumentOutOfRangeException(nameof(direction), direction, null),
            _                 => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };
        _maelstromLocations.Remove(targetLocation);
        _amarokLocations.Remove(targetLocation);
        _numberOfArrows--;
        return string.Empty;
    }

    private static void TriggerMaelstromBattle()
    {
        // Move maelstrom 1 South, 2 West
        _maelstromLocations.Remove(_currentLocation);
        var row = Math.Clamp(_currentLocation.Row    + 1, 0, _max);
        var col = Math.Clamp(_currentLocation.Column - 2, 0, _max);
        _maelstromLocations.Add(new Point(row, col));

        // Move player 1 North, 2 East
        row              = Math.Clamp(_currentLocation.Row    - 1, 0, _max);
        col              = Math.Clamp(_currentLocation.Column + 2, 0, _max);
        _currentLocation = new Point(row, col);
        DisplayDescriptiveText(MaelstromPlayerMoved);
    }
}