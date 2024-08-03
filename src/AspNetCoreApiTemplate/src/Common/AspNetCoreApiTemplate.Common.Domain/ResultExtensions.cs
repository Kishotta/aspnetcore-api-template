namespace AspNetCoreApiTemplate.Common.Domain;

public static class ResultExtensions
{
    public static async Task<Result<T>> Then<T>(this Task<Result> resultTask, Func<Task<Result<T>>> func)
    {
        var result = await resultTask;
        return result.IsSuccess ? await func() : Result.Failure<T>(result.Error);
    }
    
    public static async Task<Result<T>> Then<T>(this Task<Result<T>> resultTask, Func<T, Result<T>> func)
    {
        var result = await resultTask;
        return result.IsSuccess ? func(result.Value) : Result.Failure<T>(result.Error);
    }
    
    public static async Task<Result<T>> Do<T>(this Task<Result<T>> resultTask, Func<T, Task> action)
    {
        var result = await resultTask;
        if (!result.IsSuccess) return Result.Failure<T>(result.Error);
        
        await action(result.Value);
        return result;
    }
    
    public static async Task<Result<TOut>> Transform<TIn, TOut>(this Task<Result<TIn>> resultTask, Func<TIn, TOut> func)
    {
        var result = await resultTask;
        return result.IsSuccess ? Result.Success(func(result.Value)) : Result.Failure<TOut>(result.Error);
    }
    
    public static TOut Match<TOut>(
        this Result result,
        Func<TOut> onSuccess,
        Func<Result, TOut> onFailure)
    {
        return result.IsSuccess ? onSuccess() : onFailure(result);
    }

    public static TOut Match<TIn, TOut>(
        this Result<TIn> result,
        Func<TIn, TOut> onSuccess,
        Func<Result<TIn>, TOut> onFailure)
    {
        return result.IsSuccess ? onSuccess(result.Value) : onFailure(result);
    }
}