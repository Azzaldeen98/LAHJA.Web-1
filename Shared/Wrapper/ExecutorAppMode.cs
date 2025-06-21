using Shared.Enums;
using Shared.Settings;

public class ExecutorAppMode
{

    public static async Task<T> ExecuteAsync<T>(Func<Task<T>> ifTrue, Func<Task<T>> ifFalse)
    {
        return await (ApplicationModeService.CurrentMode == ApplicationMode.Production ? ifTrue() : ifFalse());
    }


}
