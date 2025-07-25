namespace Settrix.Comunication.DTO_s.Response;

public class ResponseSettrixErrorJson
{
    public List<string> Errors { get; set; }

    public ResponseSettrixErrorJson(List<string> errors)
    {
        Errors = errors;       
    }
    public ResponseSettrixErrorJson(string error)
    {
        Errors = [error];       
    }
}