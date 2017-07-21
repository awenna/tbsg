namespace TurnBasedStrategyGame
{
    public interface IMap
    {
        ITile TileAt(HexCoordinate location);
        bool LocationIsWithinBounds(HexCoordinate location);
    }
}
