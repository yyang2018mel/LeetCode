internal record KeyValue(int Key, int Value);

public class MyHashMap 
{
    
    private readonly int tableSize;
    
    private readonly List<KeyValue>[] separateChain;
    
    public MyHashMap() 
    {
        tableSize = 1000;
        separateChain = new List<KeyValue>[tableSize];
    }
    
    public void Put(int key, int value) 
    {
        var index = key.GetHashCode() % tableSize;
        var chain = separateChain[index];
        
        if(chain is null)
            chain = new List<KeyValue> { new KeyValue(key,value) };
        
        var found = chain.FindIndex(kv => kv.Key == key);
        if(found == -1)
            chain.Add(new KeyValue(key, value));
        else
            chain[found] = chain[found] with { Value = value };
        
        separateChain[index] = chain;
        
    }
    
    public int Get(int key) 
    {
        var index = key.GetHashCode() % tableSize;
        var chain = separateChain[index];
        
        if (chain is null) 
            return -1;
        
        var found = chain.FindIndex(kv => kv.Key == key);
        
        if (found == -1) return -1;
        
        return chain[found].Value;
    }
    
    public void Remove(int key) 
    {
        var index = key.GetHashCode() % tableSize;
        var chain = separateChain[index];
        
        if (chain is not null)
        {
            var found = chain.FindIndex(kv => kv.Key == key);
            if (found != -1)
                chain.RemoveAt(found);
        }
    }
}

/**
 * Your MyHashMap object will be instantiated and called as such:
 * MyHashMap obj = new MyHashMap();
 * obj.Put(key,value);
 * int param_2 = obj.Get(key);
 * obj.Remove(key);
 */