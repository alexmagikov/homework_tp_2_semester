namespace MffFunc;

/// <summary>
/// Fold function.
/// </summary>
public static class Fold
{
    /// <summary>
    /// Fold function.
    /// </summary>
    /// <param name="inputList">Input list.</param>
    /// <param name="currentSum">Current sum.</param>
    /// <param name="function">Function which take current value and sum and return next sum.</param>
    /// <typeparam name="T">Type of list element.</typeparam>
    /// <typeparam name="TSum">Type of sum.</typeparam>
    /// <returns>Result sum.</returns>
    public static TSum FoldFunction<T, TSum>(List<T> inputList, TSum currentSum, Func<T, TSum, TSum> function)
    {
        foreach (var element in inputList)
        {
            currentSum = function(element, currentSum);
        }

        return currentSum;
    }
}