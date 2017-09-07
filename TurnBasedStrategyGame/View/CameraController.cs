using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBSG.Data;

namespace TBSG.View
{
    public class CameraController : ICameraController
    {
        public Camera Camera { get; set; }

        private readonly IAlgorithms mAlgorithms;
        private readonly IConfigurationProvider mConfigurationProvider;

        public CameraController
            (IAlgorithms algorithms, IConfigurationProvider configurationProvider)
        {
            mAlgorithms = algorithms;
            mConfigurationProvider = configurationProvider;

            Camera = new Camera();
            Camera.Scale = mConfigurationProvider.GetValue<int>("CameraScaleDefault");
            Camera.Location = XY.World(0, 0);
        }

        public void MoveBy(WorldCoordinate amount)
        {
            Camera.Location += amount;
        }

        public IEnumerable<HexCoordinate> GetHexesInView()
        {
            var start = mAlgorithms.WorldToHex(Camera.Location, Camera.Scale);

            var size = mAlgorithms.ScreenToWorld(Camera.ViewSize, Camera.Location);
            var end = mAlgorithms.WorldToHex(size, Camera.Scale);

            return mAlgorithms.Get2DRange(start - XY.Hex(1, 1), end + XY.Hex(1, 1));
        }

        public Camera GetCamera()
        {
            return Camera;
        }

        public void SetViewSize(ScreenCoordinate size)
        {
            Camera.ViewSize = size;
        }
    }
}
