namespace Brazil.Standard
{
    /// <summary>
    /// To be added.
    /// </summary>
    public interface IPhoneNumber : IStringValue
    {
        /// <summary>
        /// To be added.
        /// </summary>
        byte AreaCode { get; }

        /// <summary>
        /// To be added.
        /// </summary>
        bool IsMobile { get; }

        /// <summary>
        /// To be added.
        /// </summary>
        string International { get; }
    }
}
