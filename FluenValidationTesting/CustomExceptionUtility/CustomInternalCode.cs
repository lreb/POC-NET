using System.ComponentModel;

namespace FluenValidationTesting.CustomExceptionUtility
{
    public enum CustomInternalErrors
    {
        [Description("My custom error 1")]
        ErrorOne = 1,
        [Description("My custom error 2")]
        ErrorTwo = 2,
        [Description("Input Validation Errror")]
        InputValidation = 3
    }
}
