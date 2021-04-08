namespace TradeCategorizer.Models.Base
{
    public interface ITrade
    {
        public double Value { get; }
        public string ClientSector { get; }
    }
}
