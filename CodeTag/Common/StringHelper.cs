using System;

namespace CodeTag.Common
{
    /// <summary>
    /// String helper class.
    /// </summary>
    public static class StringHelper
    {
        /// <summary>
        /// Trims the given input string and replaces Unix newlines.
        /// </summary>
        /// <param name="str">Input string.</param>
        /// <returns>Trimmed string with correct newlines.</returns>
        public static string Strip(this string str)
        {
            return string.IsNullOrWhiteSpace(str)
                       ? null
                       : str.Trim().Replace("\r", "").Replace("\n", Environment.NewLine);
        }
    }
}
