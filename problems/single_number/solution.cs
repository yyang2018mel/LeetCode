using System.Linq;

public class Solution 
{
    public int SingleNumber(int[] nums) 
    {
        var cache = new HashSet<int>();
        foreach(var n in nums)
        {
            if(cache.Contains(n))
                cache.Remove(n);
            else
                cache.Add(n);
        }
        
        return cache.Single();
    }
}