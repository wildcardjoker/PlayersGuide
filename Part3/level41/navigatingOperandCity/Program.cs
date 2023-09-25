namespace navigatingOperandCity;

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
}

/// <summary>
///     The relative distance between two blocks
/// </summary>
public record BlockOffset(int RowOffset, int ColumnOffset);

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