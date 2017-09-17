namespace Core.SeedWork
{
    public class ValidationResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationResult"/> class.
        /// </summary>
        /// <param name="message"> The message. </param>
        public ValidationResult(string message)
        {
            Message = message;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationResult"/> class.
        /// </summary>
        /// <param name="memberName"> Name of the member. </param>
        /// <param name="message"> The message. </param>
        public ValidationResult(string message, string memberName)
        {
            MemberName = memberName;
            Message = message;
        }

        /// <summary>
        /// Gets or sets the name of the member.
        /// </summary>
        /// <value> The name of the member. May be null for general validation issues. </value>
        public string MemberName { get; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value> The message. </value>
        public string Message { get; }

        #region casts

        public static implicit operator ValidationResult(string message)
        {
            return new ValidationResult(message);
        }

        #endregion casts
    }
}