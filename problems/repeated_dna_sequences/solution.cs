public class Solution 
{
    public IList<string> FindRepeatedDnaSequences(string s) 
    {
        var cache = new HashSet<string>();
        var result = new HashSet<string>();
        // brute force -- sliding window
        for(var i = 0;  i < s.Length - 9; i++)
        {
            var sub = s.Substring(i, 10);
            if (!cache.Add(sub))
                result.Add(sub);
        }
        return result.ToList() as IList<string>;
    }
}