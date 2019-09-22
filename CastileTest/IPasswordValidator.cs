using System;
using System.Collections.Generic;
using System.Text;

namespace CastileTest
{
    public interface IPasswordValidator
    {
        /// <summary>
        /// Initialize a password validator.
        /// </summary>
        ///
        /// <param name="minLength">The minimum length of the passowrd</param>
        /// <param name="maxLength">The maximum length of the passowrd</param>
        /// <param name="mustContainDigits"><c>true</c> - a password must contain at least 1 digit</param>
        /// <param name="mustContainCapitalLetters"><c>true</c> - a password must contain at least 1 capital letter</param>
        ///
        /// <exception cref="IndexOutOfRangeException">If minLength is lower than or equal to zero</exception>
        /// <exception cref="IndexOutOfRangeException">If maxLength is greater than 255</exception>
        /// <exception cref="ArgumentException">If minLength is greater than maxLength</exception>
        void Initialize(
            int minLength,
            int maxLength,
            bool mustContainDigits,
            bool mustContainCapitalLetters);

        /// <summary>
        /// Validates a provided password
        /// </summary>
        /// <param name="password">A password to validate</param>
        /// <returns>A validator result</returns>
        ValidationResult Validate(string password);
    }
}
