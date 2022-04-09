public class Solution 
{
    public int RemoveDuplicates(int[] nums) 
    {
        var unique = 1;
        var maxIdx = nums.Length-1;
        
        if(nums[0] != nums[maxIdx])
        {
            for(var idx = 0; idx < maxIdx; idx++)
            {
                if(nums[idx] != nums[idx+1])
                {
                    nums[unique] = nums[idx+1];   
                    unique++;
                }
            }    
        }
        
        return unique;
    }
}