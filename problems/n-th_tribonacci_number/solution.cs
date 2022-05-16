public class Solution 
{
    public int Tribonacci(int n) 
    {
        if (n == 0) return 0;
        if (n == 1 || n == 2) return 1;
        
        var cache = new int[n+1];
        cache[0] = 0;
        cache[1] = 1;
        cache[2] = 1;
        for(var i = 3; i <= n; i++)
            cache[i] = cache[i-1] + cache[i-2] + cache[i-3];
        
        return cache[n];
    }
}