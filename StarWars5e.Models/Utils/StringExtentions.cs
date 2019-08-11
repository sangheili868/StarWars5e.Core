﻿using System.Text.RegularExpressions;

namespace StarWars5e.Models.Utils
{
    public static class StringExtentions
    {
        public static bool HasLeadingHtmlWhitespace(this string input)
        {
            return input.Trim().StartsWith("&emsp;") || input.Trim().StartsWith("&nbsp;");
        }
        public static string RemoveHtmlWhitespace(this string input)
        {
            return input.Replace("&emsp;", string.Empty).Replace("&nbsp;", string.Empty);
        }

        public static string RemoveMarkdownCharacters(this string input)
        {
            return input.Replace(">", string.Empty).Replace("*", string.Empty);
        }

        public static string RemoveUnderscores(this string input)
        {
            return input.Replace("_", string.Empty);
        }

        public static bool IsJustHtmlOrOtherWhitespace(this string input)
        {
            return string.IsNullOrWhiteSpace(input.RemoveHtmlWhitespace());
        }

        public static string FormatKey(this string input)
        {
            input = input.Replace("\\", string.Empty).Replace("/", string.Empty);

            return input;
        }

        public static string ToKebabCase(this string value)
        {
            // Remove apostrophes
            value = Regex.Replace(value, @"[']", string.Empty);

            // Replace all non-alphanumeric characters with a dash
            value = Regex.Replace(value, @"[^0-9a-zA-Z]", "-");

            // Replace all subsequent dashes with a single dash
            value = Regex.Replace(value, @"[-]{2,}", "-");

            // Remove any trailing dashes
            value = Regex.Replace(value, @"-+$", string.Empty);

            // Remove any dashes in position zero
            if (value.StartsWith("-")) value = value.Substring(1);

            // Lowercase and return
            return value.ToLower();
        }

        public static string SplitPascalCase(this string value)
        {
            return Regex.Replace(
                value,
                "([A-Z])",
                " $1",
                RegexOptions.Compiled).Trim();
        }
    }
}
