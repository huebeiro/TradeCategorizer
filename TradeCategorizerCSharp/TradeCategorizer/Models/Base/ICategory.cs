using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeCategorizer.Models.Base
{
    public interface ICategory
    {
        public Func<ITrade, bool> CheckCondition { get; }
        public string Risk { get; }
    }
}
