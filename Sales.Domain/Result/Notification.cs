namespace Sales.Domain.Result;

public class Notification
{
    public string Field { get; init; }
    public string Message { get; init; }

    public Notification(string field, string message)
    {
        Field = field;
        Message = message;
    }
}