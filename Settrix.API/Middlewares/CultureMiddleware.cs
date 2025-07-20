using System.Globalization;

namespace Settrix.API.Middlewares;

public class CultureMiddleware : IMiddleware
{
    public Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var cultureSelected = context.Request.Headers.AcceptLanguage.FirstOrDefault();

        if (string.IsNullOrWhiteSpace(cultureSelected)) cultureSelected = "en";
        
        try
        {
            var culture = new CultureInfo(cultureSelected);
            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = culture;
        }
        catch (CultureNotFoundException)
        {
            var defaultCulture = new CultureInfo("en");
            CultureInfo.CurrentCulture = defaultCulture;
            CultureInfo.CurrentUICulture = defaultCulture;
        }

        return next(context);
    }
}