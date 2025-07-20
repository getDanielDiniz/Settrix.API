using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Settrix.Comunication.DTO_s.Response;
using Settrix.Exception.BaseExceptions;

namespace Settrix.API.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is SettrixBaseException exception)
        {
            HandleSettrixException(context, exception);
        }
        else
        {
            HandleUnknownException(context);
        }
    }
    
    private void HandleSettrixException(ExceptionContext context, SettrixBaseException exception)
    {
        ResponseSettrixErrorJson response = new(exception.GetErrors());
        context.HttpContext.Response.StatusCode = exception.StatusCode;
        context.Result = new ObjectResult(response);
    }
    private void HandleUnknownException(ExceptionContext context)
    {
        ResponseSettrixErrorJson response = new("Unknown error! Please contact support.");
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Result = new ObjectResult(response);
    }
    
}