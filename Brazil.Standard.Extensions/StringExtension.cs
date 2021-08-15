using System;

namespace Brazil.Standard.Extensions
{
    /// <summary>
    /// To be added.
    /// </summary>
    public static class StringExtension
    {
        static readonly int[] Multiply1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        static readonly int[] Multiply2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="ArgumentOutOfRangeException"/>
        public static string FilterCharacters(this string text, Predicate<char> filter)
        {
            char[] buffer = new char[text.Length];
            int idx = 0;

            foreach (char character in text)
                if (filter(character))
                    buffer[idx++] = character;

            return new string(buffer, 0, idx);
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="ArgumentOutOfRangeException"/>
        public static string OnlyAlphaNumeric(this string text)
        {
            return FilterCharacters(text, c => (c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'));
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="ArgumentOutOfRangeException"/>
        public static string OnlyDigits(this string text)
        {
            return FilterCharacters(text, c => c >= '0' && c <= '9');
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsCpfValid(this string text)
        {
            if (text == null)
                return false;

            int position = 0;
            int totalDigit1 = 0;
            int totalDigit2 = 0;
            int dv1 = 0;
            int dv2 = 0;

            bool equalDigits = true;
            int lastDigit = -1;

            foreach (char c in text)
                if (char.IsDigit(c))
                {
                    int digit = c - '0';
                    if (position != 0 && lastDigit != digit)
                        equalDigits = false;

                    lastDigit = digit;
                    if (position < 9)
                    {
                        totalDigit1 += digit * (10 - position);
                        totalDigit2 += digit * (11 - position);
                    }
                    else if (position == 9)
                        dv1 = digit;
                    else if (position == 10)
                        dv2 = digit;

                    position++;
                }

            if (position > 11)
                return false;

            if (equalDigits)
                return false;

            int digit1 = totalDigit1 % 11;
            digit1 = digit1 < 2 ? 0 : 11 - digit1;

            if (dv1 != digit1)
                return false;

            totalDigit2 += digit1 * 2;
            int digit2 = totalDigit2 % 11;
            digit2 = digit2 < 2 ? 0 : 11 - digit2;

            return dv2 == digit2;
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsCnpjValid(this string text)
        {
            if (text == null)
                return false;

            bool equalDigits = true;
            int lastDigit = -1;
            int position = 0;
            int totalDigit1 = 0;
            int totalDigit2 = 0;

            foreach (char c in text)
                if (char.IsDigit(c))
                {
                    int digit = c - '0';
                    if (position != 0 && lastDigit != digit)
                        equalDigits = false;

                    lastDigit = digit;
                    if (position < 12)
                    {
                        totalDigit1 += digit * Multiply1[position];
                        totalDigit2 += digit * Multiply2[position];
                    }
                    else if (position == 12)
                    {
                        int dv1 = (totalDigit1 % 11);
                        dv1 = dv1 < 2 ? 0 : 11 - dv1;

                        if (digit != dv1)
                            return false;

                        totalDigit2 += dv1 * Multiply2[12];
                    }
                    else if (position == 13)
                    {
                        int dv2 = (totalDigit2 % 11);
                        dv2 = dv2 < 2 ? 0 : 11 - dv2;

                        if (digit != dv2)
                            return false;
                    }

                    position++;
                }

            return position == 14 && !equalDigits;
        }
    }
}
