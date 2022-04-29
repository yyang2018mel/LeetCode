public class Solution 
{
    public int LengthOfLastWord(string s) 
    {
        var pointer = s.Length-1;
        
        while(s[pointer] == ' ')
            pointer--;
        
        var lastWordEnd = pointer;
        pointer--;
        
        while(pointer >= 0 && s[pointer] != ' ')
            pointer--;
        
        return lastWordEnd - pointer;
    }
}