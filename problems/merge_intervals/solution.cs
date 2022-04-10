public class Solution 
{
    private bool Overlap(int[] lhs, int[] rhs)
    {
        return lhs[1] >= rhs[0];
    }
    
    private int[] Merge(int[] lhs, int[] rhs)
    {
        var upper = Math.Max(lhs[1], rhs[1]);
        return new int[] { lhs[0], upper };
    }
    
    public int[][] Merge(int[][] intervals) 
    {
        Array.Sort(intervals, (lhs, rhs) =>
        {
            var lhsStart = lhs[0];
            var rhsStart = rhs[0];
            return lhsStart.CompareTo(rhsStart);
        });
        
        List<int[]> merged = new List<int[]>();
        int[] currentInterval = intervals[0];
        
        foreach(var interval in intervals)
        {
            if(Overlap(currentInterval, interval))
            {
                currentInterval = Merge(currentInterval, interval);
            }
            else
            {
                merged.Add(currentInterval);
                currentInterval = interval;
            }
        }
        
        merged.Add(currentInterval);
        
        return merged.ToArray();
    }
}