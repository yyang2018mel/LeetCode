public class Solution {
    public bool IsPalindrome(int x) {
     
        if (x < 0) return false;
        
        var cum = 0L;
        var base_ = 1L;
        var inversed = new List<long>();
        var i = 1;
        while(cum < x) {
            var newBase = (long)Math.Pow(10,i);
            var bloated = x % newBase - cum; 
            var digit = bloated / base_;
            
            inversed.Add(digit);
            cum += digit*base_;
            base_ = newBase;
            i++;
        }
        
        var adjustedBase = base_ / 10L;
        
        var reversed = 
            inversed
            .Select((v,i) => {
               return v * adjustedBase / (int)Math.Pow(10,i);
            })
            .Sum();
        
        Console.WriteLine(reversed);
        
        return (int)reversed == x;
    }
}