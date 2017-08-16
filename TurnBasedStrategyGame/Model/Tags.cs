namespace TBSG.Model
{
    public static class Tag
    {
        public enum Actions { Move };
        public enum Effects { Movement };
        public enum Target { Self, Another, Ground, SelfAndGround };
        public enum TargetMode { PointTarget, GroundTarget, SelfTarget };
    }
}
