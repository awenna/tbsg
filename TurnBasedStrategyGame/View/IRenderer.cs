using System.Collections.Generic;
using TBSG.Data;

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
    }
}
