public class Solution 
{
    public void WiggleSort(int[] nums) 
    {
        var upState = true;
        for(var i = 1; i < nums.Length; i++)
        {
            var current = nums[i];
            var previous = nums[i-1];
            if ((upState && previous > current) || (!upState && previous < current))
            {
                nums[i] = previous;
                nums[i-1] = current;
            }
            
            upState = !upState;
        }
    }
}