public class Solution
{
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        var sortedSymbols =
            strs
            .Select((s, i) => (new string(s.OrderBy(e => e).ToArray()), i));

        var groups = new Dictionary<string, IList<string>>();

        foreach(var (symbol, idx) in sortedSymbols)
        {
            var originalStr = strs[idx];

            if(groups.TryGetValue(symbol, out var currentList))
            {
                groups[symbol].Add(originalStr);
            }
            else
            {
                groups[symbol] = new List<string> { originalStr };
            }
        }

        return groups.Values.ToList();
    }
}