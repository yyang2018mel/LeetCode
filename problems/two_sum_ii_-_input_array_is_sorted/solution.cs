public class Solution
    {
        public int[] TwoSum(int[] numbers, int target)
        {
            // numbers is sorted in non-decreasing order
            for (var idx = 0; idx < numbers.Length; idx++)
            {
                var fixed_ = numbers[idx];
                var composite = target - fixed_;

                if (fixed_ == composite)
                {
                    if (idx + 1 < numbers.Length && numbers[idx + 1] == composite)
                    {
                        // returned index should be 1-based
                        var result = new int[] { idx + 1, idx + 1 + 1 };
                        Array.Sort(result);
                        return result;
                    }    
                    continue;
                }

                var search = Array.BinarySearch(numbers, composite);

                if (search > 0 && search != idx)
                {
                    // returned index should be 1-based
                    var result = new int[] { idx + 1, search + 1 };
                    Array.Sort(result);
                    return result;
                }                    
            }

            throw new NotSupportedException();
        }
    }