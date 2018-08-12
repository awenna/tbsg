using System;

namespace TBSG.Data
{
    [Serializable]
    public static class Tag
    {
        public enum Actions { Move }
        public enum Effects { Movement }
        public enum Range { Absolute }
        public enum Target { Self, Another, Ground, SelfAndGround }
        public enum TargetMode { PointTarget, GroundTarget, SelfTarget }
        public enum Limitation { Range, EmptyTile }
        public enum Cost { ActionPoint }
    }
}
