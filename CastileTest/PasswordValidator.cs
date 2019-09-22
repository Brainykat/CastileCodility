using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CastileTest
{
    public class PasswordValidator : IPasswordValidator
    {
        //private PasswordValidator() { }
        //private PasswordValidator(int minLength, int maxLength, bool mustContainDigits,
        //    bool mustContainCapitalLetters)
        //{
        //    Initialize(minLength, maxLength, mustContainDigits, mustContainCapitalLetters);
        //}
        
        public void Initialize(int minLength, int maxLength, bool mustContainDigits, 
            bool mustContainCapitalLetters)
        {
            if (minLength <= 0) throw new IndexOutOfRangeException(nameof(minLength));
            if (maxLength <= 0) throw new IndexOutOfRangeException(nameof(maxLength));
            if (maxLength > 255) throw new IndexOutOfRangeException(nameof(maxLength));
            if (minLength > maxLength) throw new ArgumentException("Min length cannot be greater than Max length");
            MinLength = minLength;
            MaxLength = maxLength;
            MustContainDigits = mustContainDigits;
            MustContainCapitalLetters = mustContainCapitalLetters;
        }

        public ValidationResult Validate(string password)
        {
            List<ValidationErrorEnum> validationErrorEnums = new List<ValidationErrorEnum>();
            if (string.IsNullOrWhiteSpace(password))
            {
                validationErrorEnums.Add(ValidationErrorEnum.IsEmpty);
            }
            if(password.Length < MinLength)
            {
                validationErrorEnums.Add(ValidationErrorEnum.IsTooShort);
            }
            if(password.Length > MaxLength)
            {
                validationErrorEnums.Add(ValidationErrorEnum.IsTooLong);
            }
            if (MustContainDigits)
            {
                if (!password.Any(char.IsDigit))
                {
                    validationErrorEnums.Add(ValidationErrorEnum.DoesNotContainDigits);
                }
            }
            if (MustContainCapitalLetters)
            {
                if (!password.Any(char.IsUpper))
                {
                    validationErrorEnums.Add(ValidationErrorEnum.DoesNotContainCapitalLetters);
                }
            }
            if (validationErrorEnums.Any())
            {
                return new ValidationResult(false, validationErrorEnums.ToArray());
            }
            else
            {
                return new ValidationResult(true,new ValidationErrorEnum[] { });
            }
        }
        public int MinLength { get; set; }
        public int MaxLength { get; set; }
        public bool MustContainDigits { get; set; }
        public bool MustContainCapitalLetters { get; set; }
    }
}
