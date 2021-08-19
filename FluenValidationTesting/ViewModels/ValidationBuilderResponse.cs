using FluentValidation.Results;
using FluenValidationTesting.CustomExceptionUtility;
using System.Collections.Generic;
using System.Net;

namespace FluenValidationTesting.ViewModels
{
    public class ValidationBuilderResponse
    {
        public List<ValidationMessagesResponse> BuildResponse(ValidationResult validation)
        {
            List<ValidationMessagesResponse> response = new List<ValidationMessagesResponse>();

            if (!validation.IsValid)
            {
                foreach (var failure in validation.Errors)
                {
                    response.Add(new ValidationMessagesResponse { Field = failure.PropertyName, ErrorMessage = $"Error was: {failure.ErrorMessage}" });
                }
            }
            
            return response;
        }

        public void ValidateModel(ValidationResult validation)
        {
            if (!validation.IsValid)
            {
                var response = BuildResponse(validation);
                throw new CustomException($"{EnumHelper.GetEnumDescription(CustomInternalErrors.InputValidation)}",
                    CustomInternalErrors.InputValidation,
                    (int)HttpStatusCode.BadRequest,
                    response);
            }
        }
    }
}
