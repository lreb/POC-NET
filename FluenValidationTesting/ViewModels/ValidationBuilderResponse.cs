using FluentValidation.Results;
using FluenValidationTesting.CustomExceptionUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace FluenValidationTesting.ViewModels
{
    public class ValidationBuilderResponse
    {
        public void ValidateUrlParameters(IDictionary<string, object> collection)
        {
            List<ValidationMessagesResponse> response = new List<ValidationMessagesResponse>();

            foreach (var item in collection)
            {
                var one = item;
                if (item.Value is null)
                {
                    response.Add(new ValidationMessagesResponse { Field = item.Key, ErrorMessage = $"Input is null: {item.Value}" });
                }
            }

            if (response.Any())
            {
                throw new CustomException($"{EnumHelper.GetEnumDescription(CustomInternalErrors.InputValidation)}",
                    CustomInternalErrors.InputValidation,
                    (int)HttpStatusCode.BadRequest,
                    response);
            }
        }

        public void ValidateUrlParameters(ValidationResult validation)
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
