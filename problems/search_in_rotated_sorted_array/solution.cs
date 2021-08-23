using static System.Math;

public class Solution
{
    public static int FindPivot(int[] nums, int start, int end)
    {
        // gurantee to find one pivot
        var mid = (start + end) / 2;

        if (mid + 1 >= nums.Length)
            return mid;

        if (nums[mid] > nums[mid + 1])
        {
            return mid + 1;
        }

        if(mid-1 >= 0 && nums[mid] < nums[mid-1])
        {
            return mid;
        }

        if(nums[start] < nums[mid]) 
        {
            // e.g. [3 4 5 6 0 1]
            return FindPivot(nums, mid + 1, end);
        }
        else
        {
            // e.g. [6 7 0 1 2 3 4 5]
            return FindPivot(nums, start, mid - 1);
        }
    }

    public int Search(int[] nums, int target)
    {
        var pivotIdx = FindPivot(nums, 0, nums.Length);

        if (pivotIdx >= 1 && target >= nums[0] && target <= nums[pivotIdx - 1])
        {
            return Max(-1, Array.BinarySearch(nums, 0, pivotIdx, target));
        }
        else if (target >= nums[pivotIdx] && target <= nums[nums.Length - 1])
        {
            return Max(-1, Array.BinarySearch(nums, pivotIdx, nums.Length - pivotIdx, target));
        }

        return -1;
    }
}