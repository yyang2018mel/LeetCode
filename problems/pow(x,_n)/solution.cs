public class Solution {
    
    public double MyPow(double x, int n) {
        return myPow(x, (long)n);
    }
    
    public double myPow(double x, long n) {
        if(x == 0) return 0;
        if(n == 0) return 1;
        if(n < 0) return myPow(1/x, -n);
        
        if(n % 2 == 0) return myPow(x * x, n / 2);
        else return x * myPow(x * x, n / 2);
    }
    
}