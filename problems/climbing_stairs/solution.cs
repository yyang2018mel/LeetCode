public class Solution 
{
    public int ClimbStairs(int n) 
    {
        if (n == 1) return 1;
        if (n == 2) return 2;
        
        var ways = new int[n+1];
        ways[0] = 1;
        ways[1] = 1;
        ways[2] = 2;
        
        for(var s = 3; s <=n; s++)
        {
            ways[s] = ways[s-1] + ways[s-2];
        }
        
        return ways[n];
    }
}