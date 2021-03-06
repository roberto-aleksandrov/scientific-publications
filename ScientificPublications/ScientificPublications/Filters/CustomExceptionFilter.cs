﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ScientificPublications.Application.Common.Exceptions;
using System;
using System.Net;

namespace ScientificPublications.WebUI.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is ValidationException)
            {
                var exception = context.Exception as ValidationException;

                context.HttpContext.Response.ContentType = "application/json";
                context.HttpContext.Response.StatusCode = (int)exception.ErrorType;
                context.Result = new JsonResult(((ValidationException)context.Exception).Failures);

                return;
            }
            var code = HttpStatusCode.InternalServerError;

            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int)code;
            context.Result = new JsonResult(new
            {
                error = new[] { context.Exception.Message },
                stackTrace = context.Exception.StackTrace
            });
        }
    }
}
