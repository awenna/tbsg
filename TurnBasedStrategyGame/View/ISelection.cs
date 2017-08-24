using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBSG.Data;

namespace TBSG.View
{
    public interface ISelection
    {
        Entity GetEntity();
        Tile GetTile();
        void Set(Tile tile);
        void Set(Entity entity);
        bool Exists();
        void Clear();
    }
}
