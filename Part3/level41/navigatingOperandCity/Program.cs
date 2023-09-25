var block  = new BlockCoordinate(4, 3);
var offset = new BlockOffset(2, 0);
Console.WriteLine($"I'm standing at {block}");
Console.WriteLine($"I'm moving with an offset of {offset}");
block += offset;
Console.WriteLine($"Now I'm standing at {block}");

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