using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using TBSG.Data;

namespace TBSG
{
    public class Camera : ICamera
    {
        private WorldCoordinate mLocation;
        private ScreenCoordinate mViewSize;
        private int mScale;

        private readonly IAlgorithms mAlgorithms;
        private readonly IConfigurationProvider mConfigProvider;


        public Camera(IAlgorithms algorithms, IConfigurationProvider configProvider)
        {
            mAlgorithms = algorithms;
            mLocation = new WorldCoordinate(0, 0);
            mConfigProvider = configProvider;

            mScale = configProvider.GetValue<int>("CameraScaleDefault");
        }

        public void MoveBy(WorldCoordinate amount)
        {
            mLocation = mLocation + amount;
        }

        public Tuple<HexCoordinate, HexCoordinate> GetHexesInView()
        {
            var start = mAlgorithms.WorldToHex(mLocation, mScale);

            var size = mAlgorithms.ScreenToWorld(mViewSize, mLocation);
            var end = mAlgorithms.WorldToHex(size, mScale);

            return Tuple.Create(start, end);
        }

        #region Getters

        public WorldCoordinate GetLocation()
        {
            return mLocation;
        }

        public int GetScale()
        {
            return mScale;
        }

        #endregion

        #region Setters

        public void SetSize(ScreenCoordinate size)
        {
            mViewSize = size;
        }

        public void SetSize(Size size)
        {
            mViewSize = new ScreenCoordinate(size.Width, size.Height);
        }

        #endregion

    }
}
