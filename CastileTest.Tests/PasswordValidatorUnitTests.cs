using System;
using Xunit;

namespace CastileTest.Tests
{
    public class PasswordValidatorUnitTests
    {
        

        // Do not change.
        // This is your SUT (System Under Test) which should be used in tests.
        // It is not null but it is not initialized i.e. Initialize method was not called.
        public IPasswordValidator ValidatorToTest { get; set; } = new PasswordValidator();
        // All your test methods should be public, have no parameters and be marked with [CustomFact] attribute
        //[CustomFact]
        [Fact]
        public void PasswordValidator_Detects_Null()
        {
            
            ValidatorToTest.Initialize(10, 45, true, false);
            var res = ValidatorToTest.Validate("");
            Assert.False(res.IsCorrect);
            Assert.NotNull(res.Errors);
            Assert.Contains(ValidationErrorEnum.IsEmpty, res.Errors);
        }
        [Fact]
        public void PasswordValidator_Detects_MinimumLength()
        {

            ValidatorToTest.Initialize(10, 45, true, false);
            var res = ValidatorToTest.Validate("A");
            Assert.False(res.IsCorrect);
            Assert.NotNull(res.Errors);
            Assert.Contains(ValidationErrorEnum.IsTooShort, res.Errors);
        }
        [Fact]
        public void PasswordValidator_Detects_MaxLength()
        {

            ValidatorToTest.Initialize(1, 3, true, false);
            var res = ValidatorToTest.Validate("Abcde");
            Assert.False(res.IsCorrect);
            Assert.NotNull(res.Errors);
            Assert.Contains(ValidationErrorEnum.IsTooLong, res.Errors);
        }
        [Fact]
        public void PasswordValidator_Detects_NoDigit()
        {

            ValidatorToTest.Initialize(2, 45, true, false);
            var res = ValidatorToTest.Validate("ABC");
            Assert.False(res.IsCorrect);
            Assert.NotNull(res.Errors);
            Assert.Contains(ValidationErrorEnum.DoesNotContainDigits, res.Errors);
        }
        [Fact]
        public void PasswordValidator_Detects_NoUpperCase()
        {

            ValidatorToTest.Initialize(2, 45, true, true);
            var res = ValidatorToTest.Validate("abc");
            Assert.False(res.IsCorrect);
            Assert.NotNull(res.Errors);
            Assert.Contains(ValidationErrorEnum.DoesNotContainDigits, res.Errors);
        }
        [Fact]
        public void PasswordValidator_Satifies()
        {

            ValidatorToTest.Initialize(2, 5, true, true);
            var res = ValidatorToTest.Validate("Abc1");
            Assert.True(res.IsCorrect);
            Assert.NotNull(res.Errors);
        }
    }

}
