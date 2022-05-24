public class Solution 
{
    // "(()"
    // ")()())"
    // ""
    // "()(()()()("
    // "()(()"
    // "((()())()())"
    // "((((((())))))"
    // "(((((((()))()))))"
    // "())"
    // "))()(())))"
    public int LongestValidParentheses(string s) 
    {
        var stack = new Stack<(char Character, int Idx)>();
        
        for(var i = 0; i < s.Length; i++)
        {
            var c = s[i];
            if (c == ')' && stack.TryPeek(out var top) && top.Character == '(')
                stack.Pop();
            else
                stack.Push((c,i));
        }
        
        if (stack.Count == 0) return s.Length;
        
        var remainings = new List<int>();
        remainings.Add(s.Length);
        while(stack.Count > 0)
        {
            remainings.Add(stack.Pop().Idx);
        }
        remainings.Add(-1);
        remainings.Reverse();
            
        var longestSubLen = 0;
        for(var i = 0; i < remainings.Count-1; i++)
        {
            var currentIdx = remainings[i];
            var nextIdx = remainings[i+1];
            longestSubLen = Math.Max(longestSubLen, nextIdx-currentIdx-1);
        }
        
        return longestSubLen;
    }
}