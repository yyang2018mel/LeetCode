public class Solution
{
    private int SmallestGreaterThan(int[] nums, int endIdx, int target)
    {
        for(var j = nums.Length-1; j >= endIdx; j--)
        {
            if (nums[j] > target) return j;
        }

        throw new Exception("SmallestGreaterThan");
    }

    private bool IsInDescendingOrder(int [] nums, int startIdx)
    {
        // provided everything after 'startIdx' is in descending order
        if (startIdx < 0)
        {
            throw new Exception("IsInDescendingOrder - Invalid startIdx");
        }
        else if (startIdx == nums.Length - 1)
        {
            return true;
        }
        else
            return nums[startIdx] >= nums[startIdx + 1];
    }

    public void NextPermutation(int[] nums)
    {
        var last = nums.Length - 1;
        for(var j = last-1; j >=0; j--)
        {
            if(!IsInDescendingOrder(nums, j))
            {
                // e.g. 1 3 4 2 => 1 4 2 3
                // e.g. 1 4 3 2 => 2 1 3 4
                var sgt = SmallestGreaterThan(nums, j + 1, nums[j]);
                (nums[j], nums[sgt]) = (nums[sgt], nums[j]);
                Array.Sort(nums, j + 1, nums.Length - j - 1);
                return;
            }
        }

        Array.Sort(nums);
    }
}