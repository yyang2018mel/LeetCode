public class Solution 
{
    public int CountSubstrings(string s) 
    {
        var palindromeSubs = new (int,int)[s.Length][];
        
        for(var subLen = 1; subLen <= s.Length; subLen++)
        {
            if (subLen == 1)
            {
                var base1 = Enumerable.Range(0, s.Length)
                            .Select(i => (i,i))
                            .ToArray();    
                palindromeSubs[0] = base1;
            }
            else if (subLen == 2)
            {
                var base2 = Enumerable.Range(0, s.Length-1)
                            .Select(i => (i,i+1))
                            .Where(pair => s[pair.Item1] == s[pair.Item2])
                            .ToArray();        
                palindromeSubs[1] = base2;
            }
            else
            {
                var basei = 
                    palindromeSubs[subLen-2-1]
                    .Where(pair => 
                    {
                        var (start, end) = pair;
                        return (start-1 >= 0 && end + 1 < s.Length && s[start-1] == s[end+1]); 
                    })
                    .Select(pair => 
                    {
                        var (start, end) = pair;
                        return (start-1, end+1);
                    })
                    .ToArray();
                palindromeSubs[subLen-1] = basei;
            }
        }
        
        var result = 
            palindromeSubs
            .Select(subArr => subArr.Length)
            .Sum();
        
        return result;
    }
}