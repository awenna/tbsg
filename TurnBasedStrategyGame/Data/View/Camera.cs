using TBSG.Data.Hexmap;

namespace TBSG.Data.View
{
    public class Camera
    {
        public WorldCoord Location { get; set; }
        public ScreenCoord ViewSize { get; set; }
        public int Scale { get; set; }
    }
}
