using System.Collections.Generic;
using TBSG.Data;
using TBSG.Data.Hexmap;
using TBSG.Data.View;

namespace TBSG.View
{
    public interface IRenderer
    {
        void DrawGrid(IGraphics g, ICameraController cameraController);
        void DrawUnits(IGraphics g, ICameraController cameraController);
        void DrawSelection(
            IGraphics g,
            ICameraController cameraController,
            ISelection selection);

        void DrawInfoGraphics(IGraphics g, ScreenCoordinate size);
        void DrawMinimap(IGraphics g, ScreenCoordinate size, ICameraController cameraController);
    }
}
