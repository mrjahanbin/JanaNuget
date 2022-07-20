using System;
using System.Globalization;
using System.Linq;

namespace JanaPack.Converters
{
    public static class NumberConvertor
    {
        #region ToPercent
        public static decimal ToPercent(this decimal value)
        {
            var decimalResult = decimal.Round(value, 4, MidpointRounding.ToZero);
            return decimalResult;
        }

        public static string ToPercentString(this decimal value, bool? WithSeparator = true)
        {
            
            var decimalResult = decimal.Round(value, 4, MidpointRounding.ToZero);
            string? Stringresult = "";
            if (WithSeparator.GetValueOrDefault())
            {
                Stringresult = Convert.ToDecimal(decimalResult).ToString("#,#.####", CultureInfo.InvariantCulture);

            }
            else
            {
                Stringresult = Convert.ToDecimal(decimalResult).ToString("#.####", CultureInfo.InvariantCulture);

            }
            return Stringresult;

        }
        public static decimal ToPercent(this decimal value, int? Point = 4)
        {
            try
            {
                var decimalResult = decimal.Round(value, Point.GetValueOrDefault(), MidpointRounding.ToZero);
                return decimalResult;
            }
            catch (Exception)
            {

                return 0;
            }
        }
        #endregion

        #region ToCurrency
        public static decimal ToDecimal(this decimal value, int? Point = 4)
        {
            try
            {
                var decimalResult = decimal.Round(value, Point.GetValueOrDefault(), MidpointRounding.ToZero);
                return decimalResult;
            }
            catch (Exception)
            {

                return 0;
            }
        }
        public static string ToCurrency(this decimal value, string? Format = "#,0")
        {
            try
            {
                if (Format == null)
                {
                    Format = "";
                }
                if (Format.All(Char.IsNumber) && !string.IsNullOrWhiteSpace(Format))
                {
                    return "";
                }
                var result = string.Empty;
                if (value.ToString().Contains('.'))
                {
                    var FormatSplit = Format.Split(".");
                    int Pointcount = 0;
                    if (FormatSplit.Length > 1)
                    {
                        Pointcount = FormatSplit[1].Length;
                    }

                    var decimalResult = decimal.Round(value, Pointcount, MidpointRounding.ToZero);



                    //نمیدونم چطوری کار میکنه اما جواب میده!!
                    //int count = BitConverter.GetBytes(decimal.GetBits(decimalResult)[3])[2];
                    var PointFormat = "";
                    for (int i = 0; i < Pointcount; i++)
                    {
                        PointFormat += "#";
                    }

                    result = Convert.ToDecimal(decimalResult).ToString($"{FormatSplit[0]}.{PointFormat}", CultureInfo.InvariantCulture);

                    //var resultSplit = result.Split(".");
                    //result = $"{resultSplit[0]}.{resultSplit[1].Remove(Pointcount)}";
                    //if (result.EndsWith("."))
                    //{
                    //    result = result.Replace(".", "");
                    //}

                }
                else
                {
                    result = Convert.ToDecimal(value).ToString(Format, CultureInfo.InvariantCulture);
                }




                if (!result.All(Char.IsNumber) && !(result.Contains(',') || result.Contains('.')))
                {
                    return "";
                }
                if (result == "0" || result == ".00" || result == "0.00" || result == "0.0")
                {
                    return "";
                }
                if (result.StartsWith("."))
                {
                    result = "0" + result;
                }
                return result;
            }
            catch (Exception)
            {

                return "";
            }

        }
        #endregion




    }
}