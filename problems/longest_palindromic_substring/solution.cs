public class Solution {
    
    public string LongestPalindrome(string s) 
    {
        var cache = new Dictionary<int, HashSet<(int,int)>>();
        for(var l = 1; l <= s.Length; l++)
        {
            cache[l] = new HashSet<(int,int)>();    
        }
        
        var maxL = 1;
        
        for(var l = 1; l <= s.Length; l++)
        {
            if (l == 1)
            {
                cache[l] = 
                    Enumerable.Range(0,s.Length)
                    .Select(e => (e,e))
                    .ToHashSet();
                continue;
            }
            
            foreach (var (palStart, palEnd) in cache[l-1])
            {
                var existingPalLen = l-1;
                var candidates = new List<(int,int)>();
                
                if (palStart > 0)
                {
                    var candidateStart = palStart - 1;
                    candidates.Add((candidateStart, palEnd));
                }
                    
                if (palEnd < s.Length-1)
                {
                    var candidateEnd = palEnd + 1;
                    candidates.Add((palStart, candidateEnd));
                }
                    
                if (palStart > 0 && palEnd < s.Length-1)
                {
                    var candidateStart = palStart - 1;
                    var candidateEnd = palEnd + 1;
                    candidates.Add((candidateStart, candidateEnd));
                }
                    
                foreach(var candidate in candidates)
                {
                    var (canStart, canEnd) = candidate;
                    var canLen = canEnd - canStart + 1;
                    var isPal = false;
                    
                    if (canLen <= 3)
                    {
                        isPal = s[canStart] == s[canEnd];
                    }
                    else 
                    {
                        isPal = 
                            s[canStart] == s[canEnd] &&
                            cache[canLen-2].Contains((canStart+1, canEnd-1));
                    }
                    
                    if (isPal)
                    {
                        cache[canLen].Add((canStart, canEnd));
                        maxL = Math.Max(maxL, canEnd-canStart+1);
                    }
                        
                }
            }
        }
        
        var longestKey = maxL;
        
        var (longestPalAnyStart, longestPalAnyEnd) = cache[longestKey].ToList()[0];
        
        var longestPalAny = s.Substring(longestPalAnyStart, longestPalAnyEnd-longestPalAnyStart+1);
        
        return longestPalAny;
    }
}