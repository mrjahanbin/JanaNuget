using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JanaPack.Calculates
{
    public static class Math
    {
        public static decimal Percentage(this decimal value, decimal Percentage)
        {
            var decimalResult = (value * Percentage)/100;
            return decimalResult;
        }
    }
}
