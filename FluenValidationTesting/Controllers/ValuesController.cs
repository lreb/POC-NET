using FluentValidation.Results;
using FluenValidationTesting.CustomExceptionUtility;
using FluenValidationTesting.Models;
using FluenValidationTesting.Validators;
using FluenValidationTesting.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FluenValidationTesting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // POST api/<ValuesController>
        [HttpPost, Route("")]
        public async Task<IActionResult> Post([FromBody] ValueInput value, string a, int b, bool c, decimal d)
        {
            // custom validation service
            ValidationBuilderResponse response = new ValidationBuilderResponse();

            // build input dictionary with all url parameters
            IDictionary<string, object> inp = new Dictionary<string,object>();
            inp.Add("a", a);
            inp.Add("b", b);
            inp.Add("c", c);
            response.ValidateUrlParameters(inp);

            // throw custom exception
            throw new CustomException($"{EnumHelper.GetEnumDescription(CustomInternalErrors.ErrorOne)}",
                    CustomInternalErrors.ErrorOne,
                    (int)HttpStatusCode.InternalServerError);

            // validate input
            // initialize validator
            ValueInputValidator validator = new ValueInputValidator();
            //validate
            ValidationResult results = validator.Validate(value);
            
            response.ValidateModel(results);

            return Ok();
        }
    }
}
