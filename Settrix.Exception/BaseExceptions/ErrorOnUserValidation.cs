using System.Net;

namespace Settrix.Exception.BaseExceptions;

public class ErrorOnUserValidation(List<string> errors) : SettrixBaseException
{
    private List<string> Errors {get; set;} = errors;
    public override int StatusCode { get; } = (int)HttpStatusCode.BadRequest;

    public override List<string> GetErrors()
    {
        return Errors;
    }
}