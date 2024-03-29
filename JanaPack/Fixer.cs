﻿namespace JanaPack
{
    public static class Fixer
    {

        public static string Fix(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return "";
            }

            text =
                text.Trim();

            while (text.Contains("  "))
            {
                text =
                    text.Replace("  ", " ");
            }

            return text;
        }
    }
}