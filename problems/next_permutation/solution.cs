public class Solution
{
    private int IsStrictlyDescendingFrom(int[] arr)
    {
        for(var i = arr.Length - 1; i > 0; i--)
        {
            if (arr[i] > arr[i - 1])
                return i;
        }
        return 0;
    }

    public void NextPermutation(int[] nums)
    {
        var len = nums.Length;
        var subStartIdx = IsStrictlyDescendingFrom(nums);


        if (subStartIdx == 0)
        {
            Array.Sort(nums);
            return;
        }

        var toBeReplacedIdx = subStartIdx - 1;
        var toReplaceIdx =
            Enumerable.Range(subStartIdx, len - subStartIdx)
            .Reverse()
            .First(i => nums[i] > nums[toBeReplacedIdx]);

        (nums[toBeReplacedIdx], nums[toReplaceIdx]) = (nums[toReplaceIdx], nums[toBeReplacedIdx]);
        Array.Sort(nums, subStartIdx, len - subStartIdx);

    }
}