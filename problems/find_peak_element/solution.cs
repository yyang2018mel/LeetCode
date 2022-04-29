public class Solution 
{
    public int FindPeakElement(int[] nums)
    {   
        var start = 0;
        var end = nums.Length-1;
        
        while(start <= end)
        {
            var mid = (start+end)/2;
            var greaterThanPrev = 
                mid - 1 < 0 || nums[mid-1] < nums[mid];
            var greaterThanNext = 
                mid + 1 >= nums.Length || nums[mid] > nums[mid+1];
            
            if (greaterThanPrev && greaterThanNext) return mid;    
            if (greaterThanPrev && !greaterThanNext) start = mid + 1;
            else if (!greaterThanPrev && greaterThanNext) end = mid - 1;
            else if (!greaterThanPrev && !greaterThanNext) start = mid + 1;
        }
        
        throw new Exception("Unexpected code path hit");
    }
}