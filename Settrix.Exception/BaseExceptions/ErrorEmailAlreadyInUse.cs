using System.Net;

namespace Settrix.Exception.BaseExceptions;

public class ErrorEmailAlreadyInUse : SettrixBaseException
{
    private string ErrorMessage {get; set;}
    
    public ErrorEmailAlreadyInUse(string errorMessage)
    {
        ErrorMessage = errorMessage;       
    }
    
    public override int StatusCode { get; } = (int)HttpStatusCode.Conflict;
    public override List<string> GetErrors()
    {
        return [ErrorMessage];
    }
}