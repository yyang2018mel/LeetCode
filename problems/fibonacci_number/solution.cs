public class Solution 
{
    public int Fib(int n) 
    {
        if (n == 0) return 0;
        if (n == 1) return 1;
        
        var cache = new int[n+1];
        cache[0] = 0;
        cache[1] = 1;
        for(var i = 2; i <= n; i++)
        {
            cache[i] = cache[i-1] + cache[i-2];
        }
        return cache[n];
    }
}