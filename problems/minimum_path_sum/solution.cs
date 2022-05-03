public class Solution {
    public int MinPathSum(int[][] grid) {
        var m = grid.Length;
        var n = grid[0].Length;
        
        var dp = new int[2*(n+1)];
        var here = 0;
        
        for(var i = 1; i <= m; i++)
        {
            int row_here = i % 2;
            int row_here_start = row_here*(n+1);
            int row_above = row_here == 1 ? 0 : 1;
            int row_above_start = row_above*(n+1);
            for(var j = 1; j <= n; j++)
            {    
                here = row_here_start+j;
                int left = here-1;
                int above = row_above_start +j;
                
                if (i == 1)
                {
                    dp[here] = dp[left]+grid[i-1][j-1];
                }
                else if (j == 1)
                {
                    dp[here] = dp[above]+grid[i-1][j-1];
                }
                else
                {
                    dp[here] = Math.Min(dp[above], dp[left]) + grid[i-1][j-1]; // from left
                }
            }
            
        }
        
        return dp[here];
    }
}