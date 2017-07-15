using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedStrategyGame
{
    public class Camera : ICamera
    {
        private WorldCoordinate mLocation;
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

        public Coordinate GetHexesInView()
        {
            var start = mAlgorithms.GetWorldToGridCoordinate(mLocation, mScale);
            var end = mAlgorithms.GetWorldToGridCoordinate(mLocation, mScale);

            throw new NotImplementedException();
        }

        #region Getters

        public WorldCoordinate GetLocation()
        {
            return mLocation;
        }

        #endregion
    }
}
