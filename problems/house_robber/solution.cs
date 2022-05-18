public class Solution 
{
    public int Rob(int[] nums) 
    {
        var maxCache = new int[nums.Length];
        
        for (var i = 0; i < maxCache.Length; i++)
        {
            if (i == 0) 
            {
                maxCache[i] = nums[i];
            }
            else if (i == 1)
            {
                maxCache[i] = Math.Max(nums[i], nums[i-1]);
            }
            else
            {
                // use i
                var robi = nums[i] + maxCache[i-2];
                // not use i
                var notrobi = maxCache[i-1];
                // take optimal
                maxCache[i] = Math.Max(robi, notrobi);                
            } 
        }
        
        return maxCache[maxCache.Length-1];
    }
}