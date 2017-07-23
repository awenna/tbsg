namespace TBSG.View
{
    public interface IRenderer
    {
        void DrawGrid(IGraphics g, ICamera camera);
        void DrawUnits(IGraphics g, ICamera camera);
    }
}
