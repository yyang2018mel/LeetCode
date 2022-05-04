public class Solution 
{
    public int UniquePathsWithObstacles(int[][] obstacleGrid) 
    {
        var r = obstacleGrid.Length;
        var c = obstacleGrid[0].Length;
     
        if (obstacleGrid[0][0] == 1 || obstacleGrid[r-1][c-1] == 1)
            return 0;
        
        int[,] dp = new int[r, c];
        
        for(var i = 0; i < r; i++)
        {
            for(var j = 0; j < c; j++)
            {
                if (obstacleGrid[i][j] == 1)
                {
                    dp[i,j] = 0;
                    continue;
                }
                
                if (i == 0 && j == 0)
                {
                    dp[i,j] = 1;
                }
                else if (i == 0) // first row
                {
                    dp[i,j] = dp[i,j-1];
                }
                else if (j == 0) // first column
                {
                    dp[i,j] = dp[i-1,j];
                }
                else
                {
                    dp[i,j] = dp[i-1,j] + dp[i,j-1];
                }
            }
        }
        
        return dp[r-1,c-1];
        
    }
}