using System;
using System.Collections.Generic;
using System.Text;

namespace CastileTest
{
    public class ValidationResult
    {
        public ValidationResult(bool isCorrect = true, ValidationErrorEnum[] errors = default)
        {
            IsCorrect = isCorrect;
            Errors = errors;
        }

        /// <summary>
        /// Returns <c>true</c> only if a password matches all the rules
        /// </summary>
        public bool IsCorrect { get; set; }

        /// <summary>
        /// If <c>IsCorrect</c> is <c>true</c> then this property returns an empty arrray.
        /// Otherwise it returns all found errors. Errors cannot be duplicated.
        /// This property must not be null.
        /// </summary>
        public ValidationErrorEnum[] Errors { get; set; }
    }
}
