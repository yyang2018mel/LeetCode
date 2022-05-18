public class Solution 
{
    private int[] _nums;
    
    private int Rob(int startIdx, int endIdx)
    {
        var cacheLen = endIdx-startIdx+1;
        var cache = new int[cacheLen];
        
        var i = startIdx;
        while(i <= endIdx)
        {
            if (i == startIdx)
            {
                cache[i-startIdx] = _nums[i];        
            }
            else if (i == startIdx+1)
            {
                cache[i-startIdx] = Math.Max(_nums[i], _nums[i-1]);
            }
            else
            {
                cache[i-startIdx] = Math.Max(
                    _nums[i] + cache[(i-2)-startIdx],
                    cache[(i-1)-startIdx]
                );
            }
            i++;
        }
        return cache[cache.Length-1];
    }
    
    public int Rob(int[] nums) 
    {
        
        if(nums.Length <= 2) return nums.Max();
        
        _nums = nums;
        
        var start0 = Rob(0, nums.Length-2);
        var start1 = Rob(1, nums.Length-1);
        
        return Math.Max(start0, start1);
        
    }
}