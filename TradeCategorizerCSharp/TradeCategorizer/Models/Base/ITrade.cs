using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeCategorizer.Models.Base
{
    public interface ITrade
    {
        public double Value { get; }
        public string ClientSector { get; }
    }
}
