namespace Rei02.Area
{
    internal abstract class AreaBase
    {
        public AreaBase(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public abstract void Add(AreaBase area);

        public abstract IEnumerable<AreaBase> GetChildren();

        public abstract void Alarm();

        public abstract Condition GetCondition();
    }

    internal enum Condition
    {
        Normal,
        Alarm,
    }
}
