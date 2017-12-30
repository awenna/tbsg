using TBSG.Data.Hexmap;

namespace TBSG.Data.View
{
    public class Camera
    {
        public WorldCoordinate Location { get; set; }
        public ScreenCoordinate ViewSize { get; set; }
        public int Scale { get; set; }
    }
}
