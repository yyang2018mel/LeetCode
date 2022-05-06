public class Solution 
{
    public int FindKthLargest(int[] nums, int k) 
    {
        var numsWithPriority = 
            nums
            .Select(n => (n,n))
            .ToArray();
        
        var minHeap = 
            new PriorityQueue<int,int>();
        
        for(var i = 0; i < nums.Length; i++)
        {
            if (i < k)
            {
                minHeap.Enqueue(numsWithPriority[i].Item1, numsWithPriority[i].Item2);
            }
            else if (nums[i] > minHeap.Peek())
            {
                minHeap.Dequeue();
                minHeap.Enqueue(numsWithPriority[i].Item1, numsWithPriority[i].Item2);
            }
        }
        
        return minHeap.Peek();
            
    }
}