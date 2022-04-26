public class Solution 
{
    private HashSet<int> _haveSeen = new HashSet<int>();
    
    private List<int> GetDigits(int n)
    {
        var rem = n / 10;
        var digit = n % 10;
        
        if (rem != 0)
        {
            var result = GetDigits(rem);
            result.Add(digit);
            return result;
        }
        
        return new List<int> { digit };
    }
    
    public bool IsHappy(int n) 
    {
        _haveSeen.Add(n);
        
        var digits = GetDigits(n);
        
        var ssr = 
            digits
            .Select(d => d*d)
            .Sum();
        
        if (ssr == 1) return true;
        
        if (_haveSeen.Contains(ssr)) return false;
        
        return IsHappy(ssr);
    }
}