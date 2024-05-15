namespace MongoDbSampleApi.Extensions;

public static class ArgumentValidator
{
    public static async Task<TResult> HandleAsync<TResult>(Func<Task<TResult>> function, params object[] args)
        => args.All(Validate) ? await function() : default;

    public static async Task HandleAsync(Func<Task> function, params object[] args)
    {
        if (args.All(Validate))
        {
            await function();
        }
    }

    private static bool Validate(object arg)
        => arg switch
        {
            null => false,
            IEnumerable<object> collection => collection.Any(),
            _ => true
        };
}