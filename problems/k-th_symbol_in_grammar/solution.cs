public class Solution {
    
    public int KthGrammar(int n, int k) {
        
        if (n == 1)
            return 0;
        
        if (n == 2)
            return k == 1 ? 0 : 1;
        
        var k_nMinus1 = k % 2 == 0 ? k/2 : (k+1)/2;
        
        var ancestor = KthGrammar(n-1, k_nMinus1);
        
        var result = 
            ancestor == 0 
            ? ( k % 2 == 0 ? 1 : 0)
            : ( k % 2 == 0 ? 0 : 1);
        
        return result;
        
    }
}