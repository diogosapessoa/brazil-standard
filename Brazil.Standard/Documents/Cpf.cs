using Brazil.Standard.Extensions;

using System;

namespace Brazil.Standard
{
    /// <summary>
    /// To be added.
    /// </summary>
    public sealed class Cpf : Document
    {
        /// <summary>
        /// To be added.
        /// </summary>
        public override int Length => 11;

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="cpf"></param>
        /// <exception cref="ArgumentException"/>
        /// <exception cref="ArgumentOutOfRangeException"/>
        /// <exception cref="InvalidValueException"/>
        /// <exception cref="FormatException"/>
        public Cpf(string cpf) : base(cpf) { }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="cpf"></param>
        /// <exception cref="ArgumentException"/>
        /// <exception cref="ArgumentOutOfRangeException"/>
        /// <exception cref="InvalidValueException"/>
        /// <exception cref="FormatException"/>
        public Cpf(ulong cpf) : base(cpf) { }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        protected override string Format(string text)
        {
            return text.Insert(9, "-").Insert(6, ".").Insert(3, ".");
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        protected override bool Validate(string text)
        {
            return text.IsCpfValid();
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="cpf"></param>
        /// <exception cref="ArgumentException"/>
        /// <exception cref="ArgumentOutOfRangeException"/>
        /// <exception cref="InvalidValueException"/>
        /// <exception cref="FormatException"/>
        public static explicit operator Cpf(string cpf)
        {
            return new Cpf(cpf);
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="cpf"></param>
        /// <exception cref="ArgumentException"/>
        /// <exception cref="ArgumentOutOfRangeException"/>
        /// <exception cref="InvalidValueException"/>
        /// <exception cref="FormatException"/>
        public static explicit operator Cpf(ulong cpf)
        {
            return new Cpf(cpf);
        }
    }
}
