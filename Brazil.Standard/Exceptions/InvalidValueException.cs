using System;
using System.Runtime.Serialization;

namespace Brazil.Standard
{
    /// <summary>
    /// To be added.
    /// </summary>
    public class InvalidValueException : Exception
    {
        /// <summary>
        /// To be added.
        /// </summary>
        public InvalidValueException() { }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="message"></param>
        public InvalidValueException(string message) : base(message) { }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public InvalidValueException(string message, Exception innerException) : base(message, innerException) { }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected InvalidValueException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
