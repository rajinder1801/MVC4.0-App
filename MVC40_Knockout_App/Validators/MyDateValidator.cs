using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC40_Knockout_App.Validators
{
    /// <summary>
    /// Validator Class
    /// </summary>
    public class MyDateValidator : ValidationAttribute, IClientValidatable
    {
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            //Can implement this for client side validation.
            throw new NotImplementedException();
        }

        private readonly string _startDate;

        public MyDateValidator(string startDate)
        {
            _startDate = startDate;
        }
        
        /// <summary>
        /// IsValid Override
        /// </summary>
        /// <param name="value">End Date Value</param>
        /// <param name="validationContext"></param>
        /// <returns>Validation Result</returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var propertyInfo = validationContext.ObjectType.GetProperty(_startDate);
            /// Get Start Date Value 
            var startDateValue = propertyInfo.GetValue(validationContext.ObjectInstance, null);
            // init start date 
            var startDate = DateTime.MinValue;
            var endDate = DateTime.MinValue;

            if (DateTime.TryParse(startDateValue.ToString(), out startDate))
            {
                if (DateTime.TryParse(value.ToString(), out endDate))
                {
                    //Check end date is greater than or equal to start date.
                    if (endDate.ToUniversalTime() >= startDate.ToUniversalTime())
                        return ValidationResult.Success;
                    else
                        return new ValidationResult("End Date should be after Start date");
                }
                else
                    return new ValidationResult("End Date is not valid");                
            }
            else
                return new ValidationResult("Start Date is not valid");
        }

    }
}