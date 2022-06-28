using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marketplace.AspNetCoreMvc.Filters.ExceptionFilters
{
    public class ValidationExceptionFilter : IExceptionFilter
    {
        private IModelMetadataProvider _modelMetadataProvider { get; }

        public ValidationExceptionFilter(IModelMetadataProvider modelMetadataProvider)
        {
            _modelMetadataProvider = modelMetadataProvider;
        }

        public void OnException(ExceptionContext context)
        {
            if (context.Exception is ValidationException ex)
            {
                var validationResult = new ValidationResult(ex.Errors);
                validationResult.AddToModelState(context.ModelState, null);
                context.Result = new ViewResult { ViewData = new ViewDataDictionary(_modelMetadataProvider, context.ModelState) };
                context.ExceptionHandled = true;
            }
        }
    }
}
