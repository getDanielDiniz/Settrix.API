using System.Net;

namespace Settrix.Exception.BaseExceptions;

public class ErrorUnauthorized : SettrixBaseException
{
    private string ErrorMessage { get; set; }
    
    public ErrorUnauthorized( string errorMessage)
    {
        ErrorMessage = errorMessage;
    }

    public override int StatusCode { get; } = (int)HttpStatusCode.Unauthorized;
    public override List<string> GetErrors()
    {
        return [ErrorMessage];
    }
}