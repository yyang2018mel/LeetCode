public class Solution 
{
    
    private int BinarySearchForInsertion(int[] num, int target)
    {
        var start = 0;
        var end = num.Length-1;
        var mid = -1;
        
        while(start <= end)
        {
            mid = (start+end)/2;
            
            if(num[mid] == target)
            {
                return mid;
            }
            if(num[mid] > target)
            {
                end = mid - 1;
            }
            else
            {
                start = mid + 1;
            }
        }
        
        if (num[mid] > target)
        {
            return mid;
        }
        else // (num[mid] < target)
        {
            return mid+1;
        }
    }
    
    
    public int SearchInsert(int[] nums, int target) 
    {
        return BinarySearchForInsertion(nums, target);
    }
}