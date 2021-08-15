using Brazil.Standard.Extensions;

using System;

namespace Brazil.Standard
{
    public sealed partial class BrazilPhone
    {
        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(BrazilPhone left, BrazilPhone right)
        {
            if (left is null)
                return right is null;
            return left.Equals(right);
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(BrazilPhone left, BrazilPhone right)
        {
            return !(left == right);
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(BrazilPhone left, string right)
        {
            if (left is null)
                return right is null;
            return left.Text == right.OnlyDigits();
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(BrazilPhone left, string right)
        {
            return !(left == right);
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(string left, BrazilPhone right)
        {
            if (left is null)
                return right is null;
            return left.OnlyDigits() == right.Text;
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(string left, BrazilPhone right)
        {
            return !(left == right);
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(BrazilPhone left, ulong right)
        {
            if (left is null)
                return false;
            return left.Value == right;
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(BrazilPhone left, ulong right)
        {
            return !(left == right);
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(ulong left, BrazilPhone right)
        {
            if (right is null)
                return false;
            return left == right.Value;
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(ulong left, BrazilPhone right)
        {
            return !(left == right);
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="phone"></param>
        /// <remarks>
        /// Cast to string 
        /// </remarks>
        public static implicit operator string(BrazilPhone phone)
        {
            return phone?.Text;
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="phone"></param>
        /// <remarks>
        /// Cast to string 
        /// </remarks>
        public static implicit operator ulong(BrazilPhone phone)
        {
            return phone?.Value ?? 0;
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="phone"></param>
        /// <exception cref="ArgumentException"/>
        /// <exception cref="ArgumentOutOfRangeException"/>
        /// <exception cref="FormatException"/>
        public static explicit operator BrazilPhone(string phone)
        {
            return new BrazilPhone(phone);
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="phone"></param>
        /// <exception cref="ArgumentException"/>
        /// <exception cref="ArgumentOutOfRangeException"/>
        /// <exception cref="FormatException"/>
        public static explicit operator BrazilPhone(ulong phone)
        {
            return new BrazilPhone(phone);
        }
    }
}
