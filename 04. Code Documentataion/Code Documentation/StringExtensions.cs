namespace Telerik.ILS.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    public static class StringExtensions
    {
        /// <summary>
        /// Gets MD5 hash code of a string
        /// </summary>
        /// <param name="input">This instance</param>
        /// <returns>Retursn MD5 hash code of a string</returns>
        public static string ToMd5Hash(this string input)
        {           
            var md5Hash = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new StringBuilder to collect the bytes
            // and create a string.
            var builder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return builder.ToString();
        }

        /// <summary>
        /// Converts the string representation of a boolean
        /// </summary>
        /// <param name="input">This instance</param>
        /// <returns>The string representation of a boolean</returns>
        public static bool ToBoolean(this string input)
        {
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
            return stringTrueValues.Contains(input.ToLower());
        }

        /// <summary>
        /// Converts the string representation of a number to its <see cref="System.Int16"/> signed integer equivalent
        /// </summary>
        /// <param name="input">String to convert</param>
        /// <returns>Returns 16-bit signed integer or 0 if it's not valid</returns>
        public static short ToShort(this string input)
        {           
            short shortValue;
            short.TryParse(input, out shortValue);
            return shortValue;
        }

        /// <summary>
        /// Converts the string representation of a number to <see cref="System.Int32"/> 
        /// </summary>
        /// <param name="input">This instance</param>
        /// <returns><see cref="System.Int32"/> if convertion is successfull, otherwise returns 0</returns>
        public static int ToInteger(this string input)
        {           
            int integerValue;
            int.TryParse(input, out integerValue);
            return integerValue;
        }

        /// <summary>
        /// Converts the string representation of a number to <see cref="System.Int64"/>
        /// </summary>
        /// <param name="input">This instance</param>
        /// <returns><see cref="System.Int64"/> if convertion is possible, otherwise returns 0 </returns>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);
            return longValue;
        }

        /// <summary>
        /// Converts the string representation of a Date to <see cref="System.DateTime"/>
        /// </summary>
        /// <param name="input">This instance</param>
        /// <returns> <see cref="System.DateTime"/> if convertion is possible, otherwise returns 01.01.0001 00:00:00</returns>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);
            return dateTimeValue;
        }

        /// <summary>
        /// Capitalize first letter of the a string
        /// </summary>
        /// <param name="input">The string to capitalize</param>
        /// <returns>String with capitalized first letter</returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1, input.Length - 1);
        }

        /// <summary>
        /// Retrives a substring between <paramref name="strarString"/> and <paramref name="endString"/> , starting from <paramref name="startFrom"/> 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="startString">Starting string</param>
        /// <param name="endString">Ending string</param>
        /// <param name="startFrom">Position to start</param>
        /// <returns></returns>
        public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);
            startFrom = 0;
            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        /// Converts a string with cyrillic letters to string with corresponding latin letters 
        /// </summary>
        /// <param name="input">This instance</param>
        /// <returns>A string with cyrillic letters to string with corresponding latin letters </returns>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
                                       {
                                           "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                                           "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
                                       };
            var latinRepresentationsOfBulgarianLetters = new[]
                                                             {
                                                                 "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                                                                 "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                                                                 "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
                                                             };
            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(bulgarianLetters[i].ToUpper(), latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        /// Converts a string with latin letters to string with corresponding cyrillic letters 
        /// </summary>
        /// <param name="input">This instance</param>
        /// <returns>A string with latin letters to string with corresponding cyrillic letters</returns>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
                                   {
                                       "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                                       "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
                                   };

            var bulgarianRepresentationOfLatinKeyboard = new[]
                                                             {
                                                                 "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                                                                 "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                                                                 "в", "ь", "ъ", "з"
                                                             };

            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }

        /// <summary>
        /// Returns a string in which all cyrillic letters is replaced with their corresponding latin letters and non-alphanumeric symbols and "." symbol are removed.
        /// </summary>
        /// <param name="input">This instance</param>
        /// <returns>A string in which all cyrillic letters is replaced with their corresponding latin letters and non-alphanumeric symbols and "." symbol are removed.</returns>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        /// <summary>
        /// Returns a string in which all space symbols are reaplced with hyphen, cyrillic symbols are replaced with their corresponding latin symbols, non-alphanumeric symbols, "." and "-" symbols are removed
        /// </summary>
        /// <param name="input">This instance</param>
        /// <returns>a string in which all space symbols are reaplced with hyphen, cyrillic symbols are replaced with their corresponding latin symbols, non-alphanumeric symbols, "." and "-" symbols are removed</returns>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }
        
        /// <summary>
        /// Retrives speciefied number of characters of a string. 
        /// </summary>
        /// <param name="input">This instance</param>
        /// <param name="charsCount">Count of characters to get</param>
        /// <returns></returns>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            return input.Substring(0, Math.Min(input.Length, charsCount));            
        }

        /// <summary>
        /// Gets file extension of a string (interpreted like file name)
        /// </summary>
        /// <param name="fileName">This instance</param>
        /// <returns>File extension of a string (interpreted like file name) if exists, otherwise returns empty string</returns>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }
            
            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        /// Gets the content type of given extension
        /// </summary>
        /// <param name="fileExtension">The extention to get the content type</param>
        /// <returns>Returns the content type of given extension or "application/octet-stream" if can't find the content type </returns>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
                                                 {
                                                     { "jpg", "image/jpeg" },
                                                     { "jpeg", "image/jpeg" },
                                                     { "png", "image/x-png" },
                                                     {
                                                         "docx",
                                                         "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                                                     },
                                                     { "doc", "application/msword" },
                                                     { "pdf", "application/pdf" },
                                                     { "txt", "text/plain" },
                                                     { "rtf", "application/rtf" }
                                                 };
            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }

        /// <summary>
        /// Returns an array of bytes of a string  
        /// </summary>
        /// <param name="input">This instance</param>
        /// <returns> An array of bytes of a string </returns>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }
    }
}
