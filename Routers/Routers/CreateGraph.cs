namespace Routers;

/// <summary>
/// Create graph by path.
/// </summary>
public class CreateGraph
{
    /// <summary>
    /// Read file and create adjency list by data in file.
    /// </summary>
    /// <param name="path">Path of the file.</param>
    /// <returns>Graph in dictionary format.</returns>
    /// <exception cref="FormatException">Invalid format of data.</exception>
    public static Dictionary<int, List<(int Router, int LengthOfEdge)>> ReadFile(string path)
    {
        Dictionary<int, List<(int, int)>> resultGraph = new();

        using var reader = new StreamReader(path);
        foreach (var buffer in reader.ReadToEnd().Split('\n'))
        {
            var parts = buffer.Split(':');
            if (parts.Length != 2)
            {
                throw new FormatException("Invalid file format");
            }

            var key = int.Parse(parts[0]);
            var valueParts = parts[1].Split(['(', ',', ')'], StringSplitOptions.RemoveEmptyEntries);
            if (valueParts.Length == 0 || valueParts.Length % 2 != 0)
            {
                throw new FormatException("Invalid file format");
            }

            for (var i = 0; i < valueParts.Length; i += 2)
            {
                var router = int.Parse(valueParts[i].Trim());
                var lengthOfEdge = int.Parse(valueParts[i + 1].Trim());
                if (resultGraph.ContainsKey(key))
                {
                    resultGraph[key].Add((router, lengthOfEdge));
                }
                else
                {
                    resultGraph[key] = [(router, lengthOfEdge)];
                }
            }
        }

        return resultGraph;
    }
}