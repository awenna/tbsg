using System.Collections.Generic;
using TBSG.Data;
using TBSG.Data.Hexmap;
using TBSG.Data.View;
using TBSG.Model.Hexmap;

namespace TBSG.View
{
    public interface IRenderer
    {
        void DrawGrid(IGraphics g, ICameraController cameraController, IMap map);
        void DrawUnits(IGraphics g, ICameraController cameraController, IMap map);
        void DrawSelection(
            IGraphics g,
            ICameraController cameraController,
            ISelection selection, 
            IMap map);

        void DrawInfoGraphics(IGraphics g, ScreenCoord size);
        void DrawMinimap(IGraphics g, ScreenCoord size, ICameraController cameraController);
    }
}
