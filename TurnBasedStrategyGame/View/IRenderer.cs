using System.Collections.Generic;
using TBSG.Data;

namespace TBSG.View
{
    public interface IRenderer
    {
        void DrawGrid(IGraphics g, ICamera camera);
        void DrawUnits(IGraphics g, ICamera camera);
        void DrawSelection(IGraphics g, ICamera camera, IEnumerable<HexCoordinate> selection);
    }
}
