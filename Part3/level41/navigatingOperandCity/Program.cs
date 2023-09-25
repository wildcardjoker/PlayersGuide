var block  = CreateStartingBlock();
var offset = new BlockOffset(2, 0);
Console.WriteLine($"I'm standing at {block}");
Console.WriteLine($"I'm moving with an offset of {offset}");
block += offset;
Console.WriteLine($"Now I'm standing at {block}.\n\nMoving back to my original block");
block = CreateStartingBlock();
Console.WriteLine($"I'm standing at {block}");
var directions = new[] {Direction.North, Direction.East, Direction.South, Direction.West};
foreach (var direction in directions)
{
    Console.WriteLine($"Moving {direction}");
    block += direction;
    Console.WriteLine($"Standing at {block}.");
}

BlockCoordinate CreateStartingBlock() => new (4, 3);

/// <summary>
///     The Block's location
/// </summary>
public record BlockCoordinate(int Row, int Column)
{
    /// <summary>
    ///     Implements the operator +.
    /// </summary>
    /// <param name="coordinate">The coordinate.</param>
    /// <param name="offset">The offset.</param>
    /// <returns>
    ///     A <c>BlockCoordinate</c> with the coordinates matching the original coordinates + the offset.
    /// </returns>
    public static BlockCoordinate operator +(BlockCoordinate coordinate, BlockOffset offset) =>
        new (coordinate.Row + offset.RowOffset, coordinate.Column + offset.ColumnOffset);

    /// <summary>
    ///     Implements the operator +.
    /// </summary>
    /// <param name="coordinate">The coordinate.</param>
    /// <param name="direction">The direction.</param>
    /// <returns>
    ///     A <c>BlockCoordinate</c> with the coordinates matching the original coordinates after moving in the specified
    ///     direction.
    /// </returns>
    public static BlockCoordinate operator +(BlockCoordinate coordinate, Direction direction) =>
        direction switch
        {
            Direction.North => coordinate with {Row = coordinate.Row       - 1},
            Direction.East  => coordinate with {Column = coordinate.Column + 1},
            Direction.South => coordinate with {Row = coordinate.Row       + 1},
            Direction.West  => coordinate with {Column = coordinate.Column - 1},
            _               => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };

    #region Overrides of Object
    /// <inheritdoc />
    public override string ToString() => $"Row {Row}, Col {Column}";
    #endregion
}

/// <summary>
///     The relative distance between two blocks
/// </summary>
public record BlockOffset(int RowOffset, int ColumnOffset)
{
    /// <inheritdoc />
    public override string ToString() => $"Row {RowOffset}, Col {ColumnOffset}";
}

/// <summary>
///     The direction to move
/// </summary>
public enum Direction
{
    // ReSharper disable MissingXmlDoc
    North,
    East,
    South,
    West

    // ReSharper restore MissingXmlDoc
}