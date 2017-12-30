using Xunit;
using TBSG.Data.Entities;
using TBSG.Data.Hexmap;
using TBSG.Data.View;

namespace TBSG.View
{
    public class SelectionTests
    {
        private readonly Selection Target;

        public SelectionTests()
        {
            Target = new Selection();
        }

        [Fact]
        public void Set_NullEntity_DoesNotSelect()
        {
            Target.Set((Entity)null);

            Assert.Null(Target.Entity);
        }

        [Fact]
        public void Set_NullTile_DoesNotSelect()
        {
            Target.Set((Tile)null);

            Assert.Null(Target.Tile);
        }

        [Fact]
        public void Set_NullEntity_Deselects()
        {
            Target.Entity =  new Entity();
            Target.Tile = new Tile();

            Target.Set((Entity)null);

            Assert.Null(Target.Entity);
            Assert.Null(Target.Tile);
        }

        [Fact]
        public void Set_NullTile_Deselects()
        {
            Target.Entity = new Entity();
            Target.Tile = new Tile();

            Target.Set((Tile)null);

            Assert.Null(Target.Entity);
            Assert.Null(Target.Tile);
        }

        [Fact]
        public void Exists_NothingSet_DoesNotExist()
        {
            Assert.False(Target.Exists());
        }
    }
}
