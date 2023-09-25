namespace navigatingOperandCity;

/// <summary>
///     The Block's location
/// </summary>
public record BlockCoordinate(int Row, int Column);

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