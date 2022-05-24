public class Solution 
{
    public int MaxSubArray(int[] nums) 
    {
        var currentSub = nums[0];
        var maxSub = nums[0];
        
        for(var i = 1; i < nums.Length; i++)
        {
            var num = nums[i];
            if (currentSub < 0)
                currentSub = num;
            else
                currentSub += num;
            
            maxSub = Math.Max(maxSub, currentSub);
        }
        
        return maxSub;
    }
}