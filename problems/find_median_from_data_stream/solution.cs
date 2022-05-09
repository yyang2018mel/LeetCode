public class MedianFinder 
{
    
    private int _count;
    
    private PriorityQueue<int, int> _nonTopK; // a min-heap
    
    private PriorityQueue<int, int> _topK; // a max-heap
    
    private int GetExpectedK()
    {
        return _count % 2 == 0 ? _count/2 : _count/2+1;
    }
    
    public MedianFinder() 
    {
        _nonTopK = new PriorityQueue<int, int>();
        _topK = new PriorityQueue<int, int>(Comparer<int>.Create((lhs,rhs) => rhs-lhs));
    }
    
    public void AddNum(int num) 
    {
        _count++;
        _nonTopK.Enqueue(num, num);
        
        var expectedK = GetExpectedK();
        
        if (_topK.Count < expectedK) // the diff should be at most 1
        {
            var e = _nonTopK.Dequeue();
            _topK.Enqueue(e, e);   
        }
        else 
        {
            var maybeKth = _topK.Peek();
            var minNonTopK = _nonTopK.Peek();
            
            if (minNonTopK < maybeKth)
            {
                var e1 = _nonTopK.Dequeue();
                var e2 = _topK.Dequeue();
                
                _nonTopK.Enqueue(e2,e2);
                _topK.Enqueue(e1,e1);
            }
        }
    }
    
    public double FindMedian() 
    {
        if (_count % 2 != 0) // first one of _topK
        {
            return (double)_topK.Peek();
        }
        else // first two of _topK;
        {
            var tmp1 = _topK.Peek();
            var tmp2 = _nonTopK.Peek();
            // _topK.Enqueue(tmp1, tmp1);
            
            return (tmp1+tmp2)/2.0;
        }
    }
}

/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.AddNum(num);
 * double param_2 = obj.FindMedian();
 */