public class Solution 
{
    public bool CanJump(int[] nums) 
    {
        int?[] furthest = new int?[nums.Length];
        furthest[0] = nums[0];
        
        for(var count = 1; count < furthest.Length; count++)
        {
            if (furthest[count-1] < count) // index "count" is not reacheable
                break;
            furthest[count] = Math.Max(furthest[count-1].Value, nums[count]+count);
        }
        
        return furthest[furthest.Length-1] is not null;
    }
}