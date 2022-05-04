public class Solution 
{
    public int UniquePaths(int m, int n) 
    {
        var dp = new int[m*n];
        
        for(var i = 0; i < m; i++)
        {
            var row = i*n;
            var prevRow = (i-1)*n;
            for (var j =0; j < n; j++)
            {
                if (i == 0 || j == 0)
                    dp[row+j] = 1;
                else
                    dp[row+j] = dp[prevRow+j] + dp[row+j-1];
            }
        }
        
        return dp[dp.Length-1];
    }
}