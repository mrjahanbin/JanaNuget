using System.Globalization;
using System.Text.RegularExpressions;

namespace JanaPack.Converters
{
    public static class DateTimeConvertor
    {

        #region Miladi

        public static DateTime ToMiladiDate(this string value)
        {

            if (string.IsNullOrWhiteSpace(value))
            {
                return new();
            }
            if (value.Length > 10 || value.Length < 5)
            {
                return new();
            }
            var IsLetterOrDigit = value.All(char.IsLetterOrDigit);
            var IsSymbol = value.All(char.IsSymbol);
            var IsPunctuation = value.All(char.IsPunctuation);
            var IsWhiteSpace = value.Contains(' ');

            if (IsLetterOrDigit || IsPunctuation || IsSymbol || IsWhiteSpace)
            {
                return new();
            }

            string ConvertPersianNumberToEng = Regex.Replace(value, "[۰-۹]", x => ((char)(x.Value[0] - '۰' + '0')).ToString());
            int[]? datePart;
            if (ConvertPersianNumberToEng.Contains(','))
            {
                datePart = ConvertPersianNumberToEng.Split(",").Select(d => int.Parse(d)).ToArray();
            }
            else
            {
                datePart = ConvertPersianNumberToEng.Split("/").Select(d => int.Parse(d)).ToArray();
            }

            PersianCalendar pc = new();
            var Result = new DateTime(datePart[0], datePart[1], datePart[2], pc);
            return Result;
        }
        public static DateTime ToMiladiDatetime(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return new();
            }
            if (value.Length > 10 || value.Length < 5)
            {
                return new();
            }
            var IsLetterOrDigit = value.All(char.IsLetterOrDigit);
            var IsSymbol = value.All(char.IsSymbol);
            var IsPunctuation = value.All(char.IsPunctuation);
            var IsWhiteSpace = value.Contains(' ');

            if (IsLetterOrDigit || IsPunctuation || IsSymbol || IsWhiteSpace)
            {
                return new();
            }
            string ConvertPersianNumberToEng = Regex.Replace(value, "[۰-۹]", x => ((char)(x.Value[0] - '۰' + '0')).ToString());
            var datePart = ConvertPersianNumberToEng.Split(new[] { '-', ':', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => int.Parse(d)).ToArray();

            PersianCalendar pc = new();
            var Result = new DateTime(datePart[0], datePart[1], datePart[2], datePart[3], datePart[4], datePart[5], pc);
            return Result;

        }


        public static string ToMiladiYear(this string value)
        {

            if (string.IsNullOrWhiteSpace(value))
            {
                return "";
            }
            if (value.Length > 10 || value.Length < 5)
            {
                return "";
            }
            var IsLetterOrDigit = value.All(char.IsLetterOrDigit);
            var IsSymbol = value.All(char.IsSymbol);
            var IsPunctuation = value.All(char.IsPunctuation);
            var IsWhiteSpace = value.Contains(' ');

            if (IsLetterOrDigit || IsPunctuation || IsSymbol || IsWhiteSpace)
            {
                return "";
            }

            string ConvertPersianNumberToEng = Regex.Replace(value, "[۰-۹]", x => ((char)(x.Value[0] - '۰' + '0')).ToString());
            int[]? datePart;
            if (ConvertPersianNumberToEng.Contains(','))
            {
                datePart = ConvertPersianNumberToEng.Split(",").Select(d => int.Parse(d)).ToArray();
            }
            else
            {
                datePart = ConvertPersianNumberToEng.Split("/").Select(d => int.Parse(d)).ToArray();
            }

            PersianCalendar pc = new();
            var Result = new DateTime(datePart[0], datePart[1], datePart[2], pc);
            return Result.Year.ToString();
        }
        #endregion

        #region Shamsi
        public static string ToShamsi(this DateTime value)
        {

            if (value.Year < 622)
            {
                return "";
            }
            if (value.Year < 622 && value.Month < 3)
            {
                return "";
            }
            if (value.Year < 622 && value.Month < 3 && value.Day < 22)
            {
                return "";
            }

            PersianCalendar pc = new();
            var Result = $"{pc.GetYear(value)}/{pc.GetMonth(value):00}/{pc.GetDayOfMonth(value):00}";
            return Result;
        }
        public static string ToShamsiTime(this DateTime value)
        {
            if (value.Year < 622)
            {
                return "";
            }
            if (value.Year < 622 && value.Month < 3)
            {
                return "";
            }
            if (value.Year < 622 && value.Month < 3 && value.Day < 22)
            {
                return "";
            }

            PersianCalendar pc = new();

            return $"{pc.GetYear(value)}/{pc.GetMonth(value):00}/{pc.GetDayOfMonth(value):00} {pc.GetHour(value)}:{pc.GetMinute(value)}:{pc.GetSecond(value)}";
        }



        public static string ToShamsiYear(this DateTime value)
        {

            if (value.Year < 622)
            {
                return "";
            }
            if (value.Year < 622 && value.Month < 3)
            {
                return "";
            }
            if (value.Year < 622 && value.Month < 3 && value.Day < 22)
            {
                return "";
            }

            PersianCalendar pc = new();
            var Result = pc.GetYear(value).ToString();
            return Result;
        }
        #endregion
    }
}