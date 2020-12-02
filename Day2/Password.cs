namespace Day2
{
    public abstract class Password
    {
        /// <summary>
        /// Character to search for.
        /// </summary>
        public char Character { get; set; }

        /// <summary>
        /// The input password.
        /// </summary>
        public string PasswordText { get; set; }

        /// <summary>
        /// Checks, whether the password is valid.
        /// </summary>
        /// <returns>True if password is a valid password that meets the criteria, false otherwise</returns>
        public abstract bool IsValid { get; }
    }
}
