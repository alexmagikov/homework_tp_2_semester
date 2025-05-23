namespace ZeroElements;

/// <summary>
/// Calculate zero elements.
/// </summary>
public static class CalculationZeroElements
{
    /// <summary>
    /// Do calculation zero elements.
    /// </summary>
    /// <typeparam name="T">Type of inputList.</typeparam>
    /// <param name="list">Input List.</param>
    /// <param name="zeroChecker">Object type interface, which check nullability.</param>
    /// <returns>Number of zero elements.</returns>
    /// <exception cref="ArgumentNullException">If uncorrected input data.</exception>
    public static int CalculateZeroElements<T>(List<T> list, IZeroChecker<T> zeroChecker)
    {
        if (list == null || zeroChecker == null)
        {
            throw new ArgumentNullException();
        }

        int count = 0;
        foreach (var item in list)
        {
            if (zeroChecker.IsZero(item))
            {
                count++;
            }
        }

        return count;
    }
}
