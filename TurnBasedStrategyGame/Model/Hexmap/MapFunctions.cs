using System;
using TBSG.Data;
using TBSG.Data.Hexmap;

namespace TBSG.Model.Hexmap
{
    public class MapFunctions : IMapFunctions
    {
        private readonly IAlgorithms mAlgorithms;

        public MapFunctions(IAlgorithms algorithms)
        {
            mAlgorithms = algorithms;
        }

        public double Distance
            (HexCoord startLocation, HexCoord targetLocation, Tag.Range rangeType)
        {
            switch (rangeType)
            {
                case Tag.Range.Absolute:
                    return mAlgorithms.HexDistance(startLocation, targetLocation);
            }
            throw new NotImplementedException();
        }

    }
}
