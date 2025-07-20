namespace Settrix.Exception.BaseExceptions;

public abstract class SettrixBaseException : System.Exception
{
    public abstract int StatusCode { get; }

    public abstract List<string> GetErrors();
}