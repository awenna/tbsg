using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBSG.Data;
using TBSG.Model;

namespace TBSG.View
{
    public class ViewState
    {
        public IEnumerable<HexCoordinate> Selection { get; set; }
        public Entity SelectedEntity { get; set; }
        public Tile SelectedTile { get; set; }
        public Camera Camera { get; set; }
    }
}
