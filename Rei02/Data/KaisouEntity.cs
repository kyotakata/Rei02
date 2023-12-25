namespace Rei02.Buhin.Data
{
    internal sealed class KaisouEntity
    {
        public KaisouEntity(int id, int pearentId, int kind, string name)
        {
            Id = id;
            PearentId = pearentId;
            Kind = kind;
            Name = name;
        }

        public int Id { get; }
        public int PearentId { get; }
        public int Kind { get; }
        public string Name { get; }

    }
}
