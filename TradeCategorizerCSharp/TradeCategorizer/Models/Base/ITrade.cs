namespace TradeCategorizer.Models.Base
{
    /// <summary>
    /// An interface that represents a trade
    /// </summary>
    public interface ITrade
    {
        public double Value { get; }
        public string ClientSector { get; }
    }
}
