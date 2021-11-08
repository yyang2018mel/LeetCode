public class Solution {
    
    private void reverseString(int startIdx, int endIdx, char[] s) {
        
        if(endIdx - startIdx <= 0) return;
        
        (s[startIdx], s[endIdx]) = (s[endIdx], s[startIdx]);
        reverseString(startIdx+1, endIdx-1, s);
        
    }
    
    public void ReverseString(char[] s) {
        reverseString(0, s.Length-1, s);
    }
}