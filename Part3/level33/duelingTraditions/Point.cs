// duelingTraditions

namespace duelingTraditions;

internal record Point(int Row, int Column)
{
    #region Overrides of Object
    /// <inheritdoc />
    public override string ToString() => $"(Row={Row}, Column={Column})";
    #endregion
}