using TradeCategorizer.Models.Base;

namespace TradeCategorizer.Models
{
    public class Trade : ITrade
    {
        private double _value;
        private string _clientSector;

        public Trade(double value, string clientSector)
        {
            _value = value;
            _clientSector = clientSector;
        }

        public double Value => _value;

        public string ClientSector => _clientSector;
    }
}
