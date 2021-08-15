using Brazil.Standard.Extensions;

using System;

namespace Brazil.Standard
{
    /// <summary>
    /// To be added.
    /// </summary>
    public sealed partial class BrazilPhone : IPhoneNumber, IEquatable<BrazilPhone>
    {
        /// <summary>
        /// To be added.
        /// </summary>
        public const string BrazilCode = "55";

        /// <summary>
        /// To be added.
        /// </summary>
        public int Length => Text.Length;

        /// <summary>
        /// To be added.
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// To be added.
        /// </summary>
        public bool IsMobile => Text[2] >= '6';

        private ulong? _value;
        /// <summary>
        /// To be added.
        /// </summary>
        public ulong Value
        {
            get
            {
                if (_value is null)
                    _value = ulong.Parse(Text.TrimStart('0'));
                return _value.Value;
            }
        }

        private byte? _areaCode;
        /// <summary>
        /// To be added.
        /// </summary>
        public byte AreaCode
        {
            get
            {
                if (!_areaCode.HasValue)
                    _areaCode = Convert.ToByte(Text.Substring(0, 2));
                return _areaCode.Value;
            }
        }

        private string _formatted;
        /// <summary>
        /// To be added.
        /// </summary>
        public string Formatted
        {
            get
            {
                if (_formatted is null)
                    _formatted = Text.Insert(0, "(").Insert(3, ")").Insert(Length - 2, "-");
                return _formatted;
            }
        }

        private string _international;
        /// <summary>
        /// To be added.
        /// </summary>
        public string International
        {
            get
            {
                if (_international is null)
                    _international = $"+{BrazilCode}{Text}";
                return _international;
            }
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="phone"></param>
        /// <exception cref="ArgumentException"/>
        /// <exception cref="ArgumentOutOfRangeException"/>
        /// <exception cref="FormatException"/>
        public BrazilPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                throw new ArgumentException();

            if (phone.Length <= 3)
                throw new FormatException();

            if (phone.StartsWith("+"))
            {
                if (phone.Substring(1, 2) != BrazilCode)
                    throw new FormatException();

                phone = phone.Substring(3, phone.Length - 3);
            }

            Text = phone.OnlyDigits();

            if (Text.Length < 10 || Text.Length > 11)
                throw new FormatException();
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="phone"></param>
        /// <exception cref="ArgumentException"/>
        /// <exception cref="ArgumentOutOfRangeException"/>
        /// <exception cref="FormatException"/>
        public BrazilPhone(ulong phone) : this(phone.ToString()) { }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(BrazilPhone other)
        {
            if (other is null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (GetType() != other.GetType())
                return false;

            return other.Text == Text;
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as BrazilPhone);
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Text.GetHashCode();
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Text;
        }
    }
}
