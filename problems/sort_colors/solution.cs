public class Solution 
{
    public void SortColors(int[] nums) 
    {
        var cache = new int[3];
        foreach(var n in nums)
            cache[n] += 1;
        
        var reconstructedIdx = 0;
        
        for(var i = 0; i < cache.Length; i++)
        {
            for (var j = 0; j < cache[i]; j++)
            {
                nums[reconstructedIdx] = i;
                reconstructedIdx++;
            }
        }
    }
}