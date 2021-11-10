public class Solution {
    
    private int?[] memo;
        
    
    private int fib(int n) {
        
        if(memo[n] != null) 
            return memo[n].Value;
        
        var result = 
            n == 0
            ? 0
            : n == 1
                ? 1
                : fib(n-1) + fib(n-2);
        
        memo[n] = result;
        return result;
        
    }
    
    public int Fib(int n) {
        memo = new int?[n+1];
        return fib(n);
    }
}