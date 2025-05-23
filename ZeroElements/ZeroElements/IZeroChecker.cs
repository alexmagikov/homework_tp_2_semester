namespace ZeroElements;

/// <summary>
/// Interface to check zero elements.
/// </summary>
/// <typeparam name="T">Type of input element.</typeparam>
public interface IZeroChecker<T>
{
    /// <summary>
    /// Checking zerobility.
    /// </summary>
    /// <param name="value">Input value.</param>
    /// <returns>return true - if zero element, else - false.</returns>
    bool IsZero(T value);
}
