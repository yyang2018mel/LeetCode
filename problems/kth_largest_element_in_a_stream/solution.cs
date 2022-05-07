public class KthLargest 
{
    private PriorityQueue<int, int> _minHeap;
    private int _k;
    private int _kthLargest;
    
    private int GetOrUpdateKthLargest(int newVal)
    {
        if (_minHeap.Count < _k)
        {
            _minHeap.Enqueue(newVal, newVal);
        }
        else if (_minHeap.TryPeek(out var kthMaybe, out _) && newVal > kthMaybe)
        {
            _minHeap.Dequeue();
            _minHeap.Enqueue(newVal, newVal);
        }
        
        return
            _minHeap.Count > 0
            ? _minHeap.Peek()
            : Int32.MinValue;
    }
    
    
    public KthLargest(int k, int[] nums) 
    {
        _k = k;
        
        _minHeap =  new PriorityQueue<int, int>();
        
        for(var i = 0; i < nums.Length; i++)
            GetOrUpdateKthLargest(nums[i]);
        
    }
    
    public int Add(int val) 
    {
        return GetOrUpdateKthLargest(val);
    }
}

/**
 * Your KthLargest object will be instantiated and called as such:
 * KthLargest obj = new KthLargest(k, nums);
 * int param_1 = obj.Add(val);
 */