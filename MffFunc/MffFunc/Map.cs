namespace MffFunc;

/// <summary>
/// Map func.
/// </summary>
public static class Map
{
    /// <summary>
    /// Map function: create new list by list and function.
    /// </summary>
    /// <param name="inputList">Input list.</param>
    /// <param name="function">Input function.</param>
    /// <typeparam name="T">Type of elements of list.</typeparam>
    /// <typeparam name="TResult">Type of function.</typeparam>
    /// <returns>New list.</returns>
    public static List<TResult> MapFunction<T, TResult>(List<T> inputList, Func<T, TResult> function)
    {
        var newList = new List<TResult>();
        foreach (var element in inputList)
        {
            newList.Add(function(element));
        }

        return newList;
    }
}