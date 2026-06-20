namespace GymApp.Shared.ResultPattern;

public class Result<T>
{
    public T? Value { get; private set; }
    public string? ErrMsg { get; private set; }
    public string? ErrKey { get; private set; }
    public bool IsSuccess { get; private set; }

    public static Result<T> Success(T value)
        => new Result<T>
        {
            Value = value,
            IsSuccess = true
        };
    public static Result<T> Failure(string errMsg , string? errKey = null)
        => new Result<T>
        {
            ErrMsg = errMsg,
            ErrKey = errKey,
            IsSuccess = false
        };
}
