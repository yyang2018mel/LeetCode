public class Solution 
{
    public int[] TopKFrequent(int[] nums, int k) 
    {
        var numFreq = 
            nums
            .GroupBy(n => n)
            .Select(g => (g.Key, g.Count()))
            .ToArray();
            
        var minHeap = 
            new PriorityQueue<int, int>();
        
        for(var i = 0; i < numFreq.Length; i++)
        {
            var (num, freq) = numFreq[i];
            if (i < k)
            {
                minHeap.Enqueue(num, freq);
            }
            else if (minHeap.TryPeek(out _, out var freq_) && freq_ < freq)
            {
                minHeap.Dequeue();
                minHeap.Enqueue(num, freq);
            }
        }
        
        return minHeap.UnorderedItems.Select(i => i.Item1).ToArray();
    }
}