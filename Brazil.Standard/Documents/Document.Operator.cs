using Brazil.Standard.Extensions;

namespace Brazil.Standard
{
    public partial class Document
    {
        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Document left, Document right)
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
        public static bool operator !=(Document left, Document right)
        {
            return !(left == right);
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Document left, string right)
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
        public static bool operator !=(Document left, string right)
        {
            return !(left == right);
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(string left, Document right)
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
        public static bool operator !=(string left, Document right)
        {
            return !(left == right);
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Document left, ulong right)
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
        public static bool operator !=(Document left, ulong right)
        {
            return !(left == right);
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(ulong left, Document right)
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
        public static bool operator !=(ulong left, Document right)
        {
            return !(left == right);
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="document"></param>
        /// <remarks>
        /// Cast to string 
        /// </remarks>
        public static implicit operator string(Document document)
        {
            return document?.Text;
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="document"></param>
        /// <remarks>
        /// Cast to string 
        /// </remarks>
        public static implicit operator ulong(Document document)
        {
            return document?.Value ?? 0;
        }
    }
}
