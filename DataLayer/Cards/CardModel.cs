namespace DataLayer.Cards
{
    public record CardModel
    {
        public int Id { get; init; }
        public string Name { get; init; } = "";
        public string Description { get; init; } = "";
        public byte[]? Image { get; set; } // Alterado para byte[]
        public DateTime Date { get; init; }
        public int TimeInMinutes { get; init; }
    }
}
