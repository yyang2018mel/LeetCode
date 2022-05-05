public class Solution 
{
    public string ReorganizeString(string s) 
    {
        var charFreq = 
            s
            .GroupBy(c => c)
            .Select(g => (g.Key, g.Count()));
        
        var maxHeapByCharFreq = 
            new PriorityQueue<char, int>(charFreq, Comparer<int>.Create((lhs, rhs) => rhs - lhs ));
        
        char? charJustUsed = null;
        int charJustUsedRemFreq = 0;
        var result = new StringBuilder();
        
        while(maxHeapByCharFreq.TryDequeue(out char topChar, out int topCharFreq))
        {
            result.Append(topChar);
            
            if (charJustUsed is not null && charJustUsedRemFreq > 0)
            {    
                maxHeapByCharFreq.Enqueue(charJustUsed.Value, charJustUsedRemFreq);   
            }
            charJustUsed = topChar;
            charJustUsedRemFreq = topCharFreq - 1;
        }
        
        if (charJustUsedRemFreq > 0) return "";
        
        return result.ToString();
    }
}