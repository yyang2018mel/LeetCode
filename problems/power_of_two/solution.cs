public class Solution 
{
    public bool IsPowerOfTwo(int n) 
    {
        if (n == 0) return false;
        
        if (n == Int32.MinValue) return false;
        
        return (n & -n) == n;
    }
}