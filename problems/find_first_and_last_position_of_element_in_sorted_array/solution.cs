public class Solution
{
    private int SearchBound(int[] nums, int target, int startIdx, int length, bool goLower)
    {
        var found = Array.BinarySearch(nums, startIdx, length, target);
        if (found < 0)
        {
            return -1;
        }
        else
        {
            var bound = found;

            if (goLower)
            {
                if (found > 0)
                {
                    var lower_ = SearchBound(nums, target, 0, found, goLower);

                    if (lower_ >= 0)
                        bound = lower_;
                }
            }
            else
            {
                if (found < nums.Length - 1)
                {
                    var higher_ = SearchBound(nums, target, found + 1, nums.Length - found - 1, goLower);

                    if (higher_ >= 0)
                        bound = higher_;
                }
            }

            return bound;
        }

    }

    public int[] SearchRange(int[] nums, int target)
    {
        var low = SearchBound(nums, target, 0, nums.Length, true);
        var high = low;

        if(low >= 0 && low < nums.Length - 1)
        {
            var high_ = SearchBound(nums, target, low + 1, nums.Length - low - 1, false);
            if (high_ > 0)
                high = high_;
        }

        return new int[] { low, high };
    }
}