using System.Globalization;
using System.Text.RegularExpressions;

namespace JanaPack.Converters
{
    public static class NumberConvertor
    {
        #region Shamsi
        public static decimal ToPercent(this decimal value)
        {
            var Stringresult = value.ToString("0.####");
            var decimalResult = decimal.Parse(Stringresult);
            return decimalResult;
        }



        #endregion
    }
}