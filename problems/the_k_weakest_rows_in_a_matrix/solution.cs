public class Solution 
{
    internal record Priority(int soliders, int rank);
    
    private Priority GetPriority(int[] row, int rowIndex)
    {
        var soliders = 0;
        for(var i = 0; i < row.Length; i++)
        {
            if (row[i] == 0) break;
            soliders++;
        }
        return new Priority(soliders, rowIndex);
    }
    
    public int[] KWeakestRows(int[][] mat, int k) 
    {
        var rowWithPriority = 
            mat
            .Select((m,i) => (i, GetPriority(m, i)));
        
        var comparer = 
            Comparer<Priority>.Create((lhs,rhs) => 
              {
                  if (lhs.soliders == rhs.soliders)
                      return lhs.rank - rhs.rank;
                  return lhs.soliders - rhs.soliders;
              });
        
        
        var minHeap = 
            new PriorityQueue<int, Priority>(rowWithPriority, comparer);
        
        var result = 
            Enumerable.Range(0,k)
            .Select(_ => minHeap.Dequeue())
            .ToArray();
        
        return result;
    }
}