using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;

namespace IMLokesh.StringExtensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Check if a string contains all of the substrings provided.
        /// </summary>
        /// <param name="text">Haystack</param>
        /// <param name="args">Needles</param>
        /// <returns></returns>
        public static bool ContainsAll(this string text, params string[] args)
        {
            return ContainsAll(text, false, args);
        }

        /// <summary>
        /// Check if a string contains all of the substrings provided.
        /// </summary>
        /// <param name="text">Haystack</param>
        /// <param name="ignoreCase">Ignore case while checking (uses InvariantCulture).</param>
        /// <param name="args">Needles</param>
        /// <returns></returns>
        public static bool ContainsAll(this string text, bool ignoreCase, params string[] args)
        {
            text = ignoreCase ? text.ToLowerInvariant() : text;
            args = ignoreCase ? args.Select(s => s.ToLowerInvariant()).ToArray() : args;
            return args.All(text.Contains);
        }

        /// <summary>
        /// Check if a string contains any of the substrings provided.
        /// </summary>
        /// <param name="text">Haystack</param>
        /// <param name="args">Needles</param>
        /// <returns></returns>
        public static bool ContainsAny(this string text, params string[] args)
        {
            return ContainsAny(text, false, args);
        }

        /// <summary>
        /// Check if a string contains any of the substrings provided.
        /// </summary>
        /// <param name="text">Haystack</param>
        /// <param name="ignoreCase">Ignore case while checking (uses InvariantCulture).</param>
        /// <param name="args">Needles</param>
        /// <returns></returns>
        public static bool ContainsAny(this string text, bool ignoreCase, params string[] args)
        {
            text = ignoreCase ? text.ToLowerInvariant() : text;
            args = ignoreCase ? args.Select(s => s.ToLowerInvariant()).ToArray() : args;
            return args.Any(text.Contains);
        }

        /// <summary>
        /// A shortcurt for String.IsNullOrEmpty()
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string str)
        {
            return String.IsNullOrEmpty(str);
        }

        /// <summary>
        /// A shortcurt for String.IsNullOrWhiteSpace()
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string str)
        {
            return String.IsNullOrWhiteSpace(str);
        }

        /// <summary>
        /// Replaces an array of characters in a string with corresponding characters in a different array. Both array lengths must be equal. 
        /// </summary>
        /// <param name="str">String to replace characters in.</param>
        /// <param name="arr">Characters to replace. </param>
        /// <param name="replace">Characters to replace with</param>
        /// <returns></returns>
        public static string ReplaceCharArray(this string str, char[] arr, char[] replace)
        {
            if (arr.Length != replace.Length)
            {
                throw new ArgumentException("Array lengths must be equal.");
            }
            for (var i = 0; i < arr.Length; i++)
            {
                str = str.Replace(arr[i], replace[i]);
            }
            return str;
        }

        /// <summary>
        /// Replaces an array of strings in a string with corresponding strings in a different array. Both array lengths must be equal. 
        /// </summary>
        /// <param name="str">String to replace characters in.</param>
        /// <param name="arr">String to replace. </param>
        /// <param name="replace">Strings to replace with</param>
        /// <returns></returns>
        public static string ReplaceStringArray(this string str, string[] arr, string[] replace)
        {
            if (arr.Length != replace.Length)
            {
                throw new ArgumentException("Array lengths must be equal.");
            }
            for (var i = 0; i < arr.Length; i++)
            {
                str = str.Replace(arr[i], replace[i]);
            }
            return str;
        }

        /// <summary>
        /// Writes the given string in a temp file and opens that file in the default text editor. Useful for quick debugging of large texts. 
        /// </summary>
        /// <param name="str">String to write to temp file. </param>
        public static void WriteToTempFile(this string str)
        {
            var file = Path.GetTempFileName();
            file = Path.ChangeExtension(file, "txt");
            File.WriteAllText(file, str);
            Process.Start(file);
        }

        public static string NormalizeNewLines(this string text, string with = "")
        {
            return text.Replace("\r\n", "\n").Replace("\n", with);
        }
    }
}
