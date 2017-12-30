using System.Collections.Generic;
using Xunit;
using TBSG.Data.Entities;
using TBSG.Data.Hexmap;
using TBSG.Model.Hexmap;

namespace TBSG.Model
{
    public class TileOccupantsTests
    {
        private TileOccupantsExtension Target;

        public TileOccupantsTests()
        {
            Target = new TileOccupantsExtension();
        }

        [Fact]
        public void Get_NotFound_ReturnsNull()
        {
            var entity = new Entity();

            var result = Target.Get(entity);

            Assert.Null(result);
        }

        [Fact]
        public void Get_Exists_ReturnsTile()
        {
            var entity = new Entity();
            var tile = new Tile();

            Target.GetOccupants().Add(entity, tile);

            var result = Target.Get(entity);

            Assert.Same(tile, result);
        }

        [Fact]
        public void Set_NoPrevious_SetsAnOccupant()
        {
            var entity = new Entity();
            var tile = new Tile();

            Target.Set(entity, tile);

            Assert.Same(tile, Target.GetOccupants()[entity]);
        }

        [Fact]
        public void Set_EntityFound_ChangesOccupantAndRemovesOld()
        {
            var entity = new Entity();
            var oldTile = new Tile();
            var newTile = new Tile();

            Target.GetOccupants().Add(entity, oldTile);

            Target.Set(entity, newTile);

            Assert.Same(newTile, Target.GetOccupants()[entity]);
            Assert.False(Target.GetOccupants().ContainsValue(oldTile));
        }
    }

    internal class TileOccupantsExtension : TileOccupants
    {
        public Dictionary<Entity, Tile> GetOccupants()
        {
            return Occupants;
        }
    }
}
