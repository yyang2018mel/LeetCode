public class Solution 
{
    private bool IsLeftBracket(char c)
    {
        return c == '(' || c == '[' || c == '{';
    }
    
    private bool IsRightBracket(char c)
    {
        return c == ')' || c == ']' || c == '}';
    }
    
    private bool IsPairing(char lhs, char rhs)
    {
        if (lhs == '(' && rhs == ')') return true;
        if (lhs == '[' && rhs == ']') return true;
        if (lhs == '{' && rhs == '}') return true;
        
        return false;
    }
    
    public bool IsValid(string s) 
    {
        if (s.Length % 2 != 0) return false;
        
        var stack = new Stack<char>();
        foreach(var c in s)
        {
            if (IsLeftBracket(c)) 
            {
                stack.Push(c);
                continue;
            }
            
            if (IsRightBracket(c) && stack.TryPeek(out var top) && IsPairing(top, c))
            {
                stack.Pop();    
                continue;
            }
            
            return false;    
            
        }
        
        return (stack.Count == 0);
    }
}