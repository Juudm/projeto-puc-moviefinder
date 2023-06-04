namespace moviefinder.exception;

public class ApiException : Exception
{
    public int Codigo { get; set; }
    public List<string> Messages { get; set; }

    public ApiException(string message) : base(message)
    {
    }

    public ApiException(List<string> messages)
    {
        Messages = messages;
    }
}