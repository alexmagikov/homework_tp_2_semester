namespace MffFunc;

/// <summary>
/// Filter func.
/// </summary>
public static class Filter
{
    /// <summary>
    /// Filter function.
    /// </summary>
    /// <param name="inputList">Input list.</param>
    /// <param name="function">Input function.</param>
    /// <typeparam name="T">Type of list element.</typeparam>
    /// <returns>Result list.</returns>
    public static List<T> FilterFunction<T>(List<T> inputList, Func<T, bool> function)
    {
        var newList = new List<T>();
        foreach (T element in inputList)
        {
            if (function(element))
            {
                newList.Add(element);
            }
        }

        return newList;
    }
}