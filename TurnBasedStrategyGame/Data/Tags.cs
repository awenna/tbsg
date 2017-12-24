﻿namespace TBSG.Data
{
    public static class Tag
    {
        public enum Actions { Move };
        public enum Effects { Movement };
        public enum Target { Self, Another, Ground, SelfAndGround };
        public enum TargetMode { PointTarget, GroundTarget, SelfTarget };
        public enum Cost { ActionPoint };
    }
}
