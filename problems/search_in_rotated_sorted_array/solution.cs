public class Solution 
{
    // log(n)
    private int BinarySearchForRotationPivot(int[] nums)
    {
        var start = 0;
        var end = nums.Length-1;
        
        while(start <= end)
        {
            var mid = (start+end)/2;
            var midNum = nums[mid];
            var _midNum = mid - 1 >= 0 ? nums[mid-1] : Int32.MinValue;
            var midNum_ = mid + 1 < nums.Length ? nums[mid+1] : Int32.MaxValue;
            
            if(_midNum > midNum && midNum < midNum_)
            {
                return mid;
            }
            
            if (midNum > nums[end])
            {
                start = mid + 1;    
            }
            else
            {
                end = mid - 1;
            }
        }
        return 0;
    }
    
    // log(n)
    private int BinarySearchWithRotationPivot(int[] nums, int pivot, int target)
    {
        int GetUnrotatedValue(int indexIfSorted)
        {
            var rotatedIndex = (indexIfSorted+pivot) % nums.Length;
            return nums[rotatedIndex];
        }
        
        var start = 0;
        var end = nums.Length-1;
        while(start <= end)
        {
            var mid = (start+end)/2;
            var midNum = GetUnrotatedValue(mid);
            
            // Console.WriteLine($"Start: {start}, End: {end}, Mid: {mid}, MidVal: {midNum}");
            
            if (midNum == target) 
            {
                var indexIfSorted = mid;
                var rotatedIndex = (indexIfSorted+pivot) % nums.Length;
                return rotatedIndex;
                
            }
            else if (midNum > target)
            {
                end = mid - 1;
            }
            else
            {
                start = mid + 1;
            }
        }
        
        return -1;
    }
    
    public int Search(int[] nums, int target) 
    {
        var pivot = BinarySearchForRotationPivot(nums);
        // Console.WriteLine($"Find pivot located at {pivot}, value = {nums[pivot]}");
        var result = BinarySearchWithRotationPivot(nums, pivot, target);
        
        return result;
    }
}