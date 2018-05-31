namespace TBSG.Data.Abilities
{
    public class Cost
    {
        public Tag.Cost Type { get; }
        public int Value { get; }

        public Cost (Tag.Cost type, int value)
        {
            Type = type;
            Value = value;
        }
    }
}
