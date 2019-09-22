using System;
using System.Collections.Generic;
using System.Text;

namespace CastileTest
{
    public enum ValidationErrorEnum
    {
        IsEmpty, // If a password is an empty string or null
        IsTooShort, // If the length of a password is < minLength
        IsTooLong, // If the length of a password is > maxLength
        DoesNotContainDigits,
        DoesNotContainCapitalLetters
    }
}
