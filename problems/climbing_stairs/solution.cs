public class Solution {
    
    private int?[] memo;
    
    private int climbStairs(int n) {
        
        if(memo[n] != null) return memo[n].Value;
        
        var result = 
            n == 1 
            ? 1
            : n == 2
                ? 2
                : climbStairs(n-1) + climbStairs(n-2);
            
        
        memo[n] = result;
        return result;
        
    }
    
    public int ClimbStairs(int n) {
        memo = new int?[n+1];
        return climbStairs(n);
    }
}