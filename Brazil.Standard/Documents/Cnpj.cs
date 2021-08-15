using Brazil.Standard.Extensions;

using System;

namespace Brazil.Standard
{
    /// <summary>
    /// To be added.
    /// </summary>
    public sealed class Cnpj : Document
    {
        /// <summary>
        /// To be added.
        /// </summary>
        public override int Length => 14;

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="cnpj"></param>
        /// <exception cref="ArgumentException"/>
        /// <exception cref="ArgumentOutOfRangeException"/>
        /// <exception cref="InvalidValueException"/>
        /// <exception cref="FormatException"/>
        public Cnpj(string cnpj) : base(cnpj) { }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="cnpj"></param>
        /// <exception cref="ArgumentException"/>
        /// <exception cref="ArgumentOutOfRangeException"/>
        /// <exception cref="InvalidValueException"/>
        /// <exception cref="FormatException"/>
        public Cnpj(ulong cnpj) : base(cnpj) { }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        protected override string Format(string text)
        {
            return text.Insert(12, "-").Insert(8, "/").Insert(5, ".").Insert(2, ".");
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        protected override bool Validate(string text)
        {
            return text.IsCnpjValid();
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="cnpj"></param>
        /// <exception cref="ArgumentException"/>
        /// <exception cref="InvalidValueException"/>
        /// <exception cref="FormatException"/>
        public static explicit operator Cnpj(string cnpj)
        {
            return new Cnpj(cnpj);
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="cnpj"></param>
        /// <exception cref="ArgumentException"/>
        /// <exception cref="ArgumentOutOfRangeException"/>
        /// <exception cref="InvalidValueException"/>
        /// <exception cref="FormatException"/>
        public static explicit operator Cnpj(ulong cnpj)
        {
            return new Cnpj(cnpj);
        }
    }
}
