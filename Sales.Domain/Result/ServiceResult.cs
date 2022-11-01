namespace Sales.Domain.Result;

public class ServiceResult
{
    public List<Notification> Errors { get; set; }

    public ServiceResult()
    {
        Errors = new List<Notification>();
    }

    public void AddError(string field, string message)
    {
        Errors.Add(new Notification(field, message));
    }
}


public class ServiceResult<T> : ServiceResult
{
    public T Data { get; set; }

    public ServiceResult() : base()
    {
    }

    public ServiceResult(T data) : base()
    {
        Data = data;
    }

    public ServiceResult<T> WithData(T data)
    {
        Data = data;
        return this;
    }
}