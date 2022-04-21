public class MyHashSet 
{
    private int _callCount;

    private List<int> internalMemory;
    
    private bool BinarySearch(int key, out int matchOrShouldBe)
    {
        var start = 0;
        var end = internalMemory.Count - 1;
        var mid = 0;
        
        matchOrShouldBe = mid;
        while(start <= end)
        {
            mid = (start+end)/2;
            var midVal = internalMemory[mid];
            if(midVal == key)
            {
                matchOrShouldBe = mid;
                return true;
            }
            else if (midVal > key)
                end = mid - 1;
            else
                start = mid + 1;
        }

        if (start > internalMemory.Count - 1) // should be appended to the back
            matchOrShouldBe = start;
        else if (end < 0) // should be inserted in the front
            matchOrShouldBe = 0;
        else // should be inserted in the middle
        {
            matchOrShouldBe =
                internalMemory[mid] < key
                ? mid + 1 // key needs to go higher
                : mid; // internalMemory[mid] needs to go higher
        }
        
        return false;
    }
    
    public MyHashSet() 
    {
        internalMemory = new List<int>();
    }
    
    public void Add(int key) 
    {
        if(!BinarySearch(key, out var shouldBe))
        {
            internalMemory.Insert(shouldBe, key);
        }
        // otherwise, do nothing
    }
    
    public void Remove(int key) 
    {
        if(BinarySearch(key, out var match))
        {
            internalMemory.RemoveAt(match);
        }
        // otherwise, do nothing
    }
    
    public bool Contains(int key) 
    {
        var result = BinarySearch(key, out _);
        return result;
    }
}

/**
 * Your MyHashSet object will be instantiated and called as such:
 * MyHashSet obj = new MyHashSet();
 * obj.Add(key);
 * obj.Remove(key);
 * bool param_3 = obj.Contains(key);
 */