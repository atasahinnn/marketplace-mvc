using Marketplace.Business.Abstract;
using Marketplace.Business.Concrete.Utilies.Exceptions;
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
    public class ErrorInformationExceptionFilter : IExceptionFilter
    {
        private IModelMetadataProvider _modelMetadataProvider;
        private readonly ITempDataDictionaryFactory _tempDataFactory;


        public ErrorInformationExceptionFilter(IModelMetadataProvider modelMetadataProvider, ITempDataDictionaryFactory tempDataFactory)
        {
            _modelMetadataProvider = modelMetadataProvider;
            _tempDataFactory = tempDataFactory;
        }

        public void OnException(ExceptionContext context)
        {
            if (context.Exception is ErrorInformation ex)
            {

                var tempData = _tempDataFactory.GetTempData(context.HttpContext);
                tempData.Add("ErrorMessage", context.Exception.Message.ToString());

                context.Result = new ViewResult
                {
                    ViewData = new ViewDataDictionary(_modelMetadataProvider, context.ModelState),
                    TempData = tempData
                };
                context.ExceptionHandled = true;
            }

        }
    }
}
