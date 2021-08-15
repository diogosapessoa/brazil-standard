using Brazil.Standard.Extensions;

using System;

namespace Brazil.Standard
{
    /// <summary>
    /// To be added.
    /// </summary>
    public abstract partial class Document : IStringValue, IEquatable<Document>
    {
        /// <summary>
        /// To be added.
        /// </summary>
        public abstract int Length { get; }

        private string _text;
        /// <summary>
        /// To be added.
        /// </summary>
        public string Text
        {
            get
            {
                if (_text is null)
                    _text = Value.ToString().PadLeft(Length, '0');
                return _text;
            }
        }

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

        private string _formatted;
        /// <summary>
        /// To be added.
        /// </summary>
        public string Formatted
        {
            get
            {
                if (_formatted is null)
                    _formatted = Format(Text);
                return _formatted;
            }
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="text"></param>
        /// <exception cref="ArgumentException"/>
        /// <exception cref="ArgumentOutOfRangeException"/>
        /// <exception cref="InvalidValueException"/>
        /// <exception cref="FormatException"/>
        public Document(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentException();

            _text = text.OnlyDigits();

            if (_text.Length != Length)
                throw new FormatException();

            if (!Validate(_text))
                throw new InvalidValueException();
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="ArgumentException"/>
        /// <exception cref="ArgumentOutOfRangeException"/>
        /// <exception cref="InvalidValueException"/>
        /// <exception cref="FormatException"/>
        public Document(ulong value)
        {
            _value = value;

            if (!Validate(Text))
                throw new InvalidValueException();
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        protected abstract string Format(string text);

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        protected abstract bool Validate(string text);

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Document other)
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
            return Equals(obj as Document);
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
