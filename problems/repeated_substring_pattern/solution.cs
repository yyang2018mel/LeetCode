public class Solution 
{
    // "ababababab"
    // "abcabcabc"
    
    private bool IsMultiple(string s, int l)
    {
        var p = s.Substring(0, l);
        for(var i = 0; i < s.Length; i+=p.Length)
        {
            if (s.Substring(i, l) != p) return false;
        }
        return true;
    }
    
    public bool RepeatedSubstringPattern(string s) 
    {
        // check singleton
        if (s.Length == 1) return false;
        
        // check pattern 1
        if (s.All(c => c == s[0])) return true;
        
        // check pattern 2 - len/2
        for(var l = s.Length/2; l >= 2; l--)
        {
            if (s.Length % l == 0)
            {
                if (IsMultiple(s, l))
                    return true;
            }
        }
        
        return false;
    }
}