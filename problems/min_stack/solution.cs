public class MinStack 
{

    private List<(int number, int minWithout)> _cache;
    private int _currentMin; 
    
    public MinStack() 
    {
        _cache = new List<(int number, int minWithout)>();
        _currentMin = Int32.MaxValue;
    }
    
    public void Push(int val) 
    {
        var newMin = Math.Min(val, _currentMin); 
        _cache.Add((val, _currentMin));
        _currentMin = newMin;
    }
    
    public void Pop() 
    {
        var removed = _cache[_cache.Count-1];
        _cache.RemoveAt(_cache.Count-1);
        _currentMin = removed.minWithout;
    }
    
    public int Top() 
    {
        return _cache[_cache.Count-1].number;
    }
    
    public int GetMin() 
    {
        return _currentMin;
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(val);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */